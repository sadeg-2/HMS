using AutoMapper;
using HMS.Core.Dtos;
using HMS.Core.ViewModels;
using HMS.Infrastructure.Services;
using HMS.Core.Exceptions;
using HMS.Data.Models;
using HMS.Infrastructure.Services.Users;
using HMS.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HMS.Core.Constants;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Query = HMS.Core.Dtos.Query;
using HMS.Infrastructure.Helpers;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Linq;
using HMS.Core.Enums;

namespace HMS.Infrastructure.Services.Users
{
    public class UserService : IUserService
    {
        private readonly HMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserService(
                IEmailService emailService,
                HMSDbContext db,
                IMapper mapper,
                UserManager<User> userManager,
                IFileService fileService,
                IHttpContextAccessor httpContextAccessor
                )
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _emailService = emailService;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<User> GetAllData()
        {
            var users = _db.Users.ToList();

            return users;

        }
        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Users.Where(
                x => !x.IsDelete && (
                x.FullName.Contains(query.GeneralSearch)
                || string.IsNullOrWhiteSpace(query.GeneralSearch)                 
               
                )).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var users = _mapper.Map<List<UserViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = users,
                meta = new Meta
                {
                    page = pagination.Page,
                    perpage = pagination.PerPage,
                    pages = pages,
                    total = dataCount,
                }
            };
            return result;
        }
        public  UserViewModel GetUserByUsername(string username)
        {
            var user =  _db.Users.SingleOrDefault(x => x.UserName == username && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            return _mapper.Map<UserViewModel>(user);
        }


        public async Task<string> Create(CreateUserDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));

            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }

            var user = _mapper.Map<User>(dto);

            user.UserName = dto.Email;
            
            if(dto.Image != null)
            {
                user.ImageUrl =  await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }

            var password = GenratePassword();

            try
            {
                var result = await _userManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    throw new OperationFailedException();
                }

            }
            catch(Exception e)
            {

            }
          

            await _emailService.Send(user.Email, "New Account !", $"Username is : {user.Email} and Password is { password }");

            return user.Id;
        }

        public async Task<string> Update(UpdateUserDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var user = await _db.Users.FindAsync(dto.Id);
            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.UserName = dto.Email;
            user.DOB = dto.DOB;

            if (dto.Image != null)
            {
                user.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }
            _db.Users.Update(user);
            await _emailService.Send(user.Email, "Updated Your Data ! ","Your Data is updated hh");

            _db.SaveChanges();
            return user.Id;
        }

        public async Task<string> Delete(string Id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if(user == null)
            {
                throw new EntityNotFoundException();
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return user.Id;
        }


        public async Task<UpdateUserDto> Get(string Id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }
            var updated = new UpdateUserDto() { 
                Id  = user.Id,
                DOB = user.DOB,
                Email=user.Email,
                FullName=user.FullName,
                PhoneNumber = user.PhoneNumber ,
                UserType = user.UserType 
            };

            return updated;
        }

        public async Task<byte[]> ExportToExcel()
        {
            var users = await _db.Users.Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"FullName", new ExcelColumn("FullName", 0)},
                {"Email", new ExcelColumn("Email", 1)},
                {"Phone", new ExcelColumn("Phone", 2)},
                {"User Type", new ExcelColumn("User Type", 3)}

            }, new List<ExcelRow>(users.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"FullName", e.FullName},
                    {"Email", e.Email},
                    {"Phone", e.PhoneNumber},
                    {"User Type", e.UserType.ToString()},
                }
            })));
        }
        public string GetCurrentUserName()
        {
            string userId =  _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            User currentUser = _userManager.FindByIdAsync(userId).Result;
            string systemUserName = currentUser.FullName;

            return systemUserName;
        }

        private string GenratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 7);
        }
    }
}
