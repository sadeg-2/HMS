using HMS.Infrastructure.Services;
using HMS.Infrastructure.Services.Users;
using HMS.Core.Enums;
using HMS.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HMS.Infrastructure.Services.DashBoard;

namespace HMS.Web.Controllers
{
    public class HomeController : BaseController
    {

        private readonly IDashboardService _dashboardService;

        public HomeController(IDashboardService dashboardService, IUserService userService) : base(userService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            if (userType != "Administrator")
            {
                return Redirect("/home/privacy");
            }
            var data = await _dashboardService.GetData();

            return View(data);
        }
        public async Task<IActionResult> Privacy()
        {
            return View();
        }

        public async Task<IActionResult> GetUserTypeChartData()
        {
            var data = await _dashboardService.GetUserTypeChart();

            return Ok(data);
        }
    }
}