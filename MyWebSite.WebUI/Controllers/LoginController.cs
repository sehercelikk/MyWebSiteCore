using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebSite.Entities.Concrete;
using MyWebSite.WebUI.Models;

namespace MyWebSite.WebUI.Controllers;

public class LoginController : Controller
{
    private readonly SignInManager<Admin> _signInManager;

    public LoginController(SignInManager<Admin> signInManager)
    {
        _signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var result = _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
        if (result.Result.Succeeded)
        {
            return RedirectToAction("Index", "Admin");
        }
        ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Login");
    }


    public async Task<IActionResult> AccessDenied() // Yetkisiz erişim sayfası
    {
        return View();
    }
}
