using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWSearchResultsVM
    {
        public int TravelWarrantId { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
