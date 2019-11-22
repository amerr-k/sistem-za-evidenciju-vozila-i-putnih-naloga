using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class CarsDetailsVM
    {
        public int CarId { get; set; }
        public string CarModel { get; set; }
        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public double EnginPowerKS { get; set; }
        public double EnginPowerKW { get; set; }
        public Fuel Fuel { get; set; }
        public int ProductionYear { get; set; }
    }
}
