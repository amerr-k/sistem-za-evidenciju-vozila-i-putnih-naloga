using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.Controllers
{
    [Route("Error/{statusCode}")]
    public class ErrorController : Controller
    {
        public IActionResult HttpExceptionHandler(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    ViewData["ErrorMessage"] = "Resurs nije pronađen";
                    break;
            }
            return View();
        }
        [Route("Error")]
        public IActionResult Error()
        {
            return View("Error");
        }
    }
}