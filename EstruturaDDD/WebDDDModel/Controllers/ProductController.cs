using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using Infrastructure.Configuration;
using ApplicationApp.Interfaces;

namespace WebDDDModel.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductApp _productApp;

        public ProductController(IProductApp productApp)
        {
            _productApp = productApp;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            return View(await _productApp.List()); ;
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productApp.GetEntityById(id);
            if (product == null)
                return NotFound();

            return View(product);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Price,IsActive,Id,Name")] Product product)
        {
            if (ModelState.IsValid)
            {
                await _productApp.Add(product);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productApp.GetEntityById(id);
            
            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Product/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Price,IsActive,Id,Name")] Product product)
        {
            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    await _productApp.Update(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await ProductExists(product.Id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productApp.GetEntityById(id);

            if (product == null)
                return NotFound();

            return View(product);
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _productApp.GetEntityById(id);
            await _productApp.Delete(product);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ProductExists(int id) => await _productApp.GetEntityById(id) != null;
    }
}
