using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CuelloUterino.Models
{
    public class AnaliticaViewModel
    {
        [DisplayName("Fecha de inicio")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime FechaInicio { get; set; }

        [DisplayName("Fecha final")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime FechaFin { get; set; }

        public int PorcientoPositivo { get; set; }
        public int PorcientoNegativo { get; set; }
        public int PorcientoIndeterminado { get; set; }
        public int PorcientoAdecuadas { get; set; }

        public int Positivo { get; set; }
        public int Negativo { get; set; }
        public int Indeterminado { get; set; }
        public int Adecuado { get; set; }

        public int Total { get; set; }
        public int Diario { get; set; }
        public int Mensual { get; set; }
        public int Anual { get; set; }

      


    }
}