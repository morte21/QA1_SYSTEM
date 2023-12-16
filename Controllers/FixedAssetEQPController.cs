using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    public class FixedAssetEQPController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FixedAssetEQPController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<FixedAssetEQP> fixedAssetEQP = _context.FixedAssetEQP.ToList();
            return View(fixedAssetEQP);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            FixedAssetEQP fixedAssetEQP = new FixedAssetEQP();
            return View(fixedAssetEQP);
        }

        [HttpPost]
        public IActionResult Create(FixedAssetEQP fixedAssetEQP)
        {
            _context.Add(fixedAssetEQP);
            _context.SaveChanges();

            return RedirectToAction("EditFixedAsset", "EquipmentMachine", new { id = fixedAssetEQP.EQPid });
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            FixedAssetEQP equipmentMachineHistory = _context.FixedAssetEQP
                .Where(a => a.EQPassetId == Id).FirstOrDefault();

            return View(equipmentMachineHistory);

        }

        [HttpPost]
        public IActionResult Edit(FixedAssetEQP equipmentMachineHistory)
        {
            _context.Attach(equipmentMachineHistory);
            _context.Entry(equipmentMachineHistory).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction("EditFixedAsset", "EquipmentMachine", new { id = equipmentMachineHistory.EQPid });

        }
    }
}
