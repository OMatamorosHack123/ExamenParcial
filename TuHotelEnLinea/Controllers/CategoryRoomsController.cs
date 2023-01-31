using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class CategoryRoomsController : Controller
    {
        private readonly HotelEnLineaContext _context;

        public CategoryRoomsController(HotelEnLineaContext context)
        {
            _context = context;
        }

        // GET: CategoryRooms
        public async Task<IActionResult> Index()
        {
              return View(await _context.CategoryRooms.ToListAsync());
        }

        // GET: CategoryRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoryRooms == null)
            {
                return NotFound();
            }

            var categoryRoom = await _context.CategoryRooms
                .FirstOrDefaultAsync(m => m.CategoryRoomId == id);
            if (categoryRoom == null)
            {
                return NotFound();
            }

            return View(categoryRoom);
        }

        // GET: CategoryRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryRoomId,CategoryRoomName,CategoryRoomDescription")] CategoryRoom categoryRoom)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryRoom);
        }

        // GET: CategoryRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoryRooms == null)
            {
                return NotFound();
            }

            var categoryRoom = await _context.CategoryRooms.FindAsync(id);
            if (categoryRoom == null)
            {
                return NotFound();
            }
            return View(categoryRoom);
        }

        // POST: CategoryRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryRoomId,CategoryRoomName,CategoryRoomDescription")] CategoryRoom categoryRoom)
        {
            if (id != categoryRoom.CategoryRoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryRoomExists(categoryRoom.CategoryRoomId))
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
            return View(categoryRoom);
        }

        // GET: CategoryRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoryRooms == null)
            {
                return NotFound();
            }

            var categoryRoom = await _context.CategoryRooms
                .FirstOrDefaultAsync(m => m.CategoryRoomId == id);
            if (categoryRoom == null)
            {
                return NotFound();
            }

            return View(categoryRoom);
        }

        // POST: CategoryRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CategoryRooms == null)
            {
                return Problem("Entity set 'HotelEnLineaContext.CategoryRooms'  is null.");
            }
            var categoryRoom = await _context.CategoryRooms.FindAsync(id);
            if (categoryRoom != null)
            {
                _context.CategoryRooms.Remove(categoryRoom);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryRoomExists(int id)
        {
          return _context.CategoryRooms.Any(e => e.CategoryRoomId == id);
        }
    }
}
