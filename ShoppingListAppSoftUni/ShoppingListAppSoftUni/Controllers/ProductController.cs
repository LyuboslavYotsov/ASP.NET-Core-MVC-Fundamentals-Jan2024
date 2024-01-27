using Microsoft.AspNetCore.Mvc;
using ShoppingListAppSoftUni.Contracts;
using ShoppingListAppSoftUni.Models;

namespace ShoppingListAppSoftUni.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await _productService.GetAllAsync();

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(ProductViewModel model)
        {
            if (ModelState.IsValid)
            {
                await _productService.AddProductAsync(model);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _productService.GetByIdAsync(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _productService.UpdateProductAsync(model);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
           await _productService.DeleteProductAsync(id);

            return RedirectToAction("Index");
        }
    }
}
