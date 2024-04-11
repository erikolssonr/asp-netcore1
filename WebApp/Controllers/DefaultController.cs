using Infrastructure.Contexts;
using Infrastructure.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using WebApp.Models;

namespace WebApp.Controllers;


public class DefaultController(DataContext context) : Controller
{
    private readonly DataContext _context = context;

    [Route("/")]
    public IActionResult Home()
    {
        return View();
    }

}
