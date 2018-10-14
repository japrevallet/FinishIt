using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinishIt.Data;
using FinishIt.Models;
using FinishIt.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinishIt.Controllers
{
    public class SenatorController : Controller
    {
        private ApplicationDbContext _context;

        public SenatorController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }



        public IActionResult ReadSenator(int SenatorID)
        {
            Senator senator = _context.Senators.Find(SenatorID);

            //Senator senator = applicationDbContext.Senators.Single(c => c.SenatorID == ReadSenatorViewModel.SenatorID);
            //senator = senator.Include(s => s.State).Include(p => p.Party).ToList();
            ViewBag.mySenator = senator;
            return View();
        }

        //public IActionResult ReadSenator()
        //{
        //    ReadSenatorViewModel readSenatorViewModel = new ReadSenatorViewModel();
        //    //readSenatorViewModel.Title = "Search";
        //    return View(readSenatorViewModel);
        //}

        //public IActionResult ReadSenator(int SenatorID)
        //{
        //    Senator senator = _context.Senators
        //        .Where(i => i.SenatorID == SenatorID)
        //        .Include(p => p.Party).Include(s => s.State)                
        //        .FirstOrDefault();
        //    ViewBag.senator = senator;
        //    return View();
        //}

        public IActionResult ReadAll()
        {
            IList<Senator> senators = _context.Senators
                .Include(s => s.State).Include(p => p.Party)
                .OrderBy(p => p.SenatorName)
                .ToList();
            ViewBag.senators = senators;

            //List<Senator> senators = applicationDbContext.Senators.ToList();
            //ViewBag.senators = senators;

            return View();
        }
    }
}