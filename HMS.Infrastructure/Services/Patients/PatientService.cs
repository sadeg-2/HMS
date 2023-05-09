using AutoMapper;
using HMS.Data.Models;
using HMS.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.Core.Dtos;

namespace HMS.Infrastructure.Services.Patients
{
    public class PatientService : IPatientService
    {
        private readonly HMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly UserManager<User> _userManager;
        private readonly IEmailService _emailService;

        public PatientService(IEmailService emailService, HMSDbContext db, IMapper mapper, UserManager<User> userManager, IFileService fileService)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _emailService = emailService;
        }

      




    }
}
