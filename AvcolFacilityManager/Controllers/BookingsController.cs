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
    public class BookingsController : Controller
    {
        private readonly AvcolFacilityManagerDbContext _context;

        public BookingsController(AvcolFacilityManagerDbContext context)
        {
            _context = context;
        }

        [Authorize]
        // GET: Bookings
        public async Task<IActionResult> Index(string searchString, int? pageNumber, string currentFilter, string sortOrder)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["DateSortParm"] = string.IsNullOrEmpty(sortOrder) ? "date_desc" : "";

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            IQueryable<Bookings> bookingsQuery = _context.Bookings
                .Include(b => b.AppUser)
                .Include(b => b.Facility);

            if (!User.IsInRole("Admin"))
            {
                //Filter bookings for non-admin users to only see their own bookings
                bookingsQuery = bookingsQuery.Where(b => b.AppUserId == userId);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                bookingsQuery = bookingsQuery.Where(b =>
                    b.Facility.FacilityName.Contains(searchString) ||
                    b.AppUser.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "date_desc":
                    bookingsQuery = bookingsQuery.OrderByDescending(s => s.Date);
                    break;
                default:
                    bookingsQuery = bookingsQuery.OrderBy(s => s.Date);
                    break;
            }
            int pageSize = 10;
            
            return View(await PaginatedList<Bookings>.CreateAsync(bookingsQuery.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.AppUser)
                .Include(b => b.Facility)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // GET: Bookings/Create
        public IActionResult Create()
        {
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "FirstName");
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,AppUserId,FacilityId,Date,StartTime,EndTime")] Bookings bookings)
        {
            if (!User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  //Get current user id.
                bookings.AppUserId = userId;  //Automatically assign current user id to the booking.
            }
            // Server-side validation: StartTime must be before EndTime
            if (bookings.StartTime >= bookings.EndTime)
            {
                ModelState.AddModelError("EndTime", "End Time must be after Start Time.");
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                _context.Add(bookings);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "FirstName", bookings.AppUserId);
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName", bookings.FacilityId);
            return View(bookings);
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings == null)
            {
                return NotFound();
            }
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "FirstName", bookings.AppUserId);
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName", bookings.FacilityId);
            return View(bookings);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,AppUserId,FacilityId,Date,StartTime,EndTime")] Bookings bookings)
        {
            if (id != bookings.BookingId)
            {
                return NotFound();
            }

            //Ensures that when the user edits a booking, the id is preserved in the AppUserId field so a NULL is not returned (since the AppUserId is hidden and will have no input otherwise).
            if (!User.IsInRole("Admin"))
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);  //Get current user id.
                bookings.AppUserId = userId;  //Automatically assign current user id to the booking.
            }

            if (bookings.StartTime >= bookings.EndTime)
            {
                ModelState.AddModelError("EndTime", "End Time must be after Start Time.");
                return RedirectToAction(nameof(Index));
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookings);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingsExists(bookings.BookingId))
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
            ViewData["AppUserId"] = new SelectList(_context.AppUser, "Id", "FirstName", bookings.AppUserId);
            ViewData["FacilityId"] = new SelectList(_context.Facility, "FacilityId", "FacilityName", bookings.FacilityId);
            return View(bookings);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookings = await _context.Bookings
                .Include(b => b.AppUser)
                .Include(b => b.Facility)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (bookings == null)
            {
                return NotFound();
            }

            return View(bookings);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookings = await _context.Bookings.FindAsync(id);
            if (bookings != null)
            {
                _context.Bookings.Remove(bookings);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingsExists(int id)
        {
            return _context.Bookings.Any(e => e.BookingId == id);
        }
    }
}
