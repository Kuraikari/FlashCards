using FlashCards.Enums;
using FlashCards.Models;
using FlashCards.Models.FlashCards;
using FlashCards.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace FlashCards.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SettingsModel _settings;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, IOptions<SettingsModel> settings, ApplicationDbContext context)
        {
            _logger = logger;
            _settings = settings.Value;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var flashcards = await _context.FlashCards.ToListAsync();
            return View(flashcards);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Topics,Front,Back")] FlashCardModel flashcard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(flashcard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(flashcard);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var flashcard = await _context.FlashCards.FindAsync(id);
            if (flashcard == null)
            {
                return NotFound();
            }

            return View(flashcard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Topics,Front,Back")] FlashCardModel flashcard)
        {
            if (id != flashcard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.FlashCards.Update(flashcard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!FlashCardExists(flashcard.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(flashcard);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> FlashCard()
        {
            var flashcards = _context.FlashCards.Where(x => x.Topics == Topics.Language).ToList();
            return View(flashcards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool FlashCardExists(int id)
        {
            return _context.FlashCards.Any(e => e.Id == id);
        }
    }
}