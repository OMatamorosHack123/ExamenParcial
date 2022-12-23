using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class CustomerXRoomsController : Controller
    {
        private readonly TuHotelEnLineaContext _context;

        public CustomerXRoomsController(TuHotelEnLineaContext context)
        {
            _context = context;
        }

        // GET: CustomerXRooms
        public async Task<IActionResult> Index()
        {
            var tuHotelEnLineaContext = _context.CustomerXRoom.Include(c => c.Customer).Include(c => c.Room);
            return View(await tuHotelEnLineaContext.ToListAsync());
        }

        // GET: CustomerXRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CustomerXRoom == null)
            {
                return NotFound();
            }

            var customerXRoom = await _context.CustomerXRoom
                .Include(c => c.Customer)
                .Include(c => c.Room)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerXRoom == null)
            {
                return NotFound();
            }

            return View(customerXRoom);
        }

        // GET: CustomerXRooms/Create
        public IActionResult Create()
        {
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerIdCard");
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return View();
        }

        // POST: CustomerXRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerId,RoomId,CustomerCreatedAt")] CustomerXRoom customerXRoom)
        {

                _context.Add(customerXRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerIdCard", customerXRoom.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", customerXRoom.RoomId);
            return View(customerXRoom);
        }

        // GET: CustomerXRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CustomerXRoom == null)
            {
                return NotFound();
            }

            var customerXRoom = await _context.CustomerXRoom.FindAsync(id);
            if (customerXRoom == null)
            {
                return NotFound();
            }
            ViewData["CustomerId"] = new SelectList(_context.Customer, "CustomerId", "CustomerIdCard", customerXRoom.CustomerId);
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", customerXRoom.RoomId);
            return View(customerXRoom);
        }

        // POST: CustomerXRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerId,RoomId,CustomerCreatedAt")] CustomerXRoom customerXRoom)
        {
            if (id != customerXRoom.CustomerId)
            {
                return NotFound();
            }

                try
                {
                    _context.Update(customerXRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerXRoomExists(customerXRoom.CustomerId))
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



        // GET: CustomerXRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CustomerXRoom == null)
            {
                return NotFound();
            }

            var customerXRoom = await _context.CustomerXRoom
                .Include(c => c.Customer)
                .Include(c => c.Room)
                .FirstOrDefaultAsync(m => m.CustomerId == id);
            if (customerXRoom == null)
            {
                return NotFound();
            }

            return View(customerXRoom);
        }

        // POST: CustomerXRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CustomerXRoom == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.CustomerXRoom'  is null.");
            }
            var customerXRoom = await _context.CustomerXRoom.FindAsync(id);
            if (customerXRoom != null)
            {
                _context.CustomerXRoom.Remove(customerXRoom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerXRoomExists(int id)
        {
          return _context.CustomerXRoom.Any(e => e.CustomerId == id);
        }
    }
}
