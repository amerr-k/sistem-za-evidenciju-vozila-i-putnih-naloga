using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWIndexVM
    {
        public int TravelWarrantId { get; set; }
        public string Car { get; set; }
        public string Driver { get; set; }
        public string StartEndTime { get; set; }
        public string StartEndLocation { get; set; }
        public string Status { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
