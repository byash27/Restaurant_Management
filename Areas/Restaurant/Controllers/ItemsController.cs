using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyRestaurant.Web.Data;
using MyRestaurant.Web.Models;

namespace MyRestaurant.Web.Areas.Restaurant.Controllers
{
    [Area("Restaurant")]
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Restaurant/Items
        public async Task<IActionResult> Index()
        {
            return View(await _context.Items.ToListAsync());
        }

        // GET: Restaurant/Items/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // GET: Restaurant/Items/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RestaurantSite/Items/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ItemId,ItemName,ItemPrice")] Item itemInputModel)
        {
            if (ModelState.IsValid)
            {
                itemInputModel.ItemName = itemInputModel.ItemName.Trim();
                bool isDuplicateFound
                        = _context.Items.Any(m => m.ItemName == itemInputModel.ItemName
                                       && m.ItemId != itemInputModel.ItemId);

                if (isDuplicateFound)
                {
                    ModelState.AddModelError("ItemName", "Duplicate! Another category with same name exists");
                }
                else
                {

                    _context.Add(itemInputModel);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(itemInputModel);
        }

        // GET: Restaurant/Items/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }

        // POST: RestaurantSite/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ItemId,ItemName,ItemPrice")] Item itemInputModel)
        {
            if (id != itemInputModel.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                bool isDuplicateFound
                   = _context.Items.Any(m => m.ItemName == itemInputModel.ItemName
                                                && m.ItemId != itemInputModel.ItemId);
                if (isDuplicateFound)
                {
                    ModelState.AddModelError("ItemName", "A Duplicate name is found");
                }
                else
                {


                    try
                    {
                        _context.Update(itemInputModel);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ItemExists(itemInputModel.ItemId))
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
            }
            return View(itemInputModel);
        }

        // GET: Restaurant/Items/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Items
                .FirstOrDefaultAsync(m => m.ItemId == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        // POST: Restaurant/Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
