using HMS.Core.Dtos;
using HMS.Core.ViewModels;
using HMS.Infrastructure.Services.Users;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) { 
            _userService = userService;
        }
        public IActionResult Index()
        {
            
            return View(_userService.GetAll());
        }

        [HttpGet]
        public IActionResult Create() {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm]CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                await _userService.Create(createUserDto);
                return RedirectToAction("Index");
            }

            return View(createUserDto);
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
