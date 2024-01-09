using Microsoft.AspNetCore.Mvc;
using PermohonanSurat.Models;
using System.Diagnostics;

namespace PermohonanSurat.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
    public class SuratController : Controller
    {
        private readonly PDFHelper _pdfHelper;
        private readonly EmailHelper _emailHelper;

        public SuratController(PDFHelper pdfHelper, EmailHelper emailHelper)
        {
            _pdfHelper = pdfHelper;
            _emailHelper = emailHelper;
        }

        // ... Metode lain dalam kontroler
    }

}