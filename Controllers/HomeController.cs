using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;
using System.Diagnostics;

namespace QA1_SYSTEM.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment, ILogger<HomeController> logger)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
            _logger = logger;
        }


        public IActionResult Index()
        {
            DateTime currentDate = DateTime.Now;
            int currentMonth = currentDate.Month;
            var allPurchases = _context.Purchasing.ToList();

            var viewModel = new Global
            {
                

            consumables = _context.Consumables.ToList(),
                purchasing = _context.Purchasing.OrderByDescending(x => x.date_received).ToList(),
                totalComputersCount = _context.Computers.Count(),
                totalEqpCount = _context.EquipmentMachine.Count(),

                totalArrivalCount = _context.Purchasing.Where(x => x.request_status.Contains("ARRIVAL")).Count(),
                totalApprovalCount = _context.Purchasing.Where(x => x.request_status.Contains("APPROVAL")).Count(),

                // Filter records in-memory based on the month
                totalReceivedCount = allPurchases.Where(p => !string.IsNullOrEmpty(p.date_received) && DateTime.TryParse(p.date_received, out var parsedDate) && parsedDate.Month == currentMonth).Count(),};
            return View(viewModel);
        }

        public IActionResult Consumables()
        {
            var viewModel = new Global
            {
                consumables = _context.Consumables.ToList(),
                purchasing = _context.Purchasing.OrderByDescending(x => x.date_received).ToList(),
            };
            return View(viewModel);
        }

        public IActionResult Purchase()
        {
            var viewModel = new Global
            {
               purchasing = _context.Purchasing.OrderByDescending(x => x.date_received ).ToList(),
            };
            return View(viewModel);
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

