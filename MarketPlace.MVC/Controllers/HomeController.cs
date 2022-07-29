using MarketPlace.MVC.Models;
using MarketPlaceExam.Business.Model;
using MarketPlaceExam.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MarketPlace.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _service;

        public HomeController(ILogger<HomeController> logger, ICategoryService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            CategoryModel dummyModel = new CategoryModel
            {
                Name = "FOO",
                Description = "BAR",
            };
            
            _service.AddCategory(dummyModel);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}