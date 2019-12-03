
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Services
{
    public interface ICarsService
    {
        IPagedList<CarsIndexVM> getAllCars(int? pageNumber, string sortOrder);
        CarsCreateUpdateVM PrepareDataForCreateCars();
        int createCar(CarsCreateUpdateVM model);
        bool deleteCar(int carId);
        CarsDetailsVM getCarDetails(int id);
        CarsCreateUpdateVM getCarUpdateDetails(int id);
        CarsCreateCarModelVM PrepareDataForCreateCarType();
        bool CreateCarType(CarsCreateCarModelVM model);
    }
}
