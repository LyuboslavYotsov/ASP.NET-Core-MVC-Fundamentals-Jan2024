using Contacts.Data;
using Contacts.Data.Models;
using Contacts.Models.Contact;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly ContactsDbContext _context;

        public ContactsController(ContactsDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> All()
        {
            var models = await _context
                .Contacts
                .AsNoTracking()
                .Select(c => new ContactViewModel()
                {
                    ContactId = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber,
                    Address = c.Address ?? string.Empty,
                    Website = c.Website
                })
                .ToListAsync();


            return View(models);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new ContactFormViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ContactFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = new Contact()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Address = model.Address,
                Website = model.Website
            };

            await _context.Contacts.AddAsync(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int contactId)
        {
            var entity = await _context.Contacts.FindAsync(contactId);

            if (entity == null)
            {
                return BadRequest();
            }

            var model = new ContactFormViewModel() 
            {
                ContactId = contactId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                Address = entity.Address,
                Website = entity.Website
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ContactFormViewModel model, int contactId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var entity = await _context.Contacts.FindAsync(model.ContactId);

            if (entity == null)
            {
                return BadRequest();
            }

            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Email = model.Email;
            entity.PhoneNumber = model.PhoneNumber;
            entity.Address = model.Address;
            entity.Website = model.Website;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> AddToTeam(int contactId)
        {
            var contact = await _context.Contacts.FindAsync(contactId);

            if (contact == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            var newUserContact = new UserContact()
            {
                UserId = userId,
                ContactId = contactId
            };

            if (await _context.UsersContacts.AnyAsync(uc => uc.ContactId == newUserContact.ContactId && uc.UserId == newUserContact.UserId))
            {
                return RedirectToAction(nameof(All));
            }

            await _context.UsersContacts.AddAsync(newUserContact);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromTeam(int contactId)
        {
            string userId = GetUserId();

            var contact = await _context.Contacts.FindAsync(contactId);

            if(contact == null)
            {
                return BadRequest();
            }

            var entity = new UserContact()
            {
                UserId = userId,
                ContactId = contactId
            };

            if (!await _context.UsersContacts.ContainsAsync(entity))
            {
                return BadRequest();
            }

            _context.UsersContacts.Remove(entity);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Team));
        }

        [HttpGet]
        public async Task<IActionResult> Team()
        {
            string userId = GetUserId();

            var models = await _context
                .UsersContacts
                .AsNoTracking()
                .Where(uc => uc.UserId == userId)
                .Select(uc => new ContactViewModel()
                {
                    ContactId = uc.Contact.Id,
                    FirstName = uc.Contact.FirstName,
                    LastName = uc.Contact.LastName,
                    Email = uc.Contact.Email,
                    PhoneNumber = uc.Contact.PhoneNumber,
                    Address = uc.Contact.Address ?? string.Empty,
                    Website = uc.Contact.Website
                })
                .ToListAsync();


            return View(models);
        }

        private string GetUserId()
        {
            return User.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}
