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
            //var cantidadTotal = db.Informe.Where(x =>
            //                                        (
            //                                         x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
            //                                         && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
            //                                         && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
            //                                        )

            //                                        &&

            //                                        (
            //                                         x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
            //                                         && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
            //                                         && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
            //                                        )
            //                                    )
            //                                     .ToList().Count;

            //if (cantidadTotal != 0)
            //{


            //    var positivo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Positivo &&
            //                                           (
            //                                             x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
            //                                             && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
            //                                             && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
            //                                            )

            //                                            &&

            //                                            (
            //                                             x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
            //                                             && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
            //                                             && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
            //                                            )
            //                                            ).ToList().Count;


            //    var negativo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Negativo &&
            //                                    (
            //                                                 x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
            //                                                 && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
            //                                                 && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
            //                                                )

            //                                                &&

            //                                                (
            //                                                 x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
            //                                                 && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
            //                                                 && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
            //                                                )
            //                                                ).ToList().Count;

            //    var indeterminado = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Indeterminado &&
            //                                           (
            //                                             x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
            //                                             && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
            //                                             && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
            //                                            )

            //                                            &&

            //                                            (
            //                                             x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
            //                                             && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
            //                                             && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
            //                                            )
            //                                            ).ToList().Count;

            //    var adecuada = db.Informe.Where(x => x.Valoracion.Descripcion == Constantes.Adecuadas &&
            //                                           (
            //                                             x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
            //                                             && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
            //                                             && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
            //                                            )

            //                                            &&

            //                                            (
            //                                             x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
            //                                             && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
            //                                             && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
            //                                            )
            //                                            ).ToList().Count;

            //    var porcientoPositivo = (positivo * 100) / cantidadTotal;

            //    var porcientoNegativo = (negativo * 100) / cantidadTotal;

            //    var porcientoIndeterminado = (indeterminado * 100) / cantidadTotal;

            //    var porcientoAdecuado = (adecuada * 100) / cantidadTotal;

            //    var viewModel = new AnaliticaViewModel
            //    {
            //        PorcientoAdecuadas = Convert.ToInt32(porcientoAdecuado),
            //        PorcientoIndeterminado = Convert.ToInt32(porcientoIndeterminado),
            //        PorcientoNegativo = Convert.ToInt32(porcientoNegativo),
            //        PorcientoPositivo = Convert.ToInt32(porcientoPositivo),
            //        FechaFin = analiticaViewModel.FechaFin,
            //        FechaInicio = analiticaViewModel.FechaInicio,

            //        Negativo = negativo,
            //        Positivo = positivo,
            //        Indeterminado = indeterminado,
            //        Adecuado = adecuada,
            //        Total = cantidadTotal,
            //    };
                return View(new AnaliticaViewModel());
            //};
            //return View();
        }

        public ActionResult Index()
        {

            double cantidadTotal = db.Informe.ToList().Count;
            if (cantidadTotal != 0)
            {
                var lista = db.Informe.OrderBy(x => x.FechaMuestra).ToList();

                var fechaInicio = lista.FirstOrDefault().FechaMuestra;
                var fechaFin = lista.LastOrDefault().FechaMuestra;


                double HPVTotal = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Positivo).ToList().Count;

                double NegativoParaMalignidadTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 1).ToList().Count() );
                double InflamacionleveTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 2).ToList().Count() );
                double InflamacionModeradaTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 3).ToList().Count() );
                double InflamacionSeveraTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 4).ToList().Count() );
                double ASCUSTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 5).ToList().Count() );
                double AGUSTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 6).ToList().Count() );
                double LIEBGTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 7).ToList().Count() );
                double LIEAGTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 8).ToList().Count() );
                double CarcinomaInvasorTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 9).ToList().Count() );
                double AdenocarcinomaTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 10).ToList().Count() );
                double ASCHTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 12).ToList().Count() );
                double OtrosTotal = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 13).ToList().Count() );



                double NegativoParaMalignidad = (NegativoParaMalignidadTotal * 100) / HPVTotal;
                double Inflamacionleve = (InflamacionleveTotal  * 100) / HPVTotal;
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

                var SinRealizar = (db.Informe.Where(x => x.IdTipoHistologico == 0).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CervicitisAguda = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 1).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CervicitisCronica = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 2).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var AtipiaCoilociticaSinDisplasia = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 3).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var NICI = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 4).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var NICII = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 5).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var NICIII = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 6).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CIS = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 7).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var CarcinomaEscamoso = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 8).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var DisplasiaGlandularEndocervical = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 9).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var AdenocarcinomaTipo = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 10).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);
                var OtrosTipo = (db.Informe.Where(x => x.IdDiagnosticoCitologico == 11).ToList().Count() * 100) / Convert.ToInt32(HPVTotal);



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