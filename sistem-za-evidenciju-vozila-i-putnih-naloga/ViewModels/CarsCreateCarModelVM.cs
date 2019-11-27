using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class CarsCreateCarModelVM
    {
        public string Name { get; set; }
        public int CarBrandId { get; set; }
        public List<SelectListItem> carBrandsList { get; set; }
    }
}
