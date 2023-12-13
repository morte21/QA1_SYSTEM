using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    
    public class RequestorController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public RequestorController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        
        public IActionResult Index()
        {
            List<Requestor> requestors;
            requestors = _context.Requestor.ToList();
            return View(requestors);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            Requestor requestor = new Requestor();

            return View(requestor);
        }


        [HttpPost]
        public IActionResult Create(Requestor requestor, int Id)
        {
            // Fetch the request_qty value from the submitted form or requestor object
            var requestQty = Convert.ToInt32(requestor.request_qty);

            var consumable = _context.Consumables.FirstOrDefault(a => a.ConsumbleId == requestor.ConsumbleId); // Fetch the consumable you want to update

            // Example calculation logic (modify this based on your actual calculation)
            var consumQty = Convert.ToInt32(consumable.consum_qty); // Replace this with your actual calculation
            var totalQty = Convert.ToInt32(consumable.total_qty);
            var safetyQty = Convert.ToInt32(consumable.safety_qty);
            if (consumQty > 0) {
                consumQty = consumQty - requestQty ;
                totalQty = consumQty + safetyQty;


                consumable.consum_qty = consumQty.ToString();
                consumable.total_qty = totalQty.ToString(); ;
                consumable.safety_qty = safetyQty.ToString();
                // Save changes to the database
                _context.SaveChanges();
            } 
            else if (consumQty < 1)
            {
                safetyQty = safetyQty - requestQty;
                totalQty = consumQty + safetyQty;

                consumable.consum_qty = consumQty.ToString();
                consumable.total_qty = totalQty.ToString(); ;
                consumable.safety_qty = safetyQty.ToString();
                // Save changes to the database
                _context.SaveChanges();
            }
            
            // Update Consumables table based on calculations
           
            
            _context.Add(requestor);
            _context.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("EditRequest", "Consumables", new { id = requestor.ConsumbleId });
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            Requestor requestor = _context.Requestor
                .Where(a => a.RequestId == Id).FirstOrDefault();

            return View(requestor);

        }

        [HttpPost]
        public IActionResult Edit(Requestor requestor)
        {
            _context.Attach(requestor);
            _context.Entry(requestor).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction("EditRequest", "Consumables", new { id = requestor.ConsumbleId });

        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Requestor requestor = _context.Requestor
                .Where(a => a.RequestId == id).FirstOrDefault();


            return View(requestor);
        }

        [HttpPost]
        public IActionResult Delete(Requestor requestor, int id)
        {
            var requestorToDelete = _context.Requestor.FirstOrDefault(r => r.RequestId == id);
            if (requestorToDelete != null)
            {
                int getId = requestorToDelete.ConsumbleId;
                //_context.Attach(requestor);
                //_context.Entry(requestor).State = EntityState.Deleted;
                //_context.SaveChanges();

                _context.Requestor.Remove(requestorToDelete);
                _context.SaveChanges();

                return RedirectToAction("EditRequest", "Consumables", new { id = getId });
            }
            return View(requestor);
        }
    }
}

