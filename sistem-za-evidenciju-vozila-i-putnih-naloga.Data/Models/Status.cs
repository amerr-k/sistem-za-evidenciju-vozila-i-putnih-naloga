using System;
using System.Collections.Generic;
using System.Text;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models
{
    public enum Status
    {
        Recorded, //evidentiran
        Confirmed, //potvrdjen
        Denied, //odbijen
        Completed //zavrsen
    }
}
