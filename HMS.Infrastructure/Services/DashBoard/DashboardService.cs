using HMS.Core.ViewModels;
using HMS.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Infrastructure.Services.DashBoard
{
    public class DashboardService: IDashboardService
    {
        private readonly HMSDbContext _db;

        public DashboardService(HMSDbContext db)
        {
            _db = db;
        }

        public async Task<DashboardViewModel> GetData()
        {
            var data = new DashboardViewModel();
            data.NumberOfNurse = await _db.Nurses.CountAsync(x => !x.IsDelete);
            data.NumberOfDoctor = await _db.Doctors.CountAsync(x => !x.IsDelete);
            data.NumberOfPatient = await _db.Patients.CountAsync(x => !x.IsDelete);
            return data;
        }

        public async Task<List<PieChartViewModel>> GetUserTypeChart()
        {

            var data = new List<PieChartViewModel>();
            data.Add(new PieChartViewModel()
            {
                Key = "Doctors",
                Value = await _db.Doctors.CountAsync(x => !x.IsDelete ),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Nurse",
                Value = await _db.Nurses.CountAsync(x => !x.IsDelete ),
                color = GenrateColor()
            });
            data.Add(new PieChartViewModel()
            {
                Key = "Patient",
                Value = await _db.Patients.CountAsync(x => !x.IsDelete),
                color = GenrateColor()
            });
            return data;
        }

        private string GenrateColor()
        {
            var random = new Random();
            return String.Format("#{0:X6}", random.Next(0x1000000));
        }

    }
}
