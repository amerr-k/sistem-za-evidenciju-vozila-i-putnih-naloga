﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;

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
            car.EnginPowerKS = model.EnginPowerKS;
            car.EnginPowerKW = model.EnginPowerKW;
            car.Fuel = model.Fuel;
            car.ProductionYear = model.ProductionYear;

            context.SaveChanges();
            return car.CarId;
        }

        public int deleteCar(int carId)
        {
            Car car = context.Car.Find(carId);
            int deletedId = car.CarId;
            context.Remove(car);
            context.SaveChanges();
            return deletedId;
        }

        public List<CarsIndexVM> getAllCars()
        {
            List<CarsIndexVM> listModel = context.Car.Select(x => new CarsIndexVM
            {
                CarId = x.CarId,
                CarModel = x.CarModel.CarBrand.Name + " " + x.CarModel.Name,
                ChassisNumber = x.ChassisNumber,
                EngineNumber = x.EngineNumber,
                EnginPowerKS = x.EnginPowerKS,
                EnginPowerKW = x.EnginPowerKW,
                Fuel = x.Fuel.ToString(),
                ProductionYear = x.ProductionYear
            }).ToList();
            return listModel;
        }

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
                    EnginPowerKS = x.EnginPowerKS,
                    EnginPowerKW = x.EnginPowerKW,
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

        public CarsCreateUpdateVM prepareCarsCreateVM()
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
    }
}