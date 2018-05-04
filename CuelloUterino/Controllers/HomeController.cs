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

            var lista = db.Informe.Where(x=>x.FechaMuestra>=analiticaViewModel.FechaInicio && x.FechaMuestra<=analiticaViewModel.FechaFin
                                       ).ToList();

            if (lista.Count != 0)
            {
                 lista = lista.OrderBy(x => x.FechaMuestra).ToList();

                var fechaInicio = analiticaViewModel.FechaInicio;
                var fechaFin = analiticaViewModel.FechaFin;


                double HPVTotal = lista.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Positivo).ToList().Count;

                double NegativoParaMalignidadTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 1).ToList().Count());
                double InflamacionleveTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 2).ToList().Count());
                double InflamacionModeradaTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 3).ToList().Count());
                double InflamacionSeveraTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 4).ToList().Count());
                double ASCUSTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 5).ToList().Count());
                double AGUSTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 6).ToList().Count());
                double LIEBGTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 7).ToList().Count());
                double LIEAGTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 8).ToList().Count());
                double CarcinomaInvasorTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 9).ToList().Count());
                double AdenocarcinomaTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 10).ToList().Count());
                double ASCHTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 12).ToList().Count());
                double OtrosTotal = (lista.Where(x => x.IdDiagnosticoCitologico == 13).ToList().Count());



                double NegativoParaMalignidad = (NegativoParaMalignidadTotal * 100) / HPVTotal;
                double Inflamacionleve = (InflamacionleveTotal * 100) / HPVTotal;
                double InflamacionModerada = (InflamacionModeradaTotal * 100) / HPVTotal;
                double InflamacionSevera = (InflamacionSeveraTotal * 100) / HPVTotal;
                double ASCUS = (ASCUSTotal * 100) / HPVTotal;
                double AGUS = (AGUSTotal * 100) / HPVTotal;
                double LIEBG = (LIEBGTotal * 100) / HPVTotal;
                double LIEAG = (LIEAGTotal * 100) / HPVTotal;
                double CarcinomaInvasor = (CarcinomaInvasorTotal * 100) / HPVTotal;
                double Adenocarcinoma = (AdenocarcinomaTotal * 100) / HPVTotal;
                double ASCH = (ASCHTotal * 100) / HPVTotal;
                double Otros = (OtrosTotal * 100) / HPVTotal;




                ////Tipo VPN/ Histológico

                var SinRealizar = (lista.Where(x => x.IdTipoHistologico == 0).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CervicitisAguda = (lista.Where(x => x.IdDiagnosticoCitologico == 1).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CervicitisCronica = (lista.Where(x => x.IdDiagnosticoCitologico == 2).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var AtipiaCoilociticaSinDisplasia = (lista.Where(x => x.IdDiagnosticoCitologico == 3).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var NICI = (lista.Where(x => x.IdDiagnosticoCitologico == 4).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var NICII = (lista.Where(x => x.IdDiagnosticoCitologico == 5).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var NICIII = (lista.Where(x => x.IdDiagnosticoCitologico == 6).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CIS = (lista.Where(x => x.IdDiagnosticoCitologico == 7).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CarcinomaEscamoso = (lista.Where(x => x.IdDiagnosticoCitologico == 8).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var DisplasiaGlandularEndocervical = (lista.Where(x => x.IdDiagnosticoCitologico == 9).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var AdenocarcinomaTipo = (lista.Where(x => x.IdDiagnosticoCitologico == 10).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var OtrosTipo = (lista.Where(x => x.IdDiagnosticoCitologico == 11).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);



                //

                double CitologiasTotales = lista.Where(x => x.CitologiaVPH == true).ToList().Count();

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
                    double a = NegativoParaMalignidadTotal / CitologiasTotales * 100;
                    NegativoParaMalignidadCitologias = (NegativoParaMalignidadTotal / CitologiasTotales) * 100;
                    InflamacionleveCitologias = (InflamacionleveTotal / CitologiasTotales) * 100;
                    InflamacionModeradaCitologias = (InflamacionModeradaTotal / CitologiasTotales) * 100;
                    InflamacionSeveraCitologias = (InflamacionSeveraTotal / CitologiasTotales) * 100;
                    ASCUSCitologias = (ASCUSTotal / CitologiasTotales) * 100;
                    AGUSCitologias = (AGUSTotal / CitologiasTotales) * 100;
                    LIEBGCitologias = (LIEBGTotal / CitologiasTotales) * 100;
                    LIEAGCitologias = (LIEAGTotal / CitologiasTotales) * 100;
                    CarcinomaInvasorCitologias = (CarcinomaInvasorTotal / CitologiasTotales) * 100;
                    AdenocarcinomaCitologias = (AdenocarcinomaTotal / CitologiasTotales) * 100;
                    ASCHCitologias = (ASCHTotal / CitologiasTotales) * 100;
                    OtrosCitologias = (OtrosTotal / CitologiasTotales) * 100;
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

                return View(viewModel);
            }
            else
            {

                var viewModel = new AnaliticaViewModel();
                viewModel.FechaFin = analiticaViewModel.FechaFin;
                viewModel.FechaInicio = analiticaViewModel.FechaInicio;
                return View(viewModel);


            }
           
            //};
            //return View();
        }

        public ActionResult Index()
        {

            try
            {
                double cantidadTotal = db.Informe.ToList().Count;
                if (cantidadTotal != 0)
                {
                    var lista = db.Informe.OrderBy(x => x.FechaMuestra).ToList();

                    var fechaInicio = lista.FirstOrDefault().FechaMuestra;
                    var fechaFin = lista.LastOrDefault().FechaMuestra;


                    double HPVTotal = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Positivo).ToList().Count;

                    double NegativoParaMalignidadTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 1).ToList().Count());
                    double InflamacionleveTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 2).ToList().Count());
                    double InflamacionModeradaTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 3).ToList().Count());
                    double InflamacionSeveraTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 4).ToList().Count());
                    double ASCUSTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 5).ToList().Count());
                    double AGUSTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 6).ToList().Count());
                    double LIEBGTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 7).ToList().Count());
                    double LIEAGTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 8).ToList().Count());
                    double CarcinomaInvasorTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 9).ToList().Count());
                    double AdenocarcinomaTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 10).ToList().Count());
                    double ASCHTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 12).ToList().Count());
                    double OtrosTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 13).ToList().Count());


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


                    if (HPVTotal != 0)
                    {

                         NegativoParaMalignidad = (NegativoParaMalignidadTotal * 100) / HPVTotal;
                         Inflamacionleve = (InflamacionleveTotal * 100) / HPVTotal;
                         InflamacionModerada = (InflamacionModeradaTotal * 100) / HPVTotal;
                         InflamacionSevera = (InflamacionSeveraTotal * 100) / HPVTotal;
                         ASCUS = (ASCUSTotal * 100) / HPVTotal;
                         AGUS = (AGUSTotal * 100) / HPVTotal;
                         LIEBG = (LIEBGTotal * 100) / HPVTotal;
                         LIEAG = (LIEAGTotal * 100) / HPVTotal;
                         CarcinomaInvasor = (CarcinomaInvasorTotal * 100) / HPVTotal;
                         Adenocarcinoma = (AdenocarcinomaTotal * 100) / HPVTotal;
                         ASCH = (ASCHTotal * 100) / HPVTotal;
                         Otros = (OtrosTotal * 100) / HPVTotal;

                        ////Tipo VPN/ Histológico

                         SinRealizar = (db.Informe.Where(x => x.IdTipoHistologico == 0).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         CervicitisAguda = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 1).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         CervicitisCronica = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 2).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         AtipiaCoilociticaSinDisplasia = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 3).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         NICI = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 4).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         NICII = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 5).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         NICIII = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 6).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         CIS = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 7).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         CarcinomaEscamoso = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 8).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         DisplasiaGlandularEndocervical = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 9).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         AdenocarcinomaTipo = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 10).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                         OtrosTipo = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 11).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);


                    }




                    //

                    double CitologiasTotales = db.Informe.Where(x => x.CitologiaVPH == true).ToList().Count();

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
                        double a = NegativoParaMalignidadTotal / CitologiasTotales * 100;
                        NegativoParaMalignidadCitologias = (NegativoParaMalignidadTotal / CitologiasTotales) * 100;
                        InflamacionleveCitologias = (InflamacionleveTotal / CitologiasTotales) * 100;
                        InflamacionModeradaCitologias = (InflamacionModeradaTotal / CitologiasTotales) * 100;
                        InflamacionSeveraCitologias = (InflamacionSeveraTotal / CitologiasTotales) * 100;
                        ASCUSCitologias = (ASCUSTotal / CitologiasTotales) * 100;
                        AGUSCitologias = (AGUSTotal / CitologiasTotales) * 100;
                        LIEBGCitologias = (LIEBGTotal / CitologiasTotales) * 100;
                        LIEAGCitologias = (LIEAGTotal / CitologiasTotales) * 100;
                        CarcinomaInvasorCitologias = (CarcinomaInvasorTotal / CitologiasTotales) * 100;
                        AdenocarcinomaCitologias = (AdenocarcinomaTotal / CitologiasTotales) * 100;
                        ASCHCitologias = (ASCHTotal / CitologiasTotales) * 100;
                        OtrosCitologias = (OtrosTotal / CitologiasTotales) * 100;
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

                    return View(viewModel);
                }
                else
                {

                    var viewModel = new AnaliticaViewModel();
                    return View(viewModel);


                }
            }
            catch (Exception)
            {

                throw;
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