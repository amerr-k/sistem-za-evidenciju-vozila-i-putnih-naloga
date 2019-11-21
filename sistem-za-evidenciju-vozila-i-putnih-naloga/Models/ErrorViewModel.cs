using System;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
