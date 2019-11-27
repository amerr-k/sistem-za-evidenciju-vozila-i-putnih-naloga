using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWSearchResultsVM
    {
        [DisplayName("ID")]
        public int TravelWarrantId { get; set; }

        [DisplayName("Početno vrijeme")]
        public string StartTime { get; set; }

        [DisplayName("Krajnje vrijeme")]
        public string EndTime { get; set; }

        [DisplayName("Lokacija polaska")]
        public string StartLocation { get; set; }

        [DisplayName("Destinacija")]
        public string EndLocation { get; set; }

        [DisplayName("Broj putnika")]
        public int NumberOfPassengers { get; set; }
    }
}
