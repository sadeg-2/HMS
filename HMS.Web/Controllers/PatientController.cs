using HMS.Core.Dtos;
using HMS.Infrastructure.Services.Patients;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;

using Results = HMS.Core.Constants.Results;


namespace HMS.Web.Controllers
{
    public class PatientController : BaseController
    {
        protected readonly IPatientService _patientService;
        public PatientController(IUserService userService, IPatientService patientService) : base(userService)
        {
            _patientService = patientService;
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
        public async Task<IActionResult> Create([FromForm] CreatePatientDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientService.Create(dto);
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
            var nurse = await _patientService.Get(id);

            return View(nurse);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdatePatientDto updateNurseDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _patientService.Update(updateNurseDto);
                }
                catch (Exception)
                {
                    return Ok(Results.EditFailResult());
                }
                return Ok(Results.UpdateStatusSuccessResult());
            }

            return View(updateNurseDto);
        }

        public async Task<JsonResult> GetPatientData(Pagination pagination, Query query)
        {
            var result = await _patientService.GetAll(pagination, query);
            return Json(result);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _patientService.Delete(id);
            }
            catch (Exception)
            {
                return Ok(Results.DeleteFailResult());
            }
            return Ok(Results.DeleteSuccessResult());
        }
    }
}
