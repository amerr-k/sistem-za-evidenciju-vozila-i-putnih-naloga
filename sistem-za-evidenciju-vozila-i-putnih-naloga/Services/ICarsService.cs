using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Services
{
    public interface ICarsService
    {
        List<CarsIndexVM> getAllCars();
        CarsCreateUpdateVM prepareCarsCreateVM();
        int createCar(CarsCreateUpdateVM model);
        int deleteCar(int carId);
        CarsDetailsVM getCarDetails(int id);
        CarsCreateUpdateVM getCarUpdateDetails(int id);
    }
}
