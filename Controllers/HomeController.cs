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
            return View();
        }

        public IActionResult Consumables()
        {
            var viewModel = new Global
            {
                consumables = _context.Consumables.ToList(),
                //computerHistory = _context.ComputerHistory.ToList(),
                //computers = _context.Computers.ToList(),
                //equipmentMachine = _context.EquipmentMachine.ToList(),
                //equipmentMachineHistory = _context.EquipmentMachineHistory.ToList(),
                //fixedAssetEQP = _context.FixedAssetEQP.ToList(),
                //fixedAssetPC = _context.FixedAssetPC.ToList(),
                //itemRequest = _context.ItemRequest.ToList(),
                //requestor = _context.Requestor.ToList(),
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
