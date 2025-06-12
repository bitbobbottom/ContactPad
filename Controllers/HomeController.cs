using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ContactNotePad.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace ContactNotePad.Controllers;
[Authorize]
public class HomeController: Controller
{
    private readonly IUserService _userService;
    public HomeController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
    public async Task < IActionResult > Index()
        {
            var nickname = User.Identity?.Name;
            if (string.IsNullOrEmpty(nickname))
            {
                return RedirectToAction("Index", "Login");
            }
            var contacts = await _userService.GetAllContactsAsync(nickname);
            return View(contacts);
        }
        [HttpGet("details/{id:int}")]
    public async Task < IActionResult > Details(int id)
        {
            var nickname = User.Identity?.Name;
            if (string.IsNullOrEmpty(nickname))
            {
                return RedirectToAction("Index", "Login");
            }
            var user = await _userService.GetUserByNicknameAsync(nickname);
            var contact = await _userService.GetContactByIdAsync(id);
            if (contact == null || contact.UserId != user.Id)
            {
                return NotFound();
            }
            ViewBag.Nickname = nickname;
            return View(contact);
        }
        [HttpGet("Edit/{id:int}")]
    public async Task < IActionResult > Edit(int id)
        {
            var nickname = User.Identity?.Name;
            if (string.IsNullOrEmpty(nickname))
            {
                // Jeśli nie jesteśmy zalogowani, przekieruj do logowania
                return RedirectToAction("Index", "Login");
            }
            var user = await _userService.GetUserByNicknameAsync(nickname);
            if (user == null)
            {
                return Unauthorized();
            }
            var contact = await _userService.GetContactByIdAsync(id);
            if (contact == null || contact.UserId != user.Id)
            {
                return NotFound();
            }
            ViewBag.Nickname = nickname;
            return View(contact);
        }
        [HttpPost("Edit/{id:int}")]
    public async Task < IActionResult > Edit(Contact contact)
        {
            var nickname = User.Identity?.Name;
            if (string.IsNullOrEmpty(nickname))
            {
                // Jeśli nie jesteśmy zalogowani, przekieruj do logowania
                return RedirectToAction("Index", "Login");
            }
            var user = await _userService.GetUserByNicknameAsync(nickname);
            if (user == null)
            {
                return Unauthorized();
            }
            // if (!ModelState.IsValid)
            // {
            //     return View(contact);
            // }
            var existingContact = await _userService.GetContactByIdAsync(contact.Id);
            if (existingContact == null) return NotFound();
            existingContact.FirstName = contact.FirstName;
            existingContact.LastName = contact.LastName;
            existingContact.Email = contact.Email;
            existingContact.PhoneNumber = contact.PhoneNumber;
            existingContact.Address = contact.Address;
            existingContact.Description = contact.Description;
            await _userService.UpdateContactAsync(existingContact);
            return RedirectToAction("Index");
        }
        [HttpGet]
    public IActionResult Create()
    {
        // Po prostu zwracamy pusty model do formularza
        return View(new Contact());
    }
    // POST: Contacts/Create
    [HttpPost]
    [ValidateAntiForgeryToken] // zabezpieczenie przed CSRF
    public async Task <IActionResult> Create(Contact contact)
        {
            var nickname = User.Identity?.Name;
            if (string.IsNullOrEmpty(nickname))
            {
                // Jeśli nie jesteśmy zalogowani, przekieruj do logowania
                return RedirectToAction("Index", "Login");
            }
            var user = await _userService.GetUserByNicknameAsync(nickname);
            if (user == null)
            {
                return Unauthorized();
            }
                // Przypisujemy UserId kontaktowi
                contact.UserId = user.Id;
                contact.CreatedAt = DateTime.UtcNow;
                await _userService.AddContactAsync(contact);
                return RedirectToAction("Index");
            // Jeśli model jest niepoprawny, zwracamy widok z błędami
            return View(contact);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Login");
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
