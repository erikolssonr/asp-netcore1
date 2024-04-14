using Infrastructure.Entities;
using Infrastructure.Factories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class AuthController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager) : Controller
{
    private readonly UserManager<UserEntity> _userManager = userManager;
    private readonly SignInManager<UserEntity> _signInManager = signInManager;
    

    #region SignUp
    [HttpGet]
    [Route("/signup")]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    [Route("/signup")]
    public async Task<IActionResult> SignUp(SignUpViewModel form)
    {
        if (ModelState.IsValid)
        {
            if ((await _userManager.CreateAsync(UserFactory.Create(form), form.Password)).Succeeded)
            {
                if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, false, false)).Succeeded)
                {
                    return RedirectToAction("Details", "Account");
                }
            }
            else
            {
                ViewData["StatusMessage"] = "User already exists";
            }
        }

        return View(form);
    }

    #endregion

    #region SignIn


    [HttpGet]
    [Route("/signin")]
    public IActionResult SignIn(string returnUrl)
    {
        ViewData["ReturnUrl"] = returnUrl ?? "/";
        return View();
    }

    [HttpPost]
    [Route("/signin")]
    public async Task<IActionResult> SignIn(SignInViewModel form)
    {
        if (ModelState.IsValid)
        {
            if ((await _signInManager.PasswordSignInAsync(form.Email, form.Password, form.IsPresistent, false)).Succeeded)
            {
                return RedirectToAction("Home", "Default");
            }
        }

        ViewData["StatusMessage"] = "Incorrect e-mail och password";
        return View(form);
    }

    #endregion

    #region SignOut

    [HttpGet]

    [HttpGet]
    [Route("/signout")]
    public new async Task<IActionResult> SignOut()
    {
        Response.Cookies.Delete("AccessToken");
        await _signInManager.SignOutAsync();
        return LocalRedirect("/");
    }

    #endregion
}
