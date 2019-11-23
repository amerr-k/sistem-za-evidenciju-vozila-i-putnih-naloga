using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models
{
    public class Car
    {
        public int CarId { get; set; }

        [ForeignKey(nameof(CarModel))]
        public int CarModelId { get; set; }
        public CarModel CarModel { get; set; }

        public string ChassisNumber { get; set; }
        public string EngineNumber { get; set; }
        public double EnginPowerKS { get; set; }
        public double EnginPowerKW { get; set; }
        public Fuel Fuel{ get; set; }
        public int ProductionYear{ get; set; }

    }
}
