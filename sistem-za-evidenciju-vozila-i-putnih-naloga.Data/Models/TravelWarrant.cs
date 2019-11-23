using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models
{
    public class TravelWarrant
    {
        public int TravelWarrantId { get; set; }

        [ForeignKey(nameof(Car))]
        public int CarId { get; set; }
        public Car Car { get; set; }

        [ForeignKey(nameof(Driver))]
        public int DriverId { get; set; }
        public Driver Driver { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string StartLocation { get; set; }
        public string EndLocation { get; set; }
        public Status Status { get; set; }
        public int NumberOfPassengers { get; set; }
    }
}
