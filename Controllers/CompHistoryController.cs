using Azure.Core;
using DocumentFormat.OpenXml.Office2010.Excel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QA1_SYSTEM.Data;
using QA1_SYSTEM.Models;

namespace QA1_SYSTEM.Controllers
{
    public class CompHistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CompHistoryController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<ComputerHistory> computerHistory;
            computerHistory = _context.ComputerHistory.ToList();
            return View(computerHistory);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            ComputerHistory computerHistory = new ComputerHistory();
            return View(computerHistory);
        }

        [HttpPost]
        public IActionResult Create(ComputerHistory computerHistory)
        {
            _context.Add(computerHistory);
            _context.SaveChanges();

            return RedirectToAction("EditHistory", "Computers", new { id = computerHistory.ComputerId });
        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            ComputerHistory computerHistory = _context.ComputerHistory
                .Where(a => a.CompHistoryId == Id).FirstOrDefault();

            return View(computerHistory);

        }

        [HttpPost]
        public IActionResult Edit(ComputerHistory computerHistory)
        {
            _context.Attach(computerHistory);
            _context.Entry(computerHistory).State = EntityState.Modified;

            _context.SaveChanges();
            return RedirectToAction("EditHistory", "Computers", new { id = computerHistory.ComputerId });

        }

        [Authorize(Roles = "Administrator, Moderator")]
        [HttpGet]
        public IActionResult Delete(int id)
        {
            ComputerHistory computerHistory = _context.ComputerHistory
                .Where(a => a.CompHistoryId == id).FirstOrDefault();


            return View(computerHistory);
        }

        [HttpPost]
        public IActionResult Delete(ComputerHistory computerHistory, int id)
        {
            var requestorToDelete = _context.ComputerHistory.FirstOrDefault(r => r.CompHistoryId == id);
            if (requestorToDelete != null)
            {
                int getId = requestorToDelete.ComputerId;

                _context.ComputerHistory.Remove(requestorToDelete);
                _context.SaveChanges();

                return RedirectToAction("EditRequest", "ComputerHistory", new { id = getId });
            }
            return View(computerHistory);
        }


        [HttpGet]
        public IActionResult GetHistoryPartialView(int id)
        {
            var historyData = _context.ComputerHistory
               .Where(a => a.CompHistoryId == id).FirstOrDefault();
            return PartialView("~/Views/CompHistory/Edit.cshtml", historyData);

            
        }
    }
}
