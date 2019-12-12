using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using PagedList.Core;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Services;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;
using X.PagedList;

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

        public IActionResult Index(int? page, string sortOrder)
        {
            ViewData["IdSortParm"] = (String.IsNullOrEmpty(sortOrder) || sortOrder == "idSort") ? "idSort_desc" : "idSort";
            ViewData["CarModelSortParm"] = sortOrder == "carModel" ? "carModel_desc" : "carModel";
            ViewData["EngineKSSortParm"] = sortOrder == "engineKs" ? "engineKs_desc" : "engineKs";
            ViewData["EngineKWSortParm"] = sortOrder == "engineKw" ? "engineKw_desc" : "engineKw";
            ViewData["FuelSortParm"] = sortOrder == "fuel" ? "fuel_desc" : "fuel";
            ViewData["YearSortParm"] = sortOrder == "year" ? "year_desc" : "year";
            ViewData["PageParam"] = page ?? 1;

            IPagedList<CarsIndexVM> model = carsService.getAllCars(page, sortOrder);
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateUpdateVM model = carsService.PrepareDataForCreateCars();
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(CarsCreateUpdateVM model)

        {
            if (ModelState.IsValid)
            {
                int carId = carsService.createCar(model);
                return RedirectToAction("Index");
            }
            model = carsService.PrepareDataForCreateCars();
            return View("Create", model);

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            CarsCreateUpdateVM model = carsService.getCarUpdateDetails(id);
            if(model == null)
            {
                Response.StatusCode = 404;
                return View("CarNotFound", id);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!carsService.deleteCar(id))
            {
                Response.StatusCode = 404;
                return View("CarNotFound", id);
            }

            return RedirectToAction("Index");
        }
        [HttpGet]

        public IActionResult Details(int id)
        {
            CarsDetailsVM model = carsService.getCarDetails(id);
            if(model == null)
            {
                Response.StatusCode = 404;
                return View("CarNotFound", id);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult CreateCarType()
        {
            CarsCreateCarModelVM model = carsService.PrepareDataForCreateCarType();            
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateCarType(CarsCreateCarModelVM carTypeModel)
        {
            bool status = carsService.CreateCarType(carTypeModel);
            CarsCreateUpdateVM model = carsService.PrepareDataForCreateCars();
            return RedirectToAction("Create");
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

