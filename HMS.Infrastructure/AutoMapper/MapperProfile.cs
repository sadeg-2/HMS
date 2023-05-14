using AutoMapper;
using HMS.Core.Dtos;
using HMS.Core.ViewModels;
using HMS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile() {
            CreateMap<User, UserViewModel>().ForMember(x => x.UserType, x => x.MapFrom(x => x.UserType.ToString()));
            CreateMap<CreateUserDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<UpdateNurseDto, User>().ForMember(x => x.ImageUrl, x => x.Ignore());
            CreateMap<User, UpdateNurseDto>().ForMember(x => x.Image, x => x.Ignore());


            CreateMap<Nurse, NurseViewModel>();
            CreateMap<CreateNurseDto, Nurse>();
            CreateMap<UpdateNurseDto, Nurse>();
            CreateMap<Nurse, UpdateNurseDto>();

            CreateMap<CreateUserDto , CreateNurseDto>();
            CreateMap<UpdateUserDto , UpdateNurseDto>();
            CreateMap<UpdateNurseDto , UpdateUserDto>();

            CreateMap<Doctor, DoctorViewModel>();

            CreateMap<Patient, PatientViewModel>();


        }
    }
}
