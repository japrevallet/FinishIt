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
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult ReadSenator()
        //{
        //    ReadSenatorViewModel readSenatorViewModel = new ReadSenatorViewModel();
        //    //readSenatorViewModel.Title = "Search";
        //    return View(readSenatorViewModel);
        //}

        public IActionResult ReadSenator(int SenatorID)
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();
            Senator senator = applicationDbContext.Senators.Find(SenatorID);

            //Senator senator = applicationDbContext.Senators.Single(c => c.SenatorID == ReadSenatorViewModel.SenatorID);
            //senator = senator.Include(s => s.State).Include(p => p.Party).ToList();
            ViewBag.mySenator = senator;
            return View();
        }

        public IActionResult ReadAll()
        {
            ApplicationDbContext applicationDbContext = new ApplicationDbContext();

            IList<Senator> senators = applicationDbContext.Senators.Include(s => s.State).Include(p => p.Party).ToList();
            ViewBag.senators = senators;

            //List<Senator> senators = applicationDbContext.Senators.ToList();
            //ViewBag.senators = senators;

            return View();
        }
    }
}