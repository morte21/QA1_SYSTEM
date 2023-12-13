using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    [Authorize(Roles = "Administrator, Moderator")]
    public class PurchaseController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public PurchaseController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }


        public IActionResult Index()
        {
            List<Purchasing> purchasing;
            purchasing = _context.Purchasing.ToList();
            return View(purchasing);
        }


        [HttpGet]
        public IActionResult Create()
        {
            Purchasing purchasing = new Purchasing();
            //consumables.Requestor.Add(new Requestor() { ConsumbleId = 1 });

            return View(purchasing);
        }

        [HttpPost]
        public IActionResult Create(Purchasing purchasing, IFormFile _pathDoc, IFormFile _pathDoc2)
        {
            //PO
            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"purchaseOrder"}-{purchasing.purchase_order}-{_pathDoc.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "purchaseOrder", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                purchasing.po_path = uniqueFileNameIMG;
            }

            //PR
            if (_pathDoc2 != null && _pathDoc2.Length > 0)
            {
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"purchaseRequest"}-{purchasing.pr_number}-{_pathDoc2.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "purchaseRequest", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc2.CopyTo(fileStream);
                }

                purchasing.pr_path = uniqueFileNameDoc;
            }

            _context.Add(purchasing);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Edit( int Id)
        {
            Purchasing purchasing = _context.Purchasing
                .Where(a => a.id == Id).FirstOrDefault();

            return View(purchasing);

        }


        [HttpPost]
        public IActionResult Edit(Purchasing purchasing, IFormFile _pathDoc, IFormFile _pathDoc2)
        {
            //PO
            if (_pathDoc != null && _pathDoc.Length > 0)
            {
                string uniqueFileNameIMG = $"{Guid.NewGuid()}-{"purchaseOrder"}-{purchasing.purchase_order}-{_pathDoc.FileName}";
                string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "purchaseOrder", uniqueFileNameIMG);

                using (var fileStream = new FileStream(imagePath, FileMode.Create))
                {
                    _pathDoc.CopyTo(fileStream);
                }

                purchasing.po_path = uniqueFileNameIMG;
            }

            //PR
            if (_pathDoc2 != null && _pathDoc2.Length > 0)
            {
                string uniqueFileNameDoc = $"{Guid.NewGuid()}-{"purchaseRequest"}-{purchasing.pr_number}-{_pathDoc2.FileName}";
                string docPath = Path.Combine(_webHostEnvironment.WebRootPath, "purchaseRequest", uniqueFileNameDoc);

                using (var fileStream = new FileStream(docPath, FileMode.Create))
                {
                    _pathDoc2.CopyTo(fileStream);
                }

                purchasing.pr_path = uniqueFileNameDoc;
            }
            _context.Attach(purchasing);
            _context.Entry(purchasing).State = EntityState.Modified;
            _context.Entry(purchasing).Property(f => f.po_path).IsModified = _pathDoc != null;
            _context.Entry(purchasing).Property(f => f.pr_path).IsModified = _pathDoc2 != null;
            _context.SaveChanges();


            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult EditGet(int id)
        {
            var item = _context.Purchasing.FirstOrDefault(p => p.id == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/Purchase/Edit.cshtml", item);
        }

        

        [HttpGet]
        public IActionResult DetailGet(int id)
        {
            var item = _context.Purchasing.FirstOrDefault(p => p.id == id);

            if (item == null)
            {
                // Handle when item with the given ID is not found
                return NotFound(); // Return a 404 Not Found response or some error handling
            }
            return PartialView("~/Views/Purchase/Details.cshtml", item);
        }

        [HttpGet]
        public IActionResult Details(int Id)
        {
            Purchasing purchasing = _context.Purchasing
                .Where(a => a.id == Id)
                .FirstOrDefault();
            
            return View(purchasing);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Purchasing purchasing = _context.Purchasing
                .Where(a => a.id == id).FirstOrDefault();


            return View(purchasing);
        }

        [HttpPost]
        public IActionResult Delete(Purchasing purchasing)
        {
            _context.Attach(purchasing);
            _context.Entry(purchasing).State = EntityState.Deleted;
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
