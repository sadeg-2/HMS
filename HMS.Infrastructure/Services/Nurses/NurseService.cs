using AutoMapper;
using HMS.Core.Constants;
using HMS.Core.Dtos;
using HMS.Core.Enums;
using HMS.Core.Exceptions;
using HMS.Core.ViewModels;
using HMS.Data;
using HMS.Data.Models;
using HMS.Infrastructure.Services.Patients;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HMS.Infrastructure.Services.Nurses
{
    public class NurseService : INurseService
    {
        private readonly HMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        private readonly IPatientService _patientService;
        public NurseService(
                        IEmailService emailService,
                        HMSDbContext db,
                        IMapper mapper,
                        IFileService fileService,
                        UserManager<User> userManager,
                        IUserService userService,
                        IPatientService patientService
                        )
        {
            _db = db;
            _mapper = mapper;
            _emailService = emailService;
            _fileService = fileService;
            _userManager = userManager;
            _userService = userService;
            _patientService = patientService;
        }


        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Nurses.Include(x => x.User).
                                Include(nurse => nurse.Doctors).
                                ThenInclude(doctor => doctor.User).
                                Where(x => !x.IsDelete &&
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

        public async Task<int> Create(CreateNurseDto dto)
        {
            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }

            var nurse = new Nurse()
            {
                NumberOfPatients = 0,
                ShiftsOfNurse = dto.ShiftsOfNurse,
                User = new User()
                {
                    FullName = dto.FullName,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    DOB = dto.DOB,
                    UserType = dto.UserType,
                    UserName = dto.Email,
                },
                DoctorId = await GetLessThanDoctor(),
                CreatedBy = _userService.GetCurrentUserName(),
                CreatedAt = DateTime.Now ,

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
            catch (Exception)
            {

            }
            await _emailService.Send(nurse.User.Email, "New Account !", $"Hello dear nurse,\nthis is the login data for your account in the hospital \n Username is : {nurse.User.Email} and Password is {password}");

            await _db.AddAsync(nurse);
            await _db.SaveChangesAsync();

            await DistributionNurse();

            return nurse.Id;
        }

        public async Task<int> Update(UpdateNurseDto dto)
        {
            var emailOrPhoneIsExist = _db.Nurses.Any(x => !x.IsDelete && (x.User.Email == dto.Email || x.User.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var nurse = await _db.Nurses.FindAsync(dto.Id);
            nurse.ShiftsOfNurse = dto.ShiftsOfNurse;

            var user = await _db.Users.FindAsync(nurse.UserId);
            user.FullName = dto.FullName;
            user.Email = dto.Email;
            user.PhoneNumber = dto.PhoneNumber;
            user.UserName = dto.Email;
            user.DOB = dto.DOB;
            user.UpdatedBy = _userService.GetCurrentUserName();
            user.UpdatedAt = DateTime.Now;


            if (dto.Image != null)
            {
                user.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }
   
            _db.Users.Update(user);
            _db.Nurses.Update(nurse);
            await _db.SaveChangesAsync();
            return nurse.Id;
        }


        public async Task<int> Delete(int Id)
        {
            var nurse = await _db.Nurses.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (nurse == null)
            {
                throw new EntityNotFoundException();
            }
            var userId = nurse.UserId;
            nurse.IsDelete = true;
            _db.Nurses.Update(nurse);
            await _db.SaveChangesAsync();
            if (userId != null)
            {
                await _userService.Delete(userId);
                await DistributionNurse();
            }

            return nurse.Id;
        }

        public async Task<UpdateNurseDto> Get(int Id)
        {
            var nurse = await _db.Nurses.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);

            if (nurse == null)
            {
                throw new EntityNotFoundException();
            }
            var updateNurseDto = new UpdateNurseDto()
            {
                DOB = nurse.User.DOB,
                Email = nurse.User.Email,
                FullName = nurse.User.FullName,
                Id = Id,
                PhoneNumber = nurse.User.PhoneNumber,
                ShiftsOfNurse = nurse.ShiftsOfNurse,
                UserType = UserType.Nurse,

            };
            return updateNurseDto;
        }

        private string GenratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 7);
        }

        private async Task DistributionNurse()
        {
            var patients = await _db.Patients.Where(patient => !patient.IsDelete).ToListAsync();
           
            var nurses = await _db.Nurses.Where(nurse => !nurse.IsDelete).ToListAsync();
            foreach (var nurse in nurses)
            {
                nurse.NumberOfPatients = 0;
            }
            if (patients == null || patients == null)
            {
                return;
            }
            var numOfNurse = nurses.Count();
            var numOfPatient = patients.Count();
            for (int i = 0 , j = 0; i < numOfPatient; i++)
            {
                patients[i].NurseId = nurses[j].Id;
                nurses[j].NumberOfPatients++;
                j++;
                
                if (j == numOfNurse)
                {
                    j = 0;
                }
            }
            _db.Nurses.UpdateRange(nurses);
            _db.Patients.UpdateRange(patients);
            await _db.SaveChangesAsync();
        }

        private async Task<int?> GetLessThanDoctor()
        {
            var doctor = await _db.Doctors
                .Where(x => !x.IsDelete)
                .OrderBy(x => x.NumberOfNurses)
                .FirstOrDefaultAsync();

            if (doctor == null)
            {
                return null;
            }
            return doctor.Id;

        }
    }
}
