using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    public class EquipmentMachineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EquipmentMachineController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<EquipmentMachine> equipmentMachine = _context.EquipmentMachine.ToList();
            return View(equipmentMachine);
        }

        public IActionResult IndexHistory()
        {
            List<EquipmentMachine> equipmentMachine = _context.EquipmentMachine.ToList();
            return View(equipmentMachine);
        }

        public IActionResult IndexFixedAsset()
        {
            List<EquipmentMachine> equipmentMachine = _context.EquipmentMachine.ToList();
            return View(equipmentMachine);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            EquipmentMachine equipmentMachine = new EquipmentMachine();
            return View(equipmentMachine);
        }

        [HttpPost]
        public IActionResult Create(EquipmentMachine equipmentMachine, IFormFile _pathPic)
        {
            if (_pathPic != null && _pathPic.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipments"}-{_pathPic.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "equipments", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathPic.CopyTo(fileStream);
                }

                equipmentMachine.path_pic = uniqueFileNameIMG;
            }

            _context.Add(equipmentMachine);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            EquipmentMachine equipmentMachine = _context.EquipmentMachine.Find(Id);
            return View(equipmentMachine);

        }

        [HttpPost]
        public IActionResult Edit(EquipmentMachine equipmentMachine, IFormFile _pathPic)
        {
            if (_pathPic != null && _pathPic.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"equipments"}-{_pathPic.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "equipments", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathPic.CopyTo(fileStream);
                }

                equipmentMachine.path_pic = uniqueFileNameIMG;
            }

            _context.Attach(equipmentMachine);
            _context.Entry(equipmentMachine).State = EntityState.Modified;
            _context.Entry(equipmentMachine).Property(f => f.path_pic).IsModified = _pathPic != null;

            _context.SaveChanges();
            return RedirectToAction("Index", "EquipmentMachine", new { id = equipmentMachine.EQPid });

        }




        [HttpGet]
        public IActionResult EditGet(int id)
        {
            var item = _context.EquipmentMachine.FirstOrDefault(p => p.EQPid == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/EquipmentMachine/Edit.cshtml", item);
        }


        [HttpGet]
        public IActionResult DetailsGet(int id)
        {
            var item = _context.EquipmentMachine.FirstOrDefault(p => p.EQPid == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/EquipmentMachine/Details.cshtml", item);
        }

        [Authorize]
        [HttpGet]
        public IActionResult EditHistory(int Id)
        {
            EquipmentMachine equipmentMachine = _context.EquipmentMachine.Include(e => e.equipmentMachineHistory).Where(a => a.EQPid == Id).FirstOrDefault();
            return View(equipmentMachine);

        }

        [HttpGet]
        public IActionResult EditFixedAsset(int Id)
        {
            EquipmentMachine equipmentMachine = _context.EquipmentMachine.Include(e => e.fixedAssetEQP).Where(a => a.EQPid == Id).FirstOrDefault();
            return View(equipmentMachine);

        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            EquipmentMachine equipmentMachine = _context.EquipmentMachine
                .Where(a => a.EQPid == Id)
                .FirstOrDefault();

            return View(equipmentMachine);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            EquipmentMachine equipmentMachine = _context.EquipmentMachine
               .Include(e => e.equipmentMachineHistory).Include(e => e.fixedAssetEQP)
                .Where(a => a.EQPid == id).FirstOrDefault();

            return View(equipmentMachine);
        }

        [HttpPost]
        public IActionResult Delete(EquipmentMachine equipmentMachine)
        {
            _context.Attach(equipmentMachine);
            _context.Entry(equipmentMachine).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
