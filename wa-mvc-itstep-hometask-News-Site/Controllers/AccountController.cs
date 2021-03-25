using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using wa_mvc_itstep_hometask_News_Site.Models;
using wa_mvc_itstep_hometask_News_Site.Models.Entities;
using wa_mvc_itstep_hometask_News_Site.Models.ViewModels;
using wa_mvc_itstep_hometask_News_Site.Services.Security;
using wa_mvc_itstep_hometask_News_Site.Services.Validation;

namespace wa_mvc_itstep_hometask_News_Site.Controllers
{
    public class AccountController : Controller
    {
        #region Fields
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;

        private readonly ValidationService _validationService;

        public AccountController(ApplicationContext context, IMapper mapper, ValidationService validationService)
        {
            _context = context;
            _mapper = mapper;
            _validationService = validationService;
        }
        #endregion

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "News");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid && !User.Identity.IsAuthenticated)
            {
                if (!_validationService.IsEmailValid(model.Email))
                {
                    ModelState.AddModelError("Invalid email", "Incorrect email");

                    return View(model);
                }

                if (!_validationService.IsPasswordValid(model.Password))
                {
                    ModelState.AddModelError("Invalid password", "The password must consist of the Latin alphabet");

                    return View(model);
                }

                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                Role role = await _context.Roles.FirstOrDefaultAsync(u => u.Name == "user");

                if (user == null)
                {
                    string encryptedPassword = Cryptography.EncryptPassword(model.Password);

                    user = _mapper.Map<User>(model);

                    user.Password = encryptedPassword;

                    user.RoleId = role.Id;

                    user.Role = role;

                    await _context.Users.AddAsync(user);

                    int resultOfSave = await _context.SaveChangesAsync();

                    if (resultOfSave > 0)
                    {
                        await Authenticate(user, model.RememberMe);

                        return RedirectToAction("Index", "News");
                    }
                    else
                    {
                        ModelState.AddModelError("Error adding to DB", "Error with a DB, try again later");
                    }

                }
                else
                {
                    ModelState.AddModelError("Email already registered", "Email already registered");
                }
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "News");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid && !User.Identity.IsAuthenticated)
            {
                string encryptedPassword = Cryptography.EncryptPassword(model.Password);

                User user = await _context.Users
                    .Include(e => e.Role)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(e => e.Email == model.Email && e.Password == encryptedPassword);

                if (user != null && !user.IsLocked)
                {
                    await Authenticate(user, model.RememberMe);

                    return RedirectToAction("Index", "News");
                }
                else if (user != null && user.IsLocked)
                {
                    ModelState.AddModelError("User is locked", "Ваш аккаунт заблокирован");
                }
                else
                {
                    ModelState.AddModelError("User not found", "Неверный email или пароль");
                }
            }

            return View(model);
        }

        private async Task Authenticate(User user, bool rememberMe)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
            };

            ClaimsIdentity id = new(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            int days = rememberMe ? 14 : 1;

            AuthenticationProperties authenticationProperties = new()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(days)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id), authenticationProperties);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SignOutThis()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "News");
        }
    }
}
