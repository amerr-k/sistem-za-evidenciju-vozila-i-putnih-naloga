using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWSearchVM
    {
        [DisplayName("Automobil")]
        public int CarId { get; set; }
        public List<SelectListItem> carList { get; set; }

        [DisplayName("Početno vrijeme")]
        public DateTime SearchStartDate { get; set; }

        [DisplayName("Krajnje vrijeme")]
        public DateTime SearchEndDate { get; set; }
    }
}
