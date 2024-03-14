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
    }
}
