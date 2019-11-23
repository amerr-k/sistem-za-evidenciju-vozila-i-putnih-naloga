using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWSearchVM
    {
        public int CarId { get; set; }
        public List<SelectListItem> carList { get; set; }
        public DateTime SearchStartDate { get; set; }
        public DateTime SearchEndDate { get; set; }
    }
}
