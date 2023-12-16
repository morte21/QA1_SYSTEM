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
            purchasing = _context.Purchasing
                .OrderByDescending(x => x.id) // Assuming 'id' is the ID field
                .Take(0)
                .ToList();
            return View(purchasing);
        }

        public IActionResult purchaseLoadData()
        {
            var draw = Request.Form["draw"].FirstOrDefault();
            int start = int.Parse(Request.Form["start"].FirstOrDefault());
            int length = int.Parse(Request.Form["length"].FirstOrDefault());

            // Get global search value
            string searchValue = Request.Form["search[value]"].FirstOrDefault();

            // Query the database based on start, length, filters, etc.
            var query = _context.Purchasing.Where(x => x.part_number != null);


            // Apply global search filter
            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(x =>
                    x.pr_number.Contains(searchValue) ||
                    x.purchase_order.Contains(searchValue) ||
                    x.date_request.ToString().Contains(searchValue) ||
                    x.purchase_dept.Contains(searchValue) ||
                    x.category.Contains(searchValue) ||
                    x.part_number.Contains(searchValue) ||
                    x.item_description.Contains(searchValue) ||
                    x.maker.Contains(searchValue) ||
                    x.supplier.Contains(searchValue) ||
                    x.request_reason.Contains(searchValue) ||
                    x.request_status.Contains(searchValue) ||
                    x.est_time_arrival.Contains(searchValue) ||
                    x.received_qty.Contains(searchValue) ||
                    x.item_comment.Contains(searchValue)
                   
                // ...other fields here
                );
            }

            // Fetch all search values for each column (tfoot)
            List<string> searchValuesTfoot = new List<string>();
            for (int i = 0; i < Request.Form.Keys.Count; i++)
            {
                string key = Request.Form.Keys.ElementAt(i);
                if (key.StartsWith("columns") && key.Contains("[search][value]"))
                {
                    searchValuesTfoot.Add(Request.Form[key].FirstOrDefault());
                }
            }

            // Apply column-wise search filters from tfoot in
            for (int i = 0; i < searchValuesTfoot.Count; i++)
            {
                if (!string.IsNullOrEmpty(searchValuesTfoot[i]))
                {
                    string getData = searchValuesTfoot[i];

                    // Adjust search logic for each column based on the index
                    switch (i)
                    {
                        case 1: // Handle search for the first column (adjust these cases based on your column order)
                            query = query.Where(x => x.pr_number.Contains(getData));
                            break;
                        case 2: // Handle search for the second column
                            query = query.Where(x => x.purchase_order.Contains(getData));
                            break;

                        case 3: // Handle search for the second column
                            query = query.Where(x => x.date_request.ToString().Contains(getData));
                            break;
                        case 4: // Handle search for the second column
                            query = query.Where(x => x.purchase_dept.Contains(getData));
                            break;
                        case 5: // Handle search for the second column
                            query = query.Where(x => x.category.Contains(getData));
                            break;
                        case 6: // Handle search for the second column
                            query = query.Where(x => x.part_number.Contains(getData));
                            break;
                        case 7: // Handle search for the second column
                            query = query.Where(x => x.item_description.Contains(getData));
                            break;
                        case 8: // Handle search for the second column
                            query = query.Where(x => x.maker.Contains(getData));
                            break;
                        case 9: // Handle search for the second column
                            query = query.Where(x => x.supplier.Contains(getData));
                            break;
                        case 15: // Handle search for the second column
                            query = query.Where(x => x.request_reason.Contains(getData));
                            break;
                        case 16: // Handle search for the second column
                            query = query.Where(x => x.request_status.Contains(getData));
                            break;
                        case 20: // Handle search for the second column
                            query = query.Where(x => x.est_time_arrival.Contains(getData));
                            break;
                        case 23: // Handle search for the second column
                            query = query.Where(x => x.received_qty.Contains(getData));
                            break;
                        case 24: // Handle search for the second column
                            query = query.Where(x => x.item_comment.Contains(getData));
                            break;
                        
                            // Add cases for other columns here...
                    }
                }
            }

            // Perform data filtering and pagination
            var data = query.Skip(start).Take(length).ToList();
            var totalCount = query.Count();

            return Json(new { draw = draw, recordsFiltered = totalCount, recordsTotal = totalCount, data = data });
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
