using AutoMapper;
using HMS.Core.Dtos;
using HMS.Data;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Infrastructure.Services.Users;
using HMS.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using HMS.Core.Constants;
using HMS.Core.Exceptions;
using HMS.Data.Models;
using HMS.Core.Enums;

namespace HMS.Infrastructure.Services.Nurses
{
    public class NurseService : INurseService
    {
        private readonly HMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        public NurseService(
                        IEmailService emailService,
                        HMSDbContext db,
                        IMapper mapper,
                        IFileService fileService,
                        UserManager<User> userManager
                        )
        {
            _db = db;
            _mapper = mapper;
            _emailService = emailService;
            _fileService = fileService;
            _userManager = userManager;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Nurses.Include(x => x.User).Where(x => !x.IsDelete &&
                                (x.User.FullName.Contains(query.GeneralSearch) ||
                                string.IsNullOrWhiteSpace(query.GeneralSearch) ||
                                x.User.Email.Contains(query.GeneralSearch) ||
                                x.User.PhoneNumber.Contains(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var users = _mapper.Map<List<NurseViewModel>>(dataList);
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

        public async Task<string> Create(CreateNurseDto dto)
        {
            //var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));

            //if (emailOrPhoneIsExist)
            //{
            //    throw new DuplicateEmailOrPhoneException();
            //}

            var nurse = new Nurse() {
                NumberOfPatients = 0,
                ShiftsOfNurse = dto.ShiftsOfNurse,
                User = new User() {
                    FullName = dto.FullName,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    DOB = dto.DOB,
                    UserType = dto.UserType,
                    UserName = dto.Email,
                },
           
            };

            if (dto.Image != null)
            {
                nurse.User.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }

            var password = GenratePassword();

            try
            
            {
                var result = await _userManager.CreateAsync(nurse.User, password);

                if (!result.Succeeded)
                {
                    throw new OperationFailedException();
                }

            }
            catch (Exception e)
            {

            }
            await _emailService.Send(nurse.User.Email, "New Account !", $"Hello dear nurse,\nthis is the login data for your account in the hospital \n Username is : {nurse.User.Email} and Password is {password}");
           


            await _db.AddAsync(nurse);
            _db.SaveChanges();

            return nurse.User.Id;


        }

        public Task<string> Update(UpdateNurseDto dto)
        {
            throw new NotImplementedException();
        }


        public Task<string> Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateNurseDto> Get(string Id)
        {
            throw new NotImplementedException();
        }

        private string GenratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 7);
        }

    }
}
