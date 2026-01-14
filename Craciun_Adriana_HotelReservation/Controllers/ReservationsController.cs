using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Craciun_Adriana_HotelReservation.Data;
using Craciun_Adriana_HotelReservation.Models;

namespace Craciun_Adriana_HotelReservation.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly Craciun_Adriana_HotelReservationContext _context;

        public ReservationsController(Craciun_Adriana_HotelReservationContext context)
        {
            _context = context;
        }

        // GET: Reservations
        public async Task<IActionResult> Index()
        {
            var craciun_Adriana_HotelReservationContext = _context.Reservation.Include(r => r.Room);
            return View(await craciun_Adriana_HotelReservationContext.ToListAsync());
        }

        // GET: Reservations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // GET: Reservations/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "Id", "Id");
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "Id", "Id");
            return View();
        }

        // POST: Reservations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId,RoomId,CheckInDate,CheckOutDate,TotalPrice,Status,SpecialRequests,MarketSegment")] Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reservation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "Id", "Id", reservation.RoomId);

            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "Id", "Id", reservation.ClientId);
            return View(reservation);
        }

        // GET: Reservations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "Id", "Id", reservation.RoomId);

            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "Id", "Id", reservation.ClientId);
            return View(reservation);
        }

        // POST: Reservations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,RoomId,CheckInDate,CheckOutDate,CreatedAt,TotalPrice,Status,SpecialRequests,MarketSegment")] Reservation reservation)
        {
            if (id != reservation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reservation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReservationExists(reservation.Id))
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
            ViewData["RoomId"] = new SelectList(_context.Set<Room>(), "Id", "Id", reservation.RoomId);
            ViewData["ClientId"] = new SelectList(_context.Set<Client>(), "Id", "Id", reservation.ClientId);
            return View(reservation);
        }

        // GET: Reservations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reservation = await _context.Reservation
                .Include(r => r.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (reservation == null)
            {
                return NotFound();
            }

            return View(reservation);
        }

        // POST: Reservations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservation.Remove(reservation);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReservationExists(int id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }
    }
}
