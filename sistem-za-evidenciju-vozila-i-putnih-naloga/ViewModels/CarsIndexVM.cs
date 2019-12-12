using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class CarsIndexVM
    {
        [DisplayName("#")]
        public int CarId { get; set; }
        [DisplayName("Model")]
        public string CarModel { get; set; }

        [DisplayName("Broj šasije")]
        public string ChassisNumber { get; set; }

        [DisplayName("Broj motora")]
        public string EngineNumber { get; set; }

        [DisplayName("Snaga motora (KS)")]
        public string EnginPowerKS { get; set; }

        [DisplayName("Snaga motora (KW)")]
        public string EnginPowerKW { get; set; }

        [DisplayName("Gorivo")]
        public Fuel Fuel { get; set; }

        [DisplayName("Godina proizvodnje")]
        public int? ProductionYear { get; set; }
    }
}
