using HMS.Core.Dtos;
using HMS.Core.ViewModels;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;
using Result = HMS.Core.Constants.Results;

namespace HMS.Web.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IUserService userService) : base(userService) { }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }
        public async Task<JsonResult> GetUserData(Pagination pagination, Query query)
        {
            var result = await _userService.GetAll(pagination, query);
            return Json(result);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Create(createUserDto);
                return Ok(Result.AddSuccessResult());
            }

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Update(string id)
        {
            var user = await _userService.Get(id);

            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromForm] UpdateUserDto updateUserDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Update(updateUserDto);
                return Ok(Result.UpdateStatusSuccessResult());
            }

            return View(updateUserDto);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.Get(id);

            return View(user);
        }
    }
}
