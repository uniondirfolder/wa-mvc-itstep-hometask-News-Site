using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wa_mvc_itstep_hometask_News_Site.Models;
using wa_mvc_itstep_hometask_News_Site.Models.Entities;
using wa_mvc_itstep_hometask_News_Site.Models.Helpers;
using wa_mvc_itstep_hometask_News_Site.Models.ViewModels;
using wa_mvc_itstep_hometask_News_Site.Services.Parsing;
using wa_mvc_itstep_hometask_News_Site.Services.Rss;
using wa_mvc_itstep_hometask_News_Site.Utils.Currency;

namespace wa_mvc_itstep_hometask_News_Site.Controllers
{
    public class NewsController : Controller
    {
        #region Fields
        private readonly CurrencyCBER _currencyCBER;

        private readonly EvilInfoParsing _evilInfoParsing;

        private readonly EvilInfoRss _evilInfoRss;

        private readonly IMapper _mapper;

        private readonly ApplicationContext _context;

        public NewsController(CurrencyCBER currencyCBER, EvilInfoParsing evilInfoParsing, EvilInfoRss evilInfoRss, IMapper mapper, ApplicationContext context)
        {
            _currencyCBER = currencyCBER;
            _evilInfoParsing = evilInfoParsing;
            _evilInfoRss = evilInfoRss;
            _mapper = mapper;
            _context = context;
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Index(string url = "/news", string category = "Все новости")
        {
            List<News> news = await _evilInfoRss.GetNewsAsync(url);

            List<CurrencyItem> currencyItems = await _currencyCBER.GetCurrenciesAsync();

            List<CurrencyItem> topCurrencies = currencyItems.Where(c => c.CharCode == "USD" || c.CharCode == "EUR").ToList();

            currencyItems.RemoveAll(c => c.CharCode == "USD" || c.CharCode == "EUR");

            NewsCurrenciesVM newsCurrenciesVM = new()
            {
                News = news,
                CurrencyItems = currencyItems,
                TopCurrencies = topCurrencies
            };

            ViewBag.Category = category;

            return View(newsCurrenciesVM);
        }

        [HttpGet]
        public async Task<IActionResult> OneNews(OneNews oneNews)
        {
            OneNewsVM oneNewsVM = await _evilInfoParsing.GetOneNews(oneNews, _mapper);

            return View(oneNewsVM);
        }

        [HttpPost]
        public async Task<IActionResult> SaveOneNews(OneNews oneNews)
        {
            if (!User.Identity.IsAuthenticated) return BadRequest(new { Message = "Authenticated!" });

            if (ModelState.IsValid)
            {
                User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

                SavedNews savedNews = _mapper.Map<SavedNews>(oneNews);

                savedNews.User = user;

                savedNews.UserId = user.Id;

                SavedNews exsistedSavedNews = await _context.SavedNews.FirstOrDefaultAsync(n => n.Title == oneNews.Title && n.UserId == user.Id);

                if (exsistedSavedNews == null)
                {
                    await _context.SavedNews.AddAsync(savedNews);

                    await _context.SaveChangesAsync();

                    return Ok(new { Message = "Saved!" });
                }
                else
                {
                    return BadRequest(new { Message = "Exists!" });
                }
            }

            return BadRequest(new { Message = "Error!" });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SavedNews()
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);

            List<SavedNews> savedNews = _context.SavedNews.Where(s => s.UserId == user.Id).ToList();

            savedNews.Sort((x, y) => y.Id.CompareTo(x.Id));

            return View(savedNews);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteOneNews(int id)
        {
            if (!User.Identity.IsAuthenticated) return BadRequest();

            SavedNews savedNews = await _context.SavedNews.FirstOrDefaultAsync(n => n.Id == id);

            if (savedNews == null)
            {
                return BadRequest();
            }

            _context.SavedNews.Remove(savedNews);

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
