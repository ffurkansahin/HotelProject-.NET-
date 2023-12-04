using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Setting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    public class SettingsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SettingsController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.FindByNameAsync(User.Identity?.Name);
            UserEditViewModel userViewModel = new UserEditViewModel();
            userViewModel.Name = user.Name;
            userViewModel.Surname = user.Surname;
            userViewModel.Username = user.UserName;
            userViewModel.Email = user.Email;
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel userEditViewModel) 
        {
            if (userEditViewModel.ConfirmPassword == userEditViewModel.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity?.Name);
                user.Name = userEditViewModel.Name;
                user.Surname = userEditViewModel.Surname;
                user.Email = userEditViewModel?.Email;
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditViewModel?.ConfirmPassword);
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }
    }
}
