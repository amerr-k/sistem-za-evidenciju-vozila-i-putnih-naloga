using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class TWIndexVM
    {
        [DisplayName("#")]
        public int TravelWarrantId { get; set; }

        [DisplayName("Automobil")]
        public string Car { get; set; }

        [DisplayName("Vozač")]
        public string Driver { get; set; }

        [DisplayName("Vrijeme")]
        public string StartEndTime { get; set; }

        [DisplayName("Lokacija")]
        public string StartEndLocation { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [DisplayName("Broj putnika")]
        public int NumberOfPassengers { get; set; }
    }
}
