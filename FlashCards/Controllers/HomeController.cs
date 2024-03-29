﻿using FlashCards.Enums;
using FlashCards.Helpers;
using FlashCards.Models;
using FlashCards.Models.FlashCards;
using FlashCards.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using System.Text.Json;

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

        public async Task<IActionResult> Index(int page = 1, int top = 25, int topic = 1, string subtopic = "")
        {
            var flashcardSides                              = await _context.FlashCardSides.ToListAsync();
            var flashcards                                  = await _context.FlashCards.ToListAsync();
            FlashCardsViewModel<FlashCardModel> viewModel   = new()
            {
                TotalRecords    = flashcards.Count,
                PageSize        = top,
                PageNumber      = page,
                Data            = flashcards
                                    .Skip((page - 1) * top)
                                    .Take(top)
                                    .FilterByTopics((Topics)topic)
                                    .FilterBySubTopics(subtopic)
                                    .ToList(),
                Filter          = new FilterViewModel(""+topic, subtopic)

            };
            ViewBag.Title = "Home";
            return View(viewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Title = "Create";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FlashCardModel flashcard)
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
            ViewBag.Title = "Edit";
            if (id == null)
            {
                return NotFound();
            }

            var flashcardSides  = await _context.FlashCardSides.ToListAsync();
            var flashcard       = await _context.FlashCards.FindAsync(id);
            if (flashcard == null)
            {
                return NotFound();
            }

            return View(flashcard);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("Id,Topics,SubTopics,Front,Back")] FlashCardModel flashcard)
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
                    if(!FlashCardExists(flashcard.Id) || FlashCardSideExists(flashcard.Front.Id))
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

        public async Task<IActionResult> FlashCard(int topic = 1, string subtopic = "Japanese")
        {
            ViewBag.Title = "View";
            var flashcardSides = await _context.FlashCardSides.ToListAsync();
            var flashcards = await _context.FlashCards.ToListAsync();

            var result = flashcards.FilterByTopics((Topics) topic).FilterBySubTopics(subtopic).ToList();
            return View(result);
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

        private bool FlashCardSideExists(int id)
        {
            return _context.FlashCardSides.Any(e => e.Id == id);
        }

        private JsonResult SubTopics(int topic, string text)
        {

            var result = Json(text, JsonSerializerOptions.Default);
            return result;
        }
    }
}