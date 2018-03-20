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
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/mm/yyyy}")]
        public DateTime FechaFin { get; set; }


        public double NegativoParaMalignidad { get; set; }
        public double Inflamacionleve { get; set; }
        public double InflamacionModerada { get; set; }
        public double InflamacionSevera { get; set; }
        public double ASCUS { get; set; }
        public double AGUS { get; set; }
        public double LIEBG { get; set; }
        public double LIEAG { get; set; }
        public double CarcinomaInvasor { get; set; }
        public double Adenocarcinoma { get; set; }
        public double ASCH { get; set; }
        public double Otros { get; set; }



        public int SinRealizar { get; set; }
        public int CervicitisAguda { get; set; }
        public int CervicitisCronica { get; set; }
        public int AtipiaCoilociticaSinDisplasia { get; set; }
        public int NICI { get; set; }
        public int NICII { get; set; }
        public int NICIII { get; set; }
        public int CIS { get; set; }
        public int CarcinomaEscamoso { get; set; }
        public int DisplasiaGlandularEndocervical { get; set; }
        public int AdenocarcinomaTipo { get; set; }
        public int OtrosTipo { get; set; }


        public double NegativoParaMalignidadCitologias { get; set; }
        public double InflamacionleveCitologias { get; set; }
        public double InflamacionModeradaCitologias { get; set; }
        public double InflamacionSeveraCitologias { get; set; }
        public double ASCUSCitologias { get; set; }
        public double AGUSCitologias { get; set; }
        public double LIEBGCitologias { get; set; }
        public double LIEAGCitologias { get; set; }
        public double CarcinomaInvasorCitologias { get; set; }
        public double AdenocarcinomaCitologias { get; set; }
        public double ASCHCitologias { get; set; }
        public double OtrosCitologias { get; set; }

    }
}