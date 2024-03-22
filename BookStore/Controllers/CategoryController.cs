using BookStore.Data;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            List<Category> listOfCategories=_context.Categories.ToList();
            
            return View(listOfCategories);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            

                if (category.Name==category.DisplayOrder.ToString())
                {
                    ModelState.AddModelError("name", "Name and Display order cannot be exactly the same");
                }
                if (ModelState.IsValid)
                {
                    _context.Categories.Add(category);
                    _context.SaveChanges();
                    return RedirectToAction("Index", "Category");
                }
                else
                    return View();
           

        }
    }
}
