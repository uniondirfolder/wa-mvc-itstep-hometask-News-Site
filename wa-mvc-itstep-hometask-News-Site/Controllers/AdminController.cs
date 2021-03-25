using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wa_mvc_itstep_hometask_News_Site.Models;
using wa_mvc_itstep_hometask_News_Site.Models.Entities;
using wa_mvc_itstep_hometask_News_Site.Models.ViewModels;

namespace wa_mvc_itstep_hometask_News_Site.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        #region Fields
        private readonly ApplicationContext _context;

        private readonly IMapper _mapper;
        public AdminController(ApplicationContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        #endregion

        [HttpGet]
        public IActionResult Index()
        {
            List<User> users = _context.Users.ToList();

            List<UserAdminVM> usersAdminViewModel = _mapper.Map<List<UserAdminVM>>(users);

            return View(usersAdminViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> LockUser(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                user.IsLocked = true;

                _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> UnlockUser(int id)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

            if (user != null)
            {
                user.IsLocked = false;

                _context.Users.Update(user);

                await _context.SaveChangesAsync();

                return Ok();
            }

            return BadRequest();
        }
    }
}
