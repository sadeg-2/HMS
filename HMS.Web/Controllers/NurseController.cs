using HMS.Core.Constants;
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
        protected IUserService _userService;
        public NurseController(INurseService nurseService, IUserService userService):base(userService) {
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
        public async Task<IActionResult> Update([FromForm] UpdateNurseDto updateUserDto)
        {
            if (ModelState.IsValid)
            {
                await _nurseService.Update(updateUserDto);
                return Ok(Results.UpdateStatusSuccessResult());
            }

            return View(updateUserDto);
        }

        public async Task<JsonResult> GetNurseData(Pagination pagination, Query query)
        {
            var result = await _nurseService.GetAll(pagination, query);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _nurseService.Delete(id);
            return Ok(Results.DeleteSuccessResult());
        }


    }
}
