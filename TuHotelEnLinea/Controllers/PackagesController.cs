using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class PackagesController : Controller
    {
        private readonly TuHotelEnLineaContext _context;

        public PackagesController(TuHotelEnLineaContext context)
        {
            _context = context;
        }

        // GET: Packages
        public async Task<IActionResult> Index()
        {
            var tuHotelEnLineaContext = _context.Package.Include(p => p.Room);
            return View(await tuHotelEnLineaContext.ToListAsync());
        }

        // GET: Packages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Package == null)
            {
                return NotFound();
            }

            var package = await _context.Package
                .Include(p => p.Room)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // GET: Packages/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId");
            return View();
        }

        // POST: Packages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,RoomId,PackageName,PackagePrice,PackageQdays")] Package package)
        {

            _context.Add(package);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Packages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Package == null)
            {
                return NotFound();
            }

            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.Room, "RoomId", "RoomId", package.RoomId);
            return View(package);
        }

        // POST: Packages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageId,RoomId,PackageName,PackagePrice,PackageQdays")] Package package)
        {
            if (id != package.PackageId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(package);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(package.PackageId))
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

        // GET: Packages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Package == null)
            {
                return NotFound();
            }

            var package = await _context.Package
                .Include(p => p.Room)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (package == null)
            {
                return NotFound();
            }

            return View(package);
        }

        // POST: Packages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Package == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Package'  is null.");
            }
            var package = await _context.Package.FindAsync(id);
            if (package != null)
            {
                _context.Package.Remove(package);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExists(int id)
        {
            return _context.Package.Any(e => e.PackageId == id);
        }
    }
}
