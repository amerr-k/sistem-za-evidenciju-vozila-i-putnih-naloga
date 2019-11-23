using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWEditVM
    {
        public int TravelWarrantId { get; set; }
        public string Car { get; set; }
        public string Driver { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int NumberOfPassengers { get; set; }
        public Status Status { get; set; }

    }
}
