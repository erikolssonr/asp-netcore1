using Infrastructure.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Contexts;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController(ApiContext context) : ControllerBase
    {
        private readonly ApiContext _context = context;

        [HttpPost]
        public async Task<IActionResult> Create(SubscribeForm form)
        {
            if (ModelState.IsValid)
            {

                if (!await _context.Subscribers.AnyAsync(x => x.Email == form.Email))
                {
                    var entity = new SubscriberEntity()
                    {
                        Email = form.Email,
                        DailyNewsletter = form.DailyNewsletter,
                        AdvertisingUpdates = form.AdvertisingUpdates,
                        WeekInReview = form.WeekInReview,
                        EventUpdates = form.EventUpdates,
                        StartupsWeekly = form.StartupsWeekly,
                        Podcasts = form.Podcasts
                    };

                    _context.Subscribers.Add(entity);
                    await _context.SaveChangesAsync();
                    return Created("", null);
                }
                return Conflict();
            }
            return BadRequest();
        }
    }
}
