using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    [Authorize(Roles = "Administrator, Moderator")]
    public class ConsumablesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ConsumablesController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Consumables> consumableViewModel;
            consumableViewModel = _context.Consumables.ToList();
            return View(consumableViewModel);
        }

        public IActionResult RequestorIndex()
        {
            List<Consumables> consumableViewModel;
            consumableViewModel = _context.Consumables.ToList();
            return View(consumableViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            Consumables consumables = new Consumables();
            //consumables.Requestor.Add(new Requestor() { ConsumbleId = 1 });

            return View(consumables);
        }

        [HttpPost]
        public IActionResult Create(Consumables consumables, IFormFile _pathPic)
        {
            //PO
            if (_pathPic != null && _pathPic.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"consumables"}-{_pathPic.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "consumables", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathPic.CopyTo(fileStream);
                }

                consumables.item_picture = uniqueFileNameIMG;
            }

            _context.Add(consumables);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditGet(int id)
        {
            var item = _context.Consumables.FirstOrDefault(p => p.ConsumbleId == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/Consumables/Edit.cshtml", item);
        }


        [HttpGet]
        public IActionResult DetailsGet(int id)
        {
            var item = _context.Consumables.FirstOrDefault(p => p.ConsumbleId == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/Consumables/Details.cshtml", item);
        }



      

        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Consumables init = _context.Consumables
                .Include(e => e.Requestor)
                .Where(a => a.ConsumbleId == Id).FirstOrDefault();

            return View(init);

        }

        [HttpPost]
        public IActionResult Edit(Consumables consumables, IFormFile _pathPic)
        {
     
            if (_pathPic != null && _pathPic.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"consumables"}-{_pathPic.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "consumables", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathPic.CopyTo(fileStream);
                }

                consumables.item_picture = uniqueFileNameIMG;
            }
            _context.Attach(consumables);
            _context.Entry(consumables).State = EntityState.Modified;
            _context.Entry(consumables).Property(f => f.item_picture).IsModified = _pathPic != null;
            _context.SaveChanges();

            return RedirectToAction("Index");

        }

        
        [HttpGet]
        public IActionResult EditRequest(int Id)
        {
            Consumables consumables = _context.Consumables.Include(e => e.Requestor).Where(a => a.ConsumbleId == Id).FirstOrDefault();
            return View(consumables);

        }

        [HttpPost]
        public IActionResult EditRequest(Consumables consumables, IFormFile _pathPic)
        {
            if (_pathPic != null && _pathPic.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"consumables"}-{_pathPic.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "consumables", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathPic.CopyTo(fileStream);
                }

                consumables.item_picture = uniqueFileNameIMG;
            }
            _context.Attach(consumables);
            _context.Entry(consumables).State = EntityState.Modified;
            _context.Entry(consumables).Property(f => f.item_picture).IsModified = _pathPic != null;
            _context.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("EditRequest", "Consumables", new { id = consumables.ConsumbleId });
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Consumables init = _context.Consumables
                .Where(a => a.ConsumbleId == Id)
                .FirstOrDefault();
            
            return View(init);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Consumables consumables = _context.Consumables
                .Include(e => e.Requestor)
                .Where(a => a.ConsumbleId == id).FirstOrDefault();

            return View(consumables);
        }

        [HttpPost]
        public IActionResult Delete(Consumables consumables)
        {
            _context.Attach(consumables);
            _context.Entry(consumables).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
