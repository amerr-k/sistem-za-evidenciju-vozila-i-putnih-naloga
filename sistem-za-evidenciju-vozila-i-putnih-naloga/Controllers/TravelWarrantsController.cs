﻿using System;
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
using X.PagedList;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Controllers
{
    public class TravelWarrantsController : Controller
    {
        private readonly ITravelWarrantService travelWarrantService;
        private readonly SEVPNContext context;

        public TravelWarrantsController(ITravelWarrantService travelWarrantService, SEVPNContext context)
        {
            this.travelWarrantService = travelWarrantService;
            this.context = context;
        }

        public IActionResult Index(int? page, string sortOrder)
        {
            ViewData["IdSortParm"] = (String.IsNullOrEmpty(sortOrder) || sortOrder == "idSort") ? "idSort_desc" : "idSort";
            ViewData["CarSortParm"] = sortOrder == "car" ? "car_desc" : "car";
            //ViewData["StartTimeSortParm"] = sortOrder == "startTime" ? "startTime_desc" : "startTime";
            //ViewData["EndTimeSortParm"] = sortOrder == "endTime" ? "endTime_desc" : "endTime";
            ViewData["StatusSortParm"] = sortOrder == "status" ? "status_desc" : "status";
            ViewData["PageParam"] = page ?? 1;

            IPagedList<TWIndexVM> model = travelWarrantService.getAllTravelWarrants(page, sortOrder);
            return View(model);
        }
        
        public IActionResult Edit(int id)
        {
            TWEditVM model = travelWarrantService.getTravelWarrantEditDetails(id);
            if(model == null)
            {
                Response.StatusCode = 404;
                return View("TravelWarrantNotFound", id);
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(TWEditVM model)
        {
            
            //if (!travelWarrantService.editTravelWarrant(model))
            //    return View(model);
            //return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                TravelWarrant travelWarrant = context.TravelWarrant.Find(model.TravelWarrantId);
                if (travelWarrant == null)
                {
                    Response.StatusCode = 404;
                    return View("TravelWarrantNotFound", model.TravelWarrantId);
                }
                if (model.Status.ToString() == "Recorded" &&
                    travelWarrant.Status.ToString() == "Confirmed")
                {
                    TempData["message"] = "Nalog se ne moze vratiti na pocetno stanje";
                    model.Status = travelWarrant.Status;

                    return RedirectToAction("Edit", model);
                }
                if (model.Status.ToString() == "Completed" &&
                    travelWarrant.Status.ToString() == "Recorded")
                {
                    TempData["message"] = "Nalog nije moguce kompletirati prije nego li je prihvacen";
                    model.Status = travelWarrant.Status;

                    return RedirectToAction("Edit", model);
                }
                travelWarrant.Status = model.Status;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
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
            if (!travelWarrantService.createTravelWarrant(model)) {
                TempData["message"] = "Nalog se ne moze kreirati zbog toga sto je automobil vec rezervisan";

                return RedirectToAction("Create", model);
            };
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Search()
        {
            TWSearchVM model = travelWarrantService.getTWSearchVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult SearchResults(TWSearchVM model)
        {
            List<TWSearchResultsVM> modelList = travelWarrantService.getTWSearchResultsVM(model);
            return PartialView("SearchResults", modelList);
        }
    }
}
