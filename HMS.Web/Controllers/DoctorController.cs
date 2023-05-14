using HMS.Core.Dtos;
using HMS.Infrastructure.Services.Doctors;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Results = HMS.Core.Constants.Results;


namespace HMS.Web.Controllers
{
    public class DoctorController : BaseController
    {
        protected readonly IDoctorService _doctorService;
        public DoctorController(IUserService userService, IDoctorService doctorService) : base(userService)
        {
            _doctorService = doctorService;
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
        public async Task<IActionResult> Create([FromForm] CreateDoctorDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _doctorService.Create(dto);
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
            var nurse = await _doctorService.Get(id);

            return View(nurse);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateDoctorDto updateDoctorDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _doctorService.Update(updateDoctorDto);
                }
                catch (Exception)
                {
                    return Ok(Results.EditFailResult());
                }
                return Ok(Results.UpdateStatusSuccessResult());
            }

            return View(updateDoctorDto);
        }

        public async Task<JsonResult> GetDoctorData(Pagination pagination, Query query)
        {
            var result = await _doctorService.GetAll(pagination, query);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _doctorService.Delete(id);
            }
            catch (Exception)
            {
                return Ok(Results.DeleteFailResult());
            }
            return Ok(Results.DeleteSuccessResult());
        }

    }
}
