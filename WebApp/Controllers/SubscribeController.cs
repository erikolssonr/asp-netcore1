using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SubscribeController : Controller
    {
        [HttpPost]
        public IActionResult Subscribe(SubscribeForm form)
        {
            if (ModelState.IsValid)
            {

            }

            return RedirectToAction("Home", "Default");
        }
    }
}
