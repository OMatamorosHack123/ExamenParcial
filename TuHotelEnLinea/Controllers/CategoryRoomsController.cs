using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class CategoryRoomsController : Controller
    {
        private readonly TuHotelEnLineaContext _context;

        public CategoryRoomsController(TuHotelEnLineaContext context)
        {
            _context = context;
        }

        // GET: CategoryRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryRoom.ToListAsync());
        }

        // GET: CategoryRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CategoryRoom == null)
            {
                return NotFound();
            }

            var categoryRoom = await _context.CategoryRoom
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

            _context.Add(categoryRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: CategoryRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CategoryRoom == null)
            {
                return NotFound();
            }

            var categoryRoom = await _context.CategoryRoom.FindAsync(id);
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

        // GET: CategoryRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CategoryRoom == null)
            {
                return NotFound();
            }

            var categoryRoom = await _context.CategoryRoom
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
            if (_context.CategoryRoom == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.CategoryRoom'  is null.");
            }
            var categoryRoom = await _context.CategoryRoom.FindAsync(id);
            if (categoryRoom != null)
            {
                _context.CategoryRoom.Remove(categoryRoom);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryRoomExists(int id)
        {
            return _context.CategoryRoom.Any(e => e.CategoryRoomId == id);
        }
    }
}
