using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CRUDInventoryQuick.Datos;
using CRUDInventoryQuick.Models;

namespace CRUDInventoryQuick.Controllers
{
    public class AspNetUserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AspNetUserRolesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: AspNetUserRoles
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ASPNETUSERROLEs.Include(a => a.ASPNETROLES_ASPNETROLES).Include(a => a.ASPNETUSER_ASPNETUSER);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: AspNetUserRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ASPNETUSERROLEs == null)
            {
                return NotFound();
            }

            var aSPNETUSERROLES = await _context.ASPNETUSERROLEs
                .Include(a => a.ASPNETROLES_ASPNETROLES)
                .Include(a => a.ASPNETUSER_ASPNETUSER)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aSPNETUSERROLES == null)
            {
                return NotFound();
            }

            return View(aSPNETUSERROLES);
        }

        // GET: AspNetUserRoles/Create
        public IActionResult Create()
        {
            ViewData["RoleId"] = new SelectList(_context.ASPNETROLEs, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.ASPNETUSERs, "Id", "Id");
            return View();
        }

        // POST: AspNetUserRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoleId,UserId")] ASPNETUSERROLES aSPNETUSERROLES)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aSPNETUSERROLES);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoleId"] = new SelectList(_context.ASPNETROLEs, "Id", "Id", aSPNETUSERROLES.RoleId);
            ViewData["UserId"] = new SelectList(_context.ASPNETUSERs, "Id", "Id", aSPNETUSERROLES.UserId);
            return View(aSPNETUSERROLES);
        }

        // GET: AspNetUserRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ASPNETUSERROLEs == null)
            {
                return NotFound();
            }

            var aSPNETUSERROLES = await _context.ASPNETUSERROLEs.FindAsync(id);
            if (aSPNETUSERROLES == null)
            {
                return NotFound();
            }
            ViewData["RoleId"] = new SelectList(_context.ASPNETROLEs, "Id", "Id", aSPNETUSERROLES.RoleId);
            ViewData["UserId"] = new SelectList(_context.ASPNETUSERs, "Id", "Id", aSPNETUSERROLES.UserId);
            return View(aSPNETUSERROLES);
        }

        // POST: AspNetUserRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RoleId,UserId")] ASPNETUSERROLES aSPNETUSERROLES)
        {
            if (id != aSPNETUSERROLES.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aSPNETUSERROLES);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ASPNETUSERROLESExists(aSPNETUSERROLES.Id))
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
            ViewData["RoleId"] = new SelectList(_context.ASPNETROLEs, "Id", "Id", aSPNETUSERROLES.RoleId);
            ViewData["UserId"] = new SelectList(_context.ASPNETUSERs, "Id", "Id", aSPNETUSERROLES.UserId);
            return View(aSPNETUSERROLES);
        }

        // GET: AspNetUserRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ASPNETUSERROLEs == null)
            {
                return NotFound();
            }

            var aSPNETUSERROLES = await _context.ASPNETUSERROLEs
                .Include(a => a.ASPNETROLES_ASPNETROLES)
                .Include(a => a.ASPNETUSER_ASPNETUSER)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aSPNETUSERROLES == null)
            {
                return NotFound();
            }

            return View(aSPNETUSERROLES);
        }

        // POST: AspNetUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ASPNETUSERROLEs == null)
            {
                return Problem("Entity set 'ApplicationDbContext.ASPNETUSERROLEs'  is null.");
            }
            var aSPNETUSERROLES = await _context.ASPNETUSERROLEs.FindAsync(id);
            if (aSPNETUSERROLES != null)
            {
                _context.ASPNETUSERROLEs.Remove(aSPNETUSERROLES);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ASPNETUSERROLESExists(int id)
        {
          return _context.ASPNETUSERROLEs.Any(e => e.Id == id);
        }
    }
}
