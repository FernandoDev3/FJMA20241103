using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FJMA20241103.Models;

namespace FJMA20241103.Controllers
{
    public class AutosController : Controller
    {
        private readonly FJMA20241103DBContext _context;

        public AutosController(FJMA20241103DBContext context)
        {
            _context = context;
        }

        // GET: Autos
        public async Task<IActionResult> Index()
        {
              return _context.Autos != null ? 
                          View(await _context.Autos.ToListAsync()) :
                          Problem("Entity set 'FJMA20241103DBContext.Autos'  is null.");
        }

        // GET: Autos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.IdAuto == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // GET: Autos/Create
        public IActionResult Create()
        {

            var Autos = new Auto();
            Autos.Marca = Autos.Marca;
            Autos.Modelo = Autos.Modelo;
            Autos.Anio = Autos.Anio;
            Autos.ComponenteCarros = new List<ComponenteCarro>();
            Autos.ComponenteCarros.Add(new ComponenteCarro
            {
                IdComponente = 1
            });
            ViewBag.Accion = "Create";
            return View(Autos);
        }

        // POST: Autos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAuto,Marca,Modelo,Anio")] Auto auto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(auto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(auto);
        }
        [HttpPost]
        public ActionResult AgregarDetalles([Bind("IdAuto,Marca,Modelo,Anio")] Auto auto, string accion)
        {
            auto.ComponenteCarros.Add(new ComponenteCarro { IdComponente = 1});
            ViewBag.Accion = accion;
            return View(accion, auto);
        }
        //public ActionResult EliminarDetalles([Bind("IdAuto,Marca,Modelo,Anio")] Auto auto,
        //   int index, string accion)
        //{
        //    var det = auto.ComponenteCarros[index];
        //    if (accion == "Edit" && det.Id > 0)
        //    {
        //        det.Id = det.Id * -1;
        //    }
        //    else
        //    {
        //        auto.ComponenteCarros.RemoveAt(index);
        //    }

        //    ViewBag.Accion = accion;
        //    return View(accion, auto);
        //}

        // GET: Autos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos.FindAsync(id);
            if (auto == null)
            {
                return NotFound();
            }
            return View(auto);
        }

        // POST: Autos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAuto,Marca,Modelo,Anio")] Auto auto)
        {
            if (id != auto.IdAuto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(auto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoExists(auto.IdAuto))
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
            return View(auto);
        }

        // GET: Autos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autos == null)
            {
                return NotFound();
            }

            var auto = await _context.Autos
                .FirstOrDefaultAsync(m => m.IdAuto == id);
            if (auto == null)
            {
                return NotFound();
            }

            return View(auto);
        }

        // POST: Autos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autos == null)
            {
                return Problem("Entity set 'FJMA20241103DBContext.Autos'  is null.");
            }
            var auto = await _context.Autos.FindAsync(id);
            if (auto != null)
            {
                _context.Autos.Remove(auto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoExists(int id)
        {
          return (_context.Autos?.Any(e => e.IdAuto == id)).GetValueOrDefault();
        }
    }
}
