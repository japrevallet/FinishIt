using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinishIt.Data;
using FinishIt.Models;
using FinishIt.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinishIt.Controllers
{
    public class FindUrLeaderController : Controller
    {
        //public IActionResult Index()
        //{
        //    ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        //    List<State> states = applicationDbContext.States.ToList();
        //    ViewBag.states = states;
        //    return View(states);
        //}

        //public IActionResult SelectAll()
        //{
        //    ApplicationDbContext applicationDbContext = new ApplicationDbContext();
        //    List<State> states = applicationDbContext.States.ToList();
        //    ViewBag.states = states;
        //    return View(states);
        //}

        private readonly ApplicationDbContext context;

        public FindUrLeaderController(ApplicationDbContext dbContext)
        {
            context = dbContext;
        }


        public IActionResult Index()
        {
            IList<State> states = context.States.Include(s => s.Senators).ToList();
            return View(states);
        }



        [HttpGet]
        public IActionResult SelectState()
        {
            ReadStateViewModel readStateViewModel = new ReadStateViewModel(context.States.ToList());
            return View(readStateViewModel);
        }

        [HttpGet]
        public IActionResult FindLeaders(int StateID)
        {
            IList<Senator> senators = new List<Senator>();
            State state = new State();

            senators = context.Senators.Where(s => s.StateID == StateID).ToList();

            return View(senators);
        }



        [HttpGet]
        public IActionResult SelectParty()
        {
            AllPartySenatorsViewModel allPartySenatorsViewModel = new AllPartySenatorsViewModel(context.Parties.ToList());
            return View(allPartySenatorsViewModel);
        }

        [HttpGet]
        public IActionResult PartyMembers(int PartyID)
        {
            IList<Senator> senators = new List<Senator>();
            Party party = new Party();

            senators = context.Senators.Where(p => p.PartyID == PartyID).ToList();

            return View(senators);
        }





        //[HttpGet]
        //public IActionResult Leaders()
        //{
        //    IList<Senator> senators = context.Senators.Include(s => s.State).ToList();
        //    ViewBag.senators = senators;
        //    return View();
        //}


        [HttpGet]
        [Authorize]
        public IActionResult AddState()
        {
            AddStateViewModel addStateViewModel = new AddStateViewModel();
            return View(addStateViewModel);
        }

        [HttpPost]
        public IActionResult AddState(AddStateViewModel addStateViewModel)
        {
            if (ModelState.IsValid)
            {
                State newState = new State();
                newState.StateName = addStateViewModel.StateName;

                context.States.Add(newState);
                context.SaveChanges();

                return Redirect("/FindUrLeader/SelectState");
            }
            return View(addStateViewModel);
        }
    }
}