using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pronia_Project.Datas;
using Pronia_Project.Models;
using System.Diagnostics;

namespace Pronia_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ProductDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ProductDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var getProducts = await _dbContext.Products.ToListAsync();
            return View(getProducts);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = _dbContext.Products.Include(p => p.Category).FirstOrDefault(p => p.Id == id);
            ViewBag.Related = _dbContext.Products.Where(p => p.CategoryId == product.CategoryId&&p.Id!=product.Id).ToList();
            return View(product);
        }
    }
}
