using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models
{
    public class CarModel
    {
        public int CarModelId { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(CarModel))]
        public int CarBrandId { get; set; }
        public CarBrand CarBrand { get; set; }
    }
}
