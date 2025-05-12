using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using MVC2.UnitOfWorks;

namespace MVC2.Controllers
{
    public class HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;


        public IActionResult Index()
        {
            ViewData["SoLuongSV"] = _unitOfWork.SinhVienRepo.GetAll().Count;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
