using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopApplication.Models;

namespace ShopApplication.Controllers
{
    public class OrdersDetailsController : Controller
    {
        private readonly ShopDatabaseContext _context;

        public OrdersDetailsController(ShopDatabaseContext context)
        {
            _context = context;
        }

        // GET: OrdersDetails
        public async Task<IActionResult> Index()
        {
            var shopDatabaseContext = _context.OrdersDetails.Include(o => o.Order).Include(o => o.Product);
            return View(await shopDatabaseContext.ToListAsync());
        }

        // GET: OrdersDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersDetails = await _context.OrdersDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersDetails == null)
            {
                return NotFound();
            }

            return View(ordersDetails);
        }

        // GET: OrdersDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id");
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name");
            return View();
        }

        // POST: OrdersDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OrderId,ProductId,Amount")] OrdersDetails ordersDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ordersDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", ordersDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", ordersDetails.ProductId);
            return View(ordersDetails);
        }

        // GET: OrdersDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersDetails = await _context.OrdersDetails.FindAsync(id);
            if (ordersDetails == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", ordersDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", ordersDetails.ProductId);
            return View(ordersDetails);
        }

        // POST: OrdersDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductId,Amount")] OrdersDetails ordersDetails)
        {
            if (id != ordersDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ordersDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersDetailsExists(ordersDetails.Id))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "Id", "Id", ordersDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Name", ordersDetails.ProductId);
            return View(ordersDetails);
        }

        // GET: OrdersDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ordersDetails = await _context.OrdersDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ordersDetails == null)
            {
                return NotFound();
            }

            return View(ordersDetails);
        }

        // POST: OrdersDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ordersDetails = await _context.OrdersDetails.FindAsync(id);
            _context.OrdersDetails.Remove(ordersDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersDetailsExists(int id)
        {
            return _context.OrdersDetails.Any(e => e.Id == id);
        }
    }
}
