using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    public class ComputersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ComputersController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Computers> computers;
            computers = _context.Computers.ToList();
            return View(computers);
        }

        public IActionResult IndexHistory()
        {
            List<Computers> computers;
            computers = _context.Computers.ToList();
            return View(computers);
        }

        public IActionResult IndexFixedAsset()
        {
            List<Computers> computers;
            computers = _context.Computers.ToList();
            return View(computers);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            Computers computers = new Computers();
            return View(computers);
        }

        [HttpPost]
        public IActionResult Create(Computers computers, IFormFile _pathPic)
        {

            if (_pathPic != null && _pathPic.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{_pathPic.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "computers", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathPic.CopyTo(fileStream);
                }

                computers.path_pic = uniqueFileNameIMG;
            }

            _context.Add(computers);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Computers computers = _context.Computers.Find(Id);

            return View(computers);

        }

        [HttpPost]
        public IActionResult Edit(Computers computers, IFormFile _pathPic)
        {
            if (_pathPic != null && _pathPic.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{_pathPic.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "computers", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathPic.CopyTo(fileStream);
                }

                computers.path_pic = uniqueFileNameIMG;
            }

            _context.Attach(computers);
            _context.Entry(computers).State = EntityState.Modified;
            _context.Entry(computers).Property(f => f.path_pic).IsModified = _pathPic != null;

            _context.SaveChanges();
            return RedirectToAction("Index", "Computers", new { id = computers.ComputerId });

        }

        [HttpGet]
        public IActionResult EditGet(int id)
        {
            var item = _context.Computers.FirstOrDefault(p => p.ComputerId == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/Computers/Edit.cshtml", item);
        }


        [HttpGet]
        public IActionResult DetailsGet(int id)
        {
            var item = _context.Computers.FirstOrDefault(p => p.ComputerId == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/Computers/Details.cshtml", item);
        }



        [Authorize]
        [HttpGet]
        public IActionResult EditHistory(int Id)
        {
            Computers computers = _context.Computers.Include(e => e.ComputerHistory).Where(a => a.ComputerId == Id).FirstOrDefault();

            return View(computers);

        }

        //[HttpPost]
        //public IActionResult EditHistory(Computers computers)
        //{
        //    _context.Attach(computers);
        //    _context.Entry(computers).State = EntityState.Modified;

        //    _context.SaveChanges();
        //    return RedirectToAction("EditHistory", "Computers", new { id = computers.ComputerId });

        //}

        [Authorize]
        [HttpGet]
        public IActionResult EditFixedAsset(int Id)
        {
            Computers computers = _context.Computers.Include(e => e.FixedAssetPC).Where(a => a.ComputerId == Id).FirstOrDefault();

            return View(computers);

        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Computers computers = _context.Computers
                .Where(a => a.ComputerId == Id)
                .FirstOrDefault();

            return View(computers);
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Computers computers = _context.Computers
                .Include(e => e.ComputerHistory).Include(e => e.FixedAssetPC)
                .Where(a => a.ComputerId == id).FirstOrDefault();

            return View(computers);
        }

        [HttpPost]
        public IActionResult Delete(Computers computers)
        {
            _context.Attach(computers);
            _context.Entry(computers).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
