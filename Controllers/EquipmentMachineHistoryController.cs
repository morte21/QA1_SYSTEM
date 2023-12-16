using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    public class EquipmentMachineHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EquipmentMachineHistoryController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<EquipmentMachineHistory> equipmentMachineHistory = _context.EquipmentMachineHistory.ToList();
            return View(equipmentMachineHistory);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            EquipmentMachineHistory equipmentMachineHistory = new EquipmentMachineHistory();
            return View(equipmentMachineHistory);
        }

        [HttpPost]
        public IActionResult Create(EquipmentMachineHistory equipmentMachineHistory)
        {
            _context.Add(equipmentMachineHistory);
            _context.SaveChanges();

            return RedirectToAction("EditHistory", "EquipmentMachine", new { id = equipmentMachineHistory.EQPid });
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            EquipmentMachineHistory equipmentMachineHistory = _context.EquipmentMachineHistory
                .Where(a => a.EqpMacId == Id).FirstOrDefault();

            return View(equipmentMachineHistory);

        }

        [HttpPost]
        public IActionResult Edit(EquipmentMachineHistory equipmentMachineHistory)
        {
            _context.Attach(equipmentMachineHistory);
            _context.Entry(equipmentMachineHistory).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction("EditHistory", "EquipmentMachine", new { id = equipmentMachineHistory.EQPid });

        }
    }
}
