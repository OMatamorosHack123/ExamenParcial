using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class PackageExtrasController : Controller
    {
        private readonly TuHotelEnLineaContext _context;

        public PackageExtrasController(TuHotelEnLineaContext context)
        {
            _context = context;
        }

        // GET: PackageExtras
        public async Task<IActionResult> Index()
        {
            var tuHotelEnLineaContext = _context.PackageExtra.Include(p => p.Extra).Include(p => p.Package);
            return View(await tuHotelEnLineaContext.ToListAsync());
        }

        // GET: PackageExtras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PackageExtra == null)
            {
                return NotFound();
            }

            var packageExtra = await _context.PackageExtra
                .Include(p => p.Extra)
                .Include(p => p.Package)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (packageExtra == null)
            {
                return NotFound();
            }

            return View(packageExtra);
        }

        // GET: PackageExtras/Create
        public IActionResult Create()
        {
            ViewData["ExtraId"] = new SelectList(_context.Extra, "ExtraId", "ExtraDescription");
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "PackageName");
            return View();
        }

        // POST: PackageExtras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PackageId,ExtraId")] PackageExtra packageExtra)
        {

            _context.Add(packageExtra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: PackageExtras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PackageExtra == null)
            {
                return NotFound();
            }

            var packageExtra = await _context.PackageExtra.FindAsync(id);
            if (packageExtra == null)
            {
                return NotFound();
            }
            ViewData["ExtraId"] = new SelectList(_context.Extra, "ExtraId", "ExtraDescription", packageExtra.ExtraId);
            ViewData["PackageId"] = new SelectList(_context.Package, "PackageId", "PackageName", packageExtra.PackageId);
            return View(packageExtra);
        }

        // POST: PackageExtras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PackageId,ExtraId")] PackageExtra packageExtra)
        {
            if (id != packageExtra.PackageId)
            {
                return NotFound();
            }

            try
            {
                _context.Update(packageExtra);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExtraExists(packageExtra.PackageId))
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

        // GET: PackageExtras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PackageExtra == null)
            {
                return NotFound();
            }

            var packageExtra = await _context.PackageExtra
                .Include(p => p.Extra)
                .Include(p => p.Package)
                .FirstOrDefaultAsync(m => m.PackageId == id);
            if (packageExtra == null)
            {
                return NotFound();
            }

            return View(packageExtra);
        }

        // POST: PackageExtras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PackageExtra == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.PackageExtra'  is null.");
            }
            var packageExtra = await _context.PackageExtra.FindAsync(id);
            if (packageExtra != null)
            {
                _context.PackageExtra.Remove(packageExtra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PackageExtraExists(int id)
        {
            return _context.PackageExtra.Any(e => e.PackageId == id);
        }
    }
}
