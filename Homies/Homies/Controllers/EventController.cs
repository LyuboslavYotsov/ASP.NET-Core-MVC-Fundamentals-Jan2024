using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext _context;

        public EventController(HomiesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await _context.Events
                .AsNoTracking()
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString(DataConstants.DateFormat),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .ToListAsync();

            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var detailedEvent = await _context.Events
                .AsNoTracking()
                .Where(e => e.Id == id)
                .Select(e => new EventDetailedViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Description = e.Description,
                    Start = e.Start.ToString(DataConstants.DateFormat),
                    End = e.End.ToString(DataConstants.DateFormat),
                    CreatedOn = e.CreatedOn.ToString(DataConstants.DateFormat),
                    Organiser = e.Organiser.UserName,
                    Type = e.Type.Name
                })
                .FirstOrDefaultAsync();

            if (detailedEvent == null)
            {
                return BadRequest();
            }

            return View(detailedEvent);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new EventFormViewModel();

            model.Types = await GetEventTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventFormViewModel model)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetEventTypes();

                return View(model);
            }

            Event newEvent = new Event()
            {
                CreatedOn = DateTime.Now,
                Description = model.Description,
                Name = model.Name,
                OrganiserId = GetUserId(),
                TypeId = model.TypeId,
                Start = start,
                End = end
            };

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var currentEvent = await _context.Events.FindAsync(id);

            string userId = GetUserId();

            if (currentEvent == null)
            {
                return BadRequest();
            }

            if (currentEvent.OrganiserId != userId)
            {
                return Unauthorized();
            }

            var model = new EventFormViewModel()
            {
                Description = currentEvent.Description,
                Name = currentEvent.Name,
                End = currentEvent.End.ToString(DataConstants.DateFormat),
                Start = currentEvent.Start.ToString(DataConstants.DateFormat),
                TypeId = currentEvent.TypeId,
            };

            model.Types = await GetEventTypes();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventFormViewModel model, int id)
        {
            var currentEvent = await _context.Events.FindAsync(id);

            string userId = GetUserId();

            if (currentEvent == null)
            {
                return BadRequest();
            }

            if (currentEvent.OrganiserId != userId)
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            if (!DateTime.TryParseExact(
                model.Start,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(model.Start), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!DateTime.TryParseExact(
                model.End,
                DataConstants.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(model.End), $"Invalid date! Format must be {DataConstants.DateFormat}");
            }

            if (!ModelState.IsValid)
            {
                model.Types = await GetEventTypes();
                return View(model);
            }

            currentEvent.Start = start;
            currentEvent.End = end;
            currentEvent.Description = model.Description;
            currentEvent.Name = model.Name;
            currentEvent.TypeId = model.TypeId;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var userId = GetUserId();

            var events = await _context.EventsParticipants
                .Where(ep => ep.HelperId == userId)
                .AsNoTracking()
                .Select(ep => new EventViewModel()
                {
                    Id = ep.EventId,
                    Name = ep.Event.Name,
                    Start = ep.Event.Start.ToString(DataConstants.DateFormat),
                    Organiser = ep.Event.Organiser.UserName,
                    Type = ep.Event.Type.Name
                })
                .ToListAsync();

            return View(events);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var currentEvent = await _context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (currentEvent == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            if (!currentEvent.EventsParticipants.Any(ep => ep.HelperId == userId))
            {
                currentEvent.EventsParticipants.Add(new EventParticipant()
                {
                    EventId = currentEvent.Id,
                    HelperId = userId,
                });

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Joined));
            }

            return RedirectToAction(nameof(All));

        }

        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var currentEvent = await _context.Events
                .Where(e => e.Id == id)
                .Include(e => e.EventsParticipants)
                .FirstOrDefaultAsync();

            if (currentEvent == null)
            {
                return BadRequest();
            }

            var userId = GetUserId();

            var ep = currentEvent.EventsParticipants
                .FirstOrDefault(ep => ep.HelperId == userId);

            if (ep == null)
            {
                return BadRequest();
            }

            currentEvent.EventsParticipants.Remove(ep);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private async Task<ICollection<TypeViewModel>> GetEventTypes()
        {
            return await _context.Types
                 .AsNoTracking()
                 .Select(t => new TypeViewModel()
                 {
                     Id = t.Id,
                     Name = t.Name,
                 })
                 .ToListAsync();
        }
    }
}
