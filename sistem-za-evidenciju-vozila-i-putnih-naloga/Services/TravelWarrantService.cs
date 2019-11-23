using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Services
{
    public class TravelWarrantService : ITravelWarrantService
    {
        private readonly SEVPNContext context;

        public TravelWarrantService(SEVPNContext context)
        {
            this.context = context;
        }
        public int createTravelWarrant(TWCreateVM model)
        {
            TravelWarrant travelWarrant = new TravelWarrant
            {
                CarId = model.CarId,
                DriverId = model.DriverId,
                StartLocation = model.StartLocation,
                EndLocation = model.EndLocation,
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                NumberOfPassengers = model.NumberOfPassengers,
                Status = model.Status,
            };
            context.TravelWarrant.Add(travelWarrant);
            context.SaveChanges();
            return travelWarrant.CarId;
        }

        public int deleteTravelWarrant(int travelWarrantId)
        {
            throw new NotImplementedException();
        }

        public List<TWIndexVM> getAllTravelWarrants()
        {
            List<TWIndexVM> listModels = context.TravelWarrant.Select(x => new TWIndexVM
            {
                TravelWarrantId = x.TravelWarrantId,
                StartEndLocation = x.StartLocation + " - " + x.EndLocation,
                Car =  x.Car.CarModel.CarBrand.Name + " " + 
                                x.Car.CarModel.Name + " | " + 
                                x.Car.ChassisNumber,
                StartEndTime = x.StartTime.ToShortDateString() + " " + 
                               x.StartTime.ToShortTimeString() + " - " + 
                               x.EndTime.ToShortDateString() + " " + 
                               x.EndTime.ToShortTimeString(),
                Status = x.Status.ToString()
            }).ToList();
            return listModels;
        }

        public TWDetailsVM getTravelWarrantDetails(int travelWarrantId)
        {
            throw new NotImplementedException();
        }

        public TWEditVM getTravelWarrantEditDetails(int travelWarrantId)
        {
            TWEditVM model = context.TravelWarrant
                .Where(x => x.TravelWarrantId == travelWarrantId)
                .Select(x => new TWEditVM { 
                    TravelWarrantId = x.TravelWarrantId,
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    Car = x.Car.CarModel.CarBrand.Name + " " +
                                x.Car.CarModel.Name + " | " +
                                x.Car.ChassisNumber,
                    StartTime = x.StartTime.ToShortDateString() + " " +
                               x.StartTime.ToShortTimeString(),
                    EndTime = x.EndTime.ToShortDateString() + " " +
                               x.EndTime.ToShortTimeString(),
                    Status = x.Status
                }).SingleOrDefault();
            return model;
        }

        public List<TWSearchResultsVM> getTWSearchResultsVM(TWSearchVM model)
        {
            List<TWSearchResultsVM> modelList = context.TravelWarrant
                .Where(x => x.CarId == model.CarId)
                .Where(x => x.StartTime >= model.SearchStartDate && x.StartTime <= model.SearchEndDate)
                .Select(x => new TWSearchResultsVM
                {
                    TravelWarrantId = x.TravelWarrantId,
                    StartTime = x.StartTime.ToShortDateString() + " " +
                               x.StartTime.ToShortTimeString(),
                    EndTime = x.EndTime.ToShortDateString() + " " +
                               x.EndTime.ToShortTimeString(),
                    StartLocation = x.StartLocation,
                    EndLocation = x.EndLocation,
                    NumberOfPassengers = x.NumberOfPassengers
                }).ToList();
            return modelList;
        }

        public TWSearchVM getTWSearchVM()
        {
            TWSearchVM model = new TWSearchVM
            {
                carList = context.Car.Select(x => new SelectListItem
                {
                    Value = x.CarId.ToString(),
                    Text = x.CarModel.CarBrand.Name + " " +
                                x.CarModel.Name + " | " +
                                x.ChassisNumber
                }).ToList(),                
                SearchEndDate = DateTime.Now,
                SearchStartDate = DateTime.Now
            };
            model.carList.Add(new SelectListItem { Value = "0", Text = "None" });
            return model;
        }

        public TWCreateVM prepareTWCreateVM()
        {
            TWCreateVM model = new TWCreateVM
            {
                StartTime = DateTime.Now,
                EndTime = DateTime.Now,
                Status = Status.Confirmed,
                carList = context.Car.Select(x => new SelectListItem
                {
                    Value = x.CarId.ToString(),
                    Text = x.CarModel.CarBrand.Name + " " +
                                x.CarModel.Name + " | " +
                                x.ChassisNumber
                }).ToList(),
                driverList = context.Driver.Select(x => new SelectListItem
                {
                    Value = x.DriverId.ToString(),
                    Text = x.FirstName + " " + x.Surname
                }).ToList()
            };
            return model;
        }
    }
}
