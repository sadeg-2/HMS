using AutoMapper;
using HMS.Core.Dtos;
using HMS.Core.ViewModels;
using HMS.Data.Models;

namespace HMS.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserViewModel>().ForMember(x => x.UserType, x => x.MapFrom(x => x.UserType.ToString()));
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateNurseDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<User, UpdateNurseDto>().ForMember(x => x.Image, x => x.Ignore());


            CreateMap<Nurse, NurseViewModel>().ForMember(vm => vm.doctor, 
                    x => x.MapFrom(x => x.Doctors));

            CreateMap<CreateNurseDto, Nurse>();
            CreateMap<UpdateNurseDto, Nurse>();
            CreateMap<Nurse, UpdateNurseDto>();

            CreateMap<CreateUserDto, CreateNurseDto>();
            CreateMap<UpdateUserDto, UpdateNurseDto>();
            CreateMap<UpdateNurseDto, UpdateUserDto>();

            CreateMap<Doctor, DoctorViewModel>();


            CreateMap<Patient, PatientViewModel>().ForMember(dest => dest.Doctor,
                x => x.MapFrom(x => x.Nurse.Doctors));




        }
    }
}
