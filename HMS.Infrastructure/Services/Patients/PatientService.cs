using AutoMapper;
using HMS.Core.Constants;
using HMS.Core.Dtos;
using HMS.Core.Enums;
using HMS.Core.Exceptions;
using HMS.Core.ViewModels;
using HMS.Data;
using HMS.Data.Models;
using HMS.Infrastructure.Helpers;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Infrastructure.Services.Patients
{
    public class PatientService : IPatientService
    {
        private readonly HMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;


        public PatientService(IEmailService emailService,
            HMSDbContext db,
            IMapper mapper,
            IFileService fileService,
            IUserService userService,
            UserManager<User> userManager
            )
        {
            _db = db;
            _mapper = mapper;
            _fileService = fileService;
            _emailService = emailService;
            _userService = userService;
            _userManager = userManager;
            _userManager = userManager;
        }

        public async Task<int> Create(CreatePatientDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));

            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();

            }

            var patient = new Patient()
            {
                HasNurse = false,
                User = new User()
                {
                    FullName = dto.FullName,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    DOB = dto.DOB,
                    UserType = UserType.Patient,
                    UserName = dto.Email,
                },
                NurseId = await GetLessThanNurse(),
                CreatedBy = _userService.GetCurrentUserName(),
                CreatedAt = DateTime.Now,
            };
            if (dto.Image != null)
            {
                patient.User.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }

            var password = GenratePassword();

            try

            {
                var result = await _userManager.CreateAsync(patient.User, password);

                if (!result.Succeeded)
                {
                    throw new OperationFailedException();
                }

            }
            catch (Exception)
            {

            }
            await _emailService.Send(patient.User.Email, "New Account !", $"Hello dear Patient,\nthis is the login data for your account in the hospital \n Username is : {patient.User.Email} and Password is {password}");

            await _db.AddAsync(patient);
            await _db.SaveChangesAsync();

            return patient.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var patient = await _db.Patients.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (patient == null)
            {
                throw new EntityNotFoundException();
            }
            var userId = patient.UserId;
            patient.IsDelete = true;
            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();
            if (userId != null)
            {
                await _userService.Delete(userId);
            }

            return patient.Id;
        }

        public async Task<UpdatePatientDto> Get(int Id)
        {
            var patient = await _db.Patients.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);

            if (patient == null)
            {
                throw new EntityNotFoundException();
            }
            var updatePatientDto = new UpdatePatientDto()
            {
                DOB = patient.User.DOB,
                Email = patient.User.Email,
                FullName = patient.User.FullName,
                Id = Id,
                PhoneNumber = patient.User.PhoneNumber,
                UserType = patient.User.UserType,
            };
            return updatePatientDto;
        }
    

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Patients.Include(x => x.User).
                                           Include(x => x.Nurse).ThenInclude(x => x.User).
                                           Include(x => x.Nurse).ThenInclude(x => x.Doctors).ThenInclude(x => x.User).
                                           Where(x => !x.IsDelete &&
                               (x.User.FullName.Contains(query.GeneralSearch) ||
                               string.IsNullOrWhiteSpace(query.GeneralSearch) ||
                               x.User.Email.Contains(query.GeneralSearch) ||
                               x.User.PhoneNumber.Contains(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var patients = _mapper.Map<List<PatientViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = patients,
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

        public async Task<int> Update(UpdatePatientDto dto)
        {
            var emailOrPhoneIsExist = _db.Patients.Any(x => !x.IsDelete && (x.User.Email == dto.Email || x.User.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var patient = await _db.Patients.FindAsync(dto.Id);

            var user = await _db.Users.FindAsync(patient.UserId);

            if (user != null)
            {
                user.FullName = dto.FullName;
                user.Email = dto.Email;
                user.PhoneNumber = dto.PhoneNumber;
                user.UserName = dto.Email;
                user.DOB = dto.DOB;
                if (dto.Image != null)
                {
                    user.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
                }
                user.UpdatedBy = _userService.GetCurrentUserName();
                user.UpdatedAt = DateTime.Now;
            }
            else {
                throw new EntityNotFoundException();
            }

            _db.Users.Update(user);
            _db.Patients.Update(patient);
            await _db.SaveChangesAsync();
            return patient.Id;
        }

        private async Task<int?> GetLessThanNurse() {
            var nurse = await _db.Nurses
                .Where(x => !x.IsDelete)
                .OrderBy(x => x.NumberOfPatients)
                .FirstOrDefaultAsync();

            if (nurse == null) {
                return null;
            }
            return nurse.Id;
   
        }
        private string GenratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 7);
        }

        public async Task<byte[]> ExportToExcel()
        {
            var users = await _db.Patients.Include(x => x.User).
                                           Include(x => x.Nurse).ThenInclude(x => x.User).
                                           Include(x => x.Nurse).ThenInclude(x => x.Doctors).ThenInclude(x => x.User).
                                           Where(x => !x.IsDelete).ToListAsync();

            return ExcelHelpers.ToExcel(new Dictionary<string, ExcelColumn>
            {
                {"FullName", new ExcelColumn("FullName", 0)},
                {"Email", new ExcelColumn("Email", 1)},
                {"Phone", new ExcelColumn("Phone", 2)},
                {"Nurse", new ExcelColumn("Nurse", 3)},
                {"Doctor", new ExcelColumn("Doctor", 4)},


            }, new List<ExcelRow>(users.Select(e => new ExcelRow
            {
                Values = new Dictionary<string, string>
                {
                    {"FullName", e.User.FullName},
                    {"Email", e.User.Email},
                    {"Phone", e.User.PhoneNumber},
                    {"Nurse", e.Nurse.User.FullName},
                    {"Doctor", e.Nurse.Doctors.User.FullName},

                }
            })));
        }
    }
}

