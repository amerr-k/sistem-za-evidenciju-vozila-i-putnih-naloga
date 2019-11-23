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

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Controllers
{
    public class CarsController : Controller
    {

        private readonly ICarsService carsService;

        public CarsController(ICarsService carsService)
        {
            this.carsService = carsService;
        }
        [HttpGet]

        public IActionResult Index()
        {
            List<CarsIndexVM> model = carsService.getAllCars();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateUpdateVM model = carsService.prepareCarsCreateVM();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CarsCreateUpdateVM model)
        {
            int carId = carsService.createCar(model);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarsCreateUpdateVM model = carsService.getCarUpdateDetails(id);
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            int deletedId = carsService.deleteCar(id);
            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Details(int id)
        {
            CarsDetailsVM model = carsService.getCarDetails(id);
            return View(model);
        }
    }
}


/*
 // GET: Cars
 public async Task<IActionResult> Index()
    {
        var sEVPNContext = _context.Car.Include(c => c.CarType);
        return View(await sEVPNContext.ToListAsync());
    }

    // GET: Cars/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Car
            .Include(c => c.CarType)
            .FirstOrDefaultAsync(m => m.CarId == id);
        if (car == null)
        {
            return NotFound();
        }

        return View(car);
    }

    // GET: Cars/Create
    public IActionResult Create()
    {
        ViewData["CarTypeId"] = new SelectList(_context.CarType, "CarTypeId", "CarTypeId");
        return View();
    }

    // POST: Cars/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("CarId,CarTypeId,ChassisNumber,EngineNumber,EnginPowerKS,EnginPowerKW,Fuel,ProductionYear")] Car car)
    {
        if (ModelState.IsValid)
        {
            _context.Add(car);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        ViewData["CarTypeId"] = new SelectList(_context.CarType, "CarTypeId", "CarTypeId", car.CarTypeId);
        return View(car);
    }

    // GET: Cars/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Car.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        ViewData["CarTypeId"] = new SelectList(_context.CarType, "CarTypeId", "CarTypeId", car.CarTypeId);
        return View(car);
    }

    // POST: Cars/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("CarId,CarTypeId,ChassisNumber,EngineNumber,EnginPowerKS,EnginPowerKW,Fuel,ProductionYear")] Car car)
    {
        if (id != car.CarId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(car);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(car.CarId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        ViewData["CarTypeId"] = new SelectList(_context.CarType, "CarTypeId", "CarTypeId", car.CarTypeId);
        return View(car);
    }

    // GET: Cars/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var car = await _context.Car
            .Include(c => c.CarType)
            .FirstOrDefaultAsync(m => m.CarId == id);
        if (car == null)
        {
            return NotFound();
        }

        return View(car);
    }

    // POST: Cars/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var car = await _context.Car.FindAsync(id);
        _context.Car.Remove(car);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool CarExists(int id)
    {
        return _context.Car.Any(e => e.CarId == id);
    }
}

 */
