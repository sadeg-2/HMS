using HMS.Core.Dtos;
using HMS.Infrastructure.Services.Nurses;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Web.Controllers
{
    public class NurseController : Controller
    {
        protected INurseService _nurseService;
        public NurseController(INurseService nurseService) {
            _nurseService = nurseService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateNurseDto dto)
        {
            if (ModelState.IsValid)
            {
                await _nurseService.Create(dto);
                return RedirectToAction("Index");
            }

            return View();
        }

        public async Task<JsonResult> GetNurseData(Pagination pagination, Query query)
        {
            var result = await _nurseService.GetAll(pagination, query);
            return Json(result);
        }



    }
}
