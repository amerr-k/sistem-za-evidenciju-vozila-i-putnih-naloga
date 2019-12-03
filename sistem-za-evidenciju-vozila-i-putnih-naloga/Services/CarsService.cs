using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

using sistem_za_evidenciju_vozila_i_putnih_naloga.Data;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;
using X.PagedList;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Services
{
    public class CarsService : ICarsService
    {
        private readonly SEVPNContext context;

        public CarsService(SEVPNContext context)
        {
            this.context = context;
        }

        public int createCar(CarsCreateUpdateVM model)
        {
            Car car = null;
            if (model.CarId != 0)
            {
                car = context.Car.Find(model.CarId);
            }
            else
            {
                car = new Car();
                context.Car.Add(car);
            }

            car.CarModelId = model.CarModelId;
            car.ChassisNumber = model.ChassisNumber;
            car.EngineNumber = model.EngineNumber;
            car.EnginPowerKS = float.Parse(model.EnginPowerKS);
            car.EnginPowerKW = float.Parse(model.EnginPowerKW);
            car.Fuel = model.Fuel;
            car.ProductionYear = model.ProductionYear;

            context.SaveChanges();
            return car.CarId;
        }

        public bool CreateCarType(CarsCreateCarModelVM model)
        {
            CarModel carModel = new CarModel
            {
                Name = model.Name,
                CarBrandId = model.CarBrandId
            };
            context.CarModel.Add(carModel);
            context.SaveChanges();
            return true;
        }

        public bool deleteCar(int carId)
        {
            Car car = context.Car.Find(carId);
            if(car == null)
            {
                return false;
            }
            context.Remove(car);
            context.SaveChanges();
            return true;
        }

        public IPagedList<CarsIndexVM> getAllCars(int? pageNumber, string sortOrder)
        {
            IQueryable<CarsIndexVM> listQueryable = context.Car.Select(x => new CarsIndexVM
            {
                CarId = x.CarId,
                CarModel = x.CarModel.CarBrand.Name + " " + x.CarModel.Name,
                ChassisNumber = x.ChassisNumber,
                EngineNumber = x.EngineNumber,
                EnginPowerKS = x.EnginPowerKS.ToString(),
                EnginPowerKW = x.EnginPowerKW.ToString(),
                Fuel = x.Fuel.ToString(),
                ProductionYear = x.ProductionYear
            });
            List<CarsIndexVM> listModel;
            switch (sortOrder)
            {
                case "idSort_desc":
                    listModel = listQueryable.OrderByDescending(s => s.CarId).ToList();
                    break;
                case "idSort":
                    listModel = listQueryable.OrderBy(s => s.CarId).ToList();
                    break;

                case "carModel":
                    listModel = listQueryable.OrderBy(s => s.CarModel).ToList();
                    break;
                case "carModel_desc":
                    listModel = listQueryable.OrderByDescending(s => s.CarModel).ToList();
                    break;
                case "enginePowerKs":
                    listModel = listQueryable.OrderBy(s => s.EnginPowerKS).ToList();
                    break;
                case "enginePowerKs_desc":
                    listModel = listQueryable.OrderByDescending(s => s.EnginPowerKS).ToList();
                    break;
                default:
                    listModel = listQueryable.OrderBy(s => s.CarId).ToList();
                    break;
            }
            IPagedList<CarsIndexVM> pageModel = listModel.ToPagedList(pageNumber ?? 1, 6);
            return pageModel;
        }
        //ToPagedList(pageNumber ?? 1, 3);
        public CarsDetailsVM getCarDetails(int id)
        {
            CarsDetailsVM model = context.Car.Where(x => x.CarId == id)
                .Select(x => new CarsDetailsVM
                {
                    CarId = x.CarId,
                    CarModel = x.CarModel.CarBrand.Name + " " + x.CarModel.Name,
                    ChassisNumber = x.ChassisNumber,
                    EngineNumber = x.EngineNumber,
                    EnginPowerKS = x.EnginPowerKS,
                    EnginPowerKW = x.EnginPowerKW,
                    Fuel = x.Fuel,
                    ProductionYear = x.ProductionYear
                }).FirstOrDefault();
            return model;
        }

        public CarsCreateUpdateVM getCarUpdateDetails(int id)
        {
            CarsCreateUpdateVM model = context.Car.Where(x => x.CarId == id)
                .Select(x => new CarsCreateUpdateVM
                {
                    CarId = x.CarId,
                    CarModelId = x.CarModelId,
                    CarModel = x.CarModel.Name + " " + x.CarModel.CarBrand.Name,
                    ChassisNumber = x.ChassisNumber,
                    EngineNumber = x.EngineNumber,
                    EnginPowerKS = x.EnginPowerKS.ToString(),
                    EnginPowerKW = x.EnginPowerKW.ToString(),
                    Fuel = x.Fuel,
                    ProductionYear = x.ProductionYear,
                    listCarModels = context.CarModel.Select(x => new SelectListItem
                    {
                        Value = x.CarModelId.ToString(),
                        Text = x.CarBrand.Name + " " + x.Name
                    }).ToList()
                }).SingleOrDefault();
            return model;
        }

        public CarsCreateUpdateVM PrepareDataForCreateCars()
        {
            CarsCreateUpdateVM model = new CarsCreateUpdateVM
            {
                listCarModels = context.CarModel.Select(x => new SelectListItem
                {
                    Value = x.CarModelId.ToString(),
                    Text = x.CarBrand.Name + " " + x.Name
                }).ToList(),
                
                //listFuels = Enum.GetValues(typeof(Fuel)).Cast<Fuel>().Select(x => new SelectListItem
                //{
                //    Text = x.ToString(),
                //    Value = ((int)x).ToString()
                //}).ToList()
            };
            return model;
        }

        public CarsCreateCarModelVM PrepareDataForCreateCarType()
        {
            CarsCreateCarModelVM model = new CarsCreateCarModelVM
            {
                carBrandsList = context.CarBrand.Select(x => new SelectListItem
                {
                    Value = x.CarBrandId.ToString(),
                    Text = x.Name
                }).ToList()
            };
            return model;
        }
    }
}
