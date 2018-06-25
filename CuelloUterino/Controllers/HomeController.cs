using CuelloUterino.ModeloDatos;
using CuelloUterino.Models;
using CuelloUterino.Utiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuelloUterino.Controllers
{
    [Authorize(Roles = "Consulta")]
    public class HomeController : Controller
    {
        private Model db = new Model();

        [HttpPost]
        public ActionResult Index(AnaliticaViewModel analiticaViewModel)
        {

            var Lista = db.Informe.Where(x => x.FechaMuestra >= analiticaViewModel.FechaInicio && x.FechaMuestra <= analiticaViewModel.FechaFin
                           ).ToList();

               var respuesta = Calcular(Lista);
                respuesta.FechaFin = analiticaViewModel.FechaFin;
                respuesta.FechaInicio = analiticaViewModel.FechaInicio;
                return View(respuesta);


            //};
            //return View();
        }

        public ActionResult Index()
        {

            try
            {
                var Lista = db.Informe.ToList();
                var respursta= Calcular(Lista);
                return View(respursta);
               
            }
            catch (Exception)
            {

                throw;
            }
        }



        private AnaliticaViewModel Calcular(List<Informe> Lista)
        {
            double cantidadTotal = Lista.ToList().Count;
            if (cantidadTotal != 0)
            {
                var lista = db.Informe.OrderBy(x => x.FechaMuestra).ToList();

                var fechaInicio = lista.FirstOrDefault().FechaMuestra;
                var fechaFin = lista.LastOrDefault().FechaMuestra;

                double NegativoParaMalignidadTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 1).ToList().Count());
                double InflamacionleveTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 2).ToList().Count());
                double InflamacionModeradaTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 3).ToList().Count());
                double InflamacionSeveraTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 4).ToList().Count());
                double ASCUSTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 5).ToList().Count());
                double AGUSTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 6).ToList().Count());
                double LIEBGTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 7).ToList().Count());
                double LIEAGTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 8).ToList().Count());
                double CarcinomaInvasorTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 9).ToList().Count());
                double AdenocarcinomaTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 10).ToList().Count());
                double ASCHTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 12).ToList().Count());
                double OtrosTotal = (Lista.Where(x => x.IdDiagnosticoCitologico == 13).ToList().Count());


                double NegativoParaMalignidad = 0;
                double Inflamacionleve = 0;
                double InflamacionModerada = 0;
                double InflamacionSevera = 0;
                double ASCUS = 0;
                double AGUS = 0;
                double LIEBG = 0;
                double LIEAG = 0;
                double CarcinomaInvasor = 0;
                double Adenocarcinoma = 0;
                double ASCH = 0;
                double Otros = 0;



                var SinRealizar = 0;
                var CervicitisAguda = 0;
                var CervicitisCronica = 0;
                var AtipiaCoilociticaSinDisplasia = 0;
                var NICI = 0;
                var NICII = 0;
                var NICIII = 0;
                var CIS = 0;
                var CarcinomaEscamoso = 0;
                var DisplasiaGlandularEndocervical = 0;
                var AdenocarcinomaTipo = 0;
                var OtrosTipo = 0;

                NegativoParaMalignidad = Math.Round((NegativoParaMalignidadTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                Inflamacionleve = Math.Round((InflamacionleveTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                InflamacionModerada = Math.Round((InflamacionModeradaTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                InflamacionSevera = Math.Round((InflamacionSeveraTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                ASCUS = Math.Round((ASCUSTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                AGUS = Math.Round((AGUSTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                LIEBG = Math.Round((LIEBGTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                LIEAG = Math.Round((LIEAGTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                CarcinomaInvasor = Math.Round((CarcinomaInvasorTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                Adenocarcinoma = Math.Round((AdenocarcinomaTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                ASCH = Math.Round((ASCHTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);
                Otros = Math.Round((OtrosTotal * 100) / cantidadTotal, MidpointRounding.AwayFromZero);

                ////Tipo VPN/ Histológico

                SinRealizar = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 0).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                CervicitisAguda = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 1).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                CervicitisCronica = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 2).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                AtipiaCoilociticaSinDisplasia = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 3).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                NICI = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 4).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                NICII = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 5).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                NICIII = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 6).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                CIS = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 7).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                CarcinomaEscamoso = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 8).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                DisplasiaGlandularEndocervical = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 9).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                AdenocarcinomaTipo = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 10).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));
                OtrosTipo = Convert.ToInt32(Math.Round(Convert.ToDouble((Lista.Where(x => x.IdTipoHistologico == 11).ToList().Count() * 100) / Convert.ToInt32(cantidadTotal)), MidpointRounding.AwayFromZero));

                //

                double CitologiasTotales = Lista.Where(x => x.CitologiaVPH == true).ToList().Count();

                double NegativoParaMalignidadCitologias = 0;
                double InflamacionleveCitologias = 0;
                double InflamacionModeradaCitologias = 0;
                double InflamacionSeveraCitologias = 0;
                double ASCUSCitologias = 0;
                double AGUSCitologias = 0;
                double LIEBGCitologias = 0;
                double LIEAGCitologias = 0;
                double CarcinomaInvasorCitologias = 0;
                double AdenocarcinomaCitologias = 0;
                double ASCHCitologias = 0;
                double OtrosCitologias = 0;

                if (CitologiasTotales != 0)
                {
                    NegativoParaMalignidadCitologias = Math.Round((NegativoParaMalignidadTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    InflamacionleveCitologias = Math.Round((InflamacionleveTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    InflamacionModeradaCitologias = Math.Round((InflamacionModeradaTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    InflamacionSeveraCitologias = Math.Round((InflamacionSeveraTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    ASCUSCitologias = Math.Round((ASCUSTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    AGUSCitologias = Math.Round((AGUSTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    LIEBGCitologias = Math.Round((LIEBGTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    LIEAGCitologias = Math.Round((LIEAGTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    CarcinomaInvasorCitologias = Math.Round((CarcinomaInvasorTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    AdenocarcinomaCitologias = Math.Round((AdenocarcinomaTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    ASCHCitologias = Math.Round((ASCHTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                    OtrosCitologias = Math.Round((OtrosTotal * 100) / CitologiasTotales, MidpointRounding.AwayFromZero);
                }

                var viewModel = new AnaliticaViewModel
                {
                    NegativoParaMalignidad = NegativoParaMalignidad,
                    Adenocarcinoma = Adenocarcinoma,
                    AGUS = AGUS,
                    ASCH = ASCH,
                    ASCUS = ASCUS,
                    CarcinomaInvasor = CarcinomaInvasor,
                    Inflamacionleve = Inflamacionleve,
                    InflamacionModerada = InflamacionModerada,
                    InflamacionSevera = InflamacionSevera,
                    LIEAG = LIEAG,
                    LIEBG = LIEBG,
                    Otros = Otros,


                    ////Tipo VPN/ Histológico

                    AdenocarcinomaTipo = AdenocarcinomaTipo,
                    AtipiaCoilociticaSinDisplasia = AtipiaCoilociticaSinDisplasia,
                    CarcinomaEscamoso = CarcinomaEscamoso,
                    CervicitisAguda = CervicitisAguda,
                    CervicitisCronica = CervicitisCronica,
                    CIS = CIS,
                    DisplasiaGlandularEndocervical = DisplasiaGlandularEndocervical,
                    NICI = NICI,
                    NICII = NICII,
                    NICIII = NICIII,
                    OtrosTipo = OtrosTipo,
                    SinRealizar = SinRealizar,

                    ////


                    AdenocarcinomaCitologias = AdenocarcinomaCitologias,
                    AGUSCitologias = AGUSCitologias,
                    ASCHCitologias = ASCHCitologias,
                    ASCUSCitologias = ASCUSCitologias,
                    CarcinomaInvasorCitologias = CarcinomaInvasorCitologias,
                    InflamacionleveCitologias = InflamacionleveCitologias,
                    InflamacionModeradaCitologias = InflamacionModeradaCitologias,
                    InflamacionSeveraCitologias = InflamacionSeveraCitologias,
                    LIEAGCitologias = LIEAGCitologias,
                    LIEBGCitologias = LIEBGCitologias,
                    NegativoParaMalignidadCitologias = NegativoParaMalignidadCitologias,
                    OtrosCitologias = OtrosCitologias,

                    FechaInicio = fechaInicio,
                    FechaFin = fechaFin,


                };

                return viewModel;
            }

            else
             {

                var viewModel = new AnaliticaViewModel();
                return viewModel;
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}