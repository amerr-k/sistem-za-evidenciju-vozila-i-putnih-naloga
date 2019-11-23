using Microsoft.AspNetCore.Mvc.Rendering;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWCreateVM
    {
        public int TravelWarrantId { get; set; }
        public int CarId { get; set; }
        public List<SelectListItem> carList { get; set; }
        public int DriverId { get; set; }
        public List<SelectListItem> driverList { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public Status Status { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
