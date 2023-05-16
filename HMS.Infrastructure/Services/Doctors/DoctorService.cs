using AutoMapper;
using HMS.Core.Dtos;
using HMS.Data.Models;
using HMS.Data;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using HMS.Core.Constants;
using HMS.Core.Exceptions;
using HMS.Core.Enums;

namespace HMS.Infrastructure.Services.Doctors
{
    public class DoctorService : IDoctorService
    {
        private readonly HMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly IUserService _userService;
        public DoctorService(
                        IEmailService emailService,
                        HMSDbContext db,
                        IMapper mapper,
                        IFileService fileService,
                        UserManager<User> userManager,
                        IUserService userService
                        )
        {
            _db = db;
            _mapper = mapper;
            _emailService = emailService;
            _fileService = fileService;
            _userManager = userManager;
            _userService = userService;
        }
        public async Task<int> Create(CreateDoctorDto dto)
        {

            var emailOrPhoneIsExist = _db.Users.Any(x => !x.IsDelete && (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber));

            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();

            }

            var doctor = new Doctor()
            {
                NumberOfNurses = 0,
                shiftsOfDoctor = dto.shiftsOfDoctor,
                User = new User()
                {
                    FullName = dto.FullName,
                    PhoneNumber = dto.PhoneNumber,
                    Email = dto.Email,
                    DOB = dto.DOB,
                    UserType = UserType.Doctor,
                    UserName = dto.Email,
                },
                CreatedBy = _userService.GetCurrentUserName(),
                CreatedAt = DateTime.Now,
            };
            if (dto.Image != null)
            {
                doctor.User.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImagesFolder);
            }

            var password = GenratePassword();

            try

            {
                var result = await _userManager.CreateAsync(doctor.User, password);

                if (!result.Succeeded)
                {
                    throw new OperationFailedException();
                }

            }
            catch (Exception e)
            {

            }
            await _emailService.Send(doctor.User.Email, "New Account !", $"Hello dear Doctor,\nthis is the login data for your account in the hospital \n Username is : {doctor.User.Email} and Password is {password}");

            await _db.AddAsync(doctor);
            await _db.SaveChangesAsync();

            await DistributionDoctor();

            return doctor.Id;
        }

        public async Task<int> Delete(int Id)
        {
            var doctor = await _db.Doctors.SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);
            if (doctor == null)
            {
                throw new EntityNotFoundException();
            }
            var userId = doctor.UserId;
            doctor.IsDelete = true;
            _db.Doctors.Update(doctor);
            await _db.SaveChangesAsync();
            if (userId != null)
            {
                await _userService.Delete(userId);
                await DistributionDoctor();
            }
            return doctor.Id;
        }

        public async Task<UpdateDoctorDto> Get(int Id)
        {
            var doctor = await _db.Doctors.Include(x => x.User).SingleOrDefaultAsync(x => x.Id == Id && !x.IsDelete);

            if (doctor == null)
            {
                throw new EntityNotFoundException();
            }
            var updateDoctorDto = new UpdateDoctorDto()
            {
                DOB = doctor.User.DOB,
                Email = doctor.User.Email,
                FullName = doctor.User.FullName,
                Id = Id,
                PhoneNumber = doctor.User.PhoneNumber,
                shiftsOfDoctor = doctor.shiftsOfDoctor,

            };
            return updateDoctorDto;
        }

        public async Task<ResponseDto> GetAll(Pagination pagination, Query query)
        {
            var queryString = _db.Doctors.Include(x => x.User).Where(x => !x.IsDelete &&
                               (x.User.FullName.Contains(query.GeneralSearch) ||
                               string.IsNullOrWhiteSpace(query.GeneralSearch) ||
                               x.User.Email.Contains(query.GeneralSearch) ||
                               x.User.PhoneNumber.Contains(query.GeneralSearch))).AsQueryable();

            var dataCount = queryString.Count();
            var skipValue = pagination.GetSkipValue();
            var dataList = await queryString.Skip(skipValue).Take(pagination.PerPage).ToListAsync();
            var doctors = _mapper.Map<List<DoctorViewModel>>(dataList);
            var pages = pagination.GetPages(dataCount);
            var result = new ResponseDto
            {
                data = doctors,
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

        public async Task<int> Update(UpdateDoctorDto dto)
        {
            var emailOrPhoneIsExist = _db.Doctors.Any(x => !x.IsDelete && (x.User.Email == dto.Email || x.User.PhoneNumber == dto.PhoneNumber) && x.Id != dto.Id);
            if (emailOrPhoneIsExist)
            {
                throw new DuplicateEmailOrPhoneException();
            }
            var doctor = await _db.Doctors.FindAsync(dto.Id);
            doctor.shiftsOfDoctor = dto.shiftsOfDoctor;

            var user = await _db.Users.FindAsync(doctor.UserId);
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
            _db.Doctors.Update(doctor);
            await _db.SaveChangesAsync();
            return doctor.Id;
        }

        private async Task DistributionDoctor()
        {
            var doctors = await _db.Doctors.Where(doctor => !doctor.IsDelete).ToListAsync();

            var nurses = await _db.Nurses.Where(nurse => !nurse.IsDelete).ToListAsync();
            foreach (var doctor in doctors)
            {
                doctor.NumberOfNurses = 0;
            }
            if (nurses == null || doctors == null)
            {
                return;
            }
            var numOfNurse = nurses.Count();
            var numOfDoctor = doctors.Count();
            for (int i = 0, j = 0; i < numOfNurse; i++)
            {
                nurses[i].DoctorId = doctors[j].Id;
                doctors[j].NumberOfNurses++;
                j++;
                if (j == numOfDoctor)
                {
                    j = 0;
                }
            }
            _db.Nurses.UpdateRange(nurses);
            _db.Doctors.UpdateRange(doctors);
            await _db.SaveChangesAsync();
        }
        private string GenratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 7);
        }
    }
}
