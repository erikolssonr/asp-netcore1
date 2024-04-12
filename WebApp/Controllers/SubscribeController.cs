using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace WebApp.Controllers
{
    public class SubscribeController(HttpClient http) : Controller
    {

        private readonly HttpClient _http = http;

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeForm form)
        {
            if (ModelState.IsValid)
            {
                var content = new StringContent(JsonConvert.SerializeObject(form), Encoding.UTF8, "application/json");
                var response = await _http.PostAsync("https://localhost:7083/api/Subscribe", content);
                if (response.IsSuccessStatusCode)
                {
                    TempData["Status"] = "Your are now subscribed!";
                    return RedirectToAction("Home", "Default", "subscribe");
                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
                {
                    TempData["Status"] = "Your are already subscribed!";
                    return RedirectToAction("Home", "Default", "subscribe");
                }
            }
            TempData["Status"] = "Something went wrong.";
            return RedirectToAction("Home", "Default", "subscribe");
        }
    }
}
