using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CuelloUterino.Models
{
    public class AnaliticaViewModel
    {
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