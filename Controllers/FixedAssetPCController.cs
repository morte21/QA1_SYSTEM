using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    public class FixedAssetPCController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FixedAssetPCController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<FixedAssetPC> fixedAssetPC;
            fixedAssetPC = _context.FixedAssetPC.ToList();
            return View(fixedAssetPC);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            FixedAssetPC fixedAssetPC = new FixedAssetPC();
            return View(fixedAssetPC);
        }

        [HttpPost]
        public IActionResult Create(FixedAssetPC fixedAssetPC)
        {
            _context.Add(fixedAssetPC);
            _context.SaveChanges();
            return RedirectToAction("EditFixedAsset", "Computers", new { id = fixedAssetPC.ComputerId });
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            FixedAssetPC fixedAssetPC = _context.FixedAssetPC
                .Where(a => a.FixedAssetPCId == Id).FirstOrDefault();

            return View(fixedAssetPC);

        }

        [HttpPost]
        public IActionResult Edit(FixedAssetPC fixedAssetPC)
        {
            _context.Attach(fixedAssetPC);
            _context.Entry(fixedAssetPC).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction("Index");
            //return RedirectToAction("EditRequest", "Consumables", new { id = computerHistory.ComputerId });

        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            FixedAssetPC fixedAssetPC = _context.FixedAssetPC
                .Where(a => a.FixedAssetPCId == id).FirstOrDefault();


            return View(fixedAssetPC);
        }

        [HttpPost]
        public IActionResult Delete(FixedAssetPC fixedAssetPC, int id)
        {
            var requestorToDelete = _context.FixedAssetPC.FirstOrDefault(r => r.FixedAssetPCId == id);
            if (requestorToDelete != null)
            {
                int getId = requestorToDelete.ComputerId;
                //_context.Attach(requestor);
                //_context.Entry(requestor).State = EntityState.Deleted;
                //_context.SaveChanges();

                _context.FixedAssetPC.Remove(requestorToDelete);
                _context.SaveChanges();

                return RedirectToAction("EditRequest", "FixedAssetPC", new { id = getId });
            }
            return View(fixedAssetPC);
        }
    }
}
