using Microsoft.AspNetCore.Mvc.Rendering;
using sistem_za_evidenciju_vozila_i_putnih_naloga.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sistem_za_evidenciju_vozila_i_putnih_naloga.ViewModels
{
    public class CarsCreateUpdateVM
    {
        public int CarId { get; set; }

        [Required]
        [Display(Name = "Model automobila")]
        public int CarModelId { get; set; }

        
        public string CarModel { get; set; }

        public List<SelectListItem> listCarModels { get; set; }

        [Required(ErrorMessage = "Molimo unesite broj šasije")]
        [Display(Name = "Broj šasije")]
        public string ChassisNumber { get; set; }

        [Required(ErrorMessage = "Molimo unesite broj motora")]
        [Display(Name = "Broj motora")]
        public string EngineNumber { get; set; }

        //[Required(ErrorMessage = "Molimo unesite snagu motora u konjskim snagama")]
        [Display(Name = "Snaga motora (KS)")]
        public string EnginPowerKS { get; set; }

        //[Required(ErrorMessage = "Molimo unesite snagu motora u kilowatima")]
        [Display(Name = "Snaga motora (KW)")]
        public string EnginPowerKW { get; set; }

        [Required(ErrorMessage = "Odaberite vrstu goriva")]
        [Display(Name = "Gorivo")]
        public Fuel Fuel { get; set; }
        
        [Required(ErrorMessage = "Unesite godinu proizvodnje")]
        [Display(Name = "Godina proizvodnje")]
        public int? ProductionYear { get; set; }
    }
}
