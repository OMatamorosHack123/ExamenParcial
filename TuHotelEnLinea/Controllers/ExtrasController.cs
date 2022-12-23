using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TuHotelEnLinea.Data;
using TuHotelEnLinea.Models;

namespace TuHotelEnLinea.Controllers
{
    public class ExtrasController : Controller
    {
        private readonly TuHotelEnLineaContext _context;

        public ExtrasController(TuHotelEnLineaContext context)
        {
            _context = context;
        }

        // GET: Extras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Extra.ToListAsync());
        }

        // GET: Extras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _context.Extra
                .FirstOrDefaultAsync(m => m.ExtraId == id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // GET: Extras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Extras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExtraId,ExtraName,ExtraDescription")] Extra extra)
        {

            _context.Add(extra);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Extras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _context.Extra.FindAsync(id);
            if (extra == null)
            {
                return NotFound();
            }
            return View(extra);
        }

        // POST: Extras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ExtraId,ExtraName,ExtraDescription")] Extra extra)
        {
            if (id != extra.ExtraId)
            {
                return NotFound();
            }


            try
            {
                _context.Update(extra);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExtraExists(extra.ExtraId))
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

        // GET: Extras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Extra == null)
            {
                return NotFound();
            }

            var extra = await _context.Extra
                .FirstOrDefaultAsync(m => m.ExtraId == id);
            if (extra == null)
            {
                return NotFound();
            }

            return View(extra);
        }

        // POST: Extras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Extra == null)
            {
                return Problem("Entity set 'TuHotelEnLineaContext.Extra'  is null.");
            }
            var extra = await _context.Extra.FindAsync(id);
            if (extra != null)
            {
                _context.Extra.Remove(extra);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExtraExists(int id)
        {
            return _context.Extra.Any(e => e.ExtraId == id);
        }
    }
}
