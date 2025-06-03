using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AvcolFacilityManager.Areas.Identity.Data;
using AvcolFacilityManager.Models;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace AvcolFacilityManager.Controllers
{
    public class ReviewsController : Controller
    {
        private readonly AvcolFacilityManagerDbContext _context;

        public ReviewsController(AvcolFacilityManagerDbContext context)
        {
            _context = context;
        }

       
        // GET: Reviews
        public async Task<IActionResult> Index()
        {
            var avcolFacilityManagerDbContext = _context.Reviews.Include(r => r.Booking).ThenInclude(b => b.Facility);
            return View(await avcolFacilityManagerDbContext.ToListAsync());
        }

        // GET: Reviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Booking)
                .ThenInclude(b => b.Facility)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: Reviews/Create
        public IActionResult Create()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  //Get the current user's id.

            //Check if the user is an admin
            if (User.IsInRole("Admin"))
            {
                //The admin is able to view all the bookings (in case the user asks them to leave the review for them)
                var allBookings = _context.Bookings.ToList();
                ViewData["BookingId"] = new SelectList(allBookings, "BookingId", "BookingId");
            }
            else
            {
                //Regular users can only see their own bookings (prevents users leaving reviews on other people's bookings).
                var userBookings = _context.Bookings.Where(b => b.AppUserId == userId).ToList();
                ViewData["BookingId"] = new SelectList(userBookings, "BookingId", "BookingId");
            }
            return View();
        }

        // POST: Reviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewId,BookingId,Rating,Comment")] Reviews reviews)
        {
            if (!ModelState.IsValid)
            {
                reviews.DateCreated = DateTime.Now;

                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", reviews.BookingId);
            return View(reviews);
        }

        // GET: Reviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", reviews.BookingId);
            return View(reviews);
        }

        // POST: Reviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewId,BookingId,Rating,Comment")] Reviews reviews)
        {
            if (id != reviews.ReviewId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.ReviewId))
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
            ViewData["BookingId"] = new SelectList(_context.Bookings, "BookingId", "BookingId", reviews.BookingId);
            return View(reviews);
        }

        // GET: Reviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Booking)
                .FirstOrDefaultAsync(m => m.ReviewId == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: Reviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews != null)
            {
                _context.Reviews.Remove(reviews);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewId == id);
        }
    }
}
