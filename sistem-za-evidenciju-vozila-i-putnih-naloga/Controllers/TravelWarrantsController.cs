using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Services;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Controllers
{
    public class TravelWarrantsController : Controller
    {
        private readonly ITravelWarrantService travelWarrantService;

        public TravelWarrantsController(ITravelWarrantService travelWarrantService)
        {
            this.travelWarrantService = travelWarrantService;
        }

        public IActionResult Index()
        {
            List<TWIndexVM> model = travelWarrantService.getAllTravelWarrants();
            return View(model);
        }
        
        public IActionResult Edit(int id)
        {
            TWEditVM model = travelWarrantService.getTravelWarrantEditDetails(id);
            return View(model);
        }
        public IActionResult Create()
        {
            TWCreateVM model = travelWarrantService.prepareTWCreateVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(TWCreateVM model)
        {
            int travelWarrantId = travelWarrantService.createTravelWarrant(model);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Search()
        {
            TWSearchVM model = travelWarrantService.getTWSearchVM();
            return View(model);
        }
        [HttpGet]
        public IActionResult SearchResults(TWSearchVM model)
        {
            List<TWSearchResultsVM> modelList = travelWarrantService.getTWSearchResultsVM(model);
            return View(modelList);
        }
    }
}
