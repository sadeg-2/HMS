using HMS.Core.Dtos;
using HMS.Infrastructure.Services.Nurses;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Results = HMS.Core.Constants.Results;

namespace HMS.Web.Controllers
{
    public class NurseController : BaseController
    {
        protected INurseService _nurseService;
        public NurseController(INurseService nurseService, IUserService userService) : base(userService)
        {
            _nurseService = nurseService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateNurseDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _nurseService.Create(dto);
                }
                catch (Exception)
                {
                    return Ok(Results.AddFailResult());
                }
                return Ok(Results.AddSuccessResult());
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            var nurse = await _nurseService.Get(id);

            return View(nurse);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateNurseDto updateNurseDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _nurseService.Update(updateNurseDto);
                }
                catch (Exception)
                {
                    return Ok(Results.EditFailResult());
                }
                return Ok(Results.UpdateStatusSuccessResult());
            }

            return View(updateNurseDto);
        }

        public async Task<JsonResult> GetNurseData(Pagination pagination, Query query)
        {
            var result = await _nurseService.GetAll(pagination, query);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _nurseService.Delete(id);
            }
            catch (Exception)
            {
                return Ok(Results.DeleteFailResult());
            }
            return Ok(Results.DeleteSuccessResult());
        }
        [HttpGet]
        public async Task<IActionResult> ExportToExcel()
        {
            return File(await _nurseService.ExportToExcel(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "reportNurse.xlsx");
        }

    }
}
