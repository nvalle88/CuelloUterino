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
    [Authorize]
    public class HomeController : Controller
    {
        private Model db = new Model();

        [HttpPost]
        public ActionResult Index(AnaliticaViewModel analiticaViewModel)
        {
            var cantidadTotal = db.Informe.Where(x=>
                                                    (
                                                     x.FechaMuestra.Year>=analiticaViewModel.FechaInicio.Year
                                                     && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
                                                     && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
                                                    )
                                                
                                                    &&
                                                
                                                    (
                                                     x.FechaMuestra.Year<=analiticaViewModel.FechaFin.Year
                                                     && x.FechaMuestra.Month<=analiticaViewModel.FechaFin.Month
                                                     && x.FechaMuestra.Day <=analiticaViewModel.FechaFin.Day
                                                    )
                                                )
                                                 .ToList().Count;

            if (cantidadTotal!=0)
            {


                var positivo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Positivo &&
                                                       (
                                                         x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
                                                         && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
                                                         && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
                                                        )

                                                        &&

                                                        (
                                                         x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
                                                         && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
                                                         && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
                                                        )
                                                        ).ToList().Count;
                                            

            var negativo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Negativo &&
                                            (
                                                         x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
                                                         && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
                                                         && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
                                                        )

                                                        &&

                                                        (
                                                         x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
                                                         && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
                                                         && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
                                                        )
                                                        ).ToList().Count;

                var indeterminado = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Indeterminado &&
                                                       (
                                                         x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
                                                         && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
                                                         && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
                                                        )

                                                        &&

                                                        (
                                                         x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
                                                         && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
                                                         && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
                                                        )
                                                        ).ToList().Count;

                var adecuada = db.Informe.Where(x => x.Valoracion.Descripcion == Constantes.Adecuadas &&
                                                       (
                                                         x.FechaMuestra.Year >= analiticaViewModel.FechaInicio.Year
                                                         && x.FechaMuestra.Month >= analiticaViewModel.FechaInicio.Month
                                                         && x.FechaMuestra.Day >= analiticaViewModel.FechaInicio.Day
                                                        )

                                                        &&

                                                        (
                                                         x.FechaMuestra.Year <= analiticaViewModel.FechaFin.Year
                                                         && x.FechaMuestra.Month <= analiticaViewModel.FechaFin.Month
                                                         && x.FechaMuestra.Day <= analiticaViewModel.FechaFin.Day
                                                        )
                                                        ).ToList().Count;

                var porcientoPositivo = (positivo * 100) / cantidadTotal;

            var porcientoNegativo = (negativo * 100) / cantidadTotal;

            var porcientoIndeterminado = (indeterminado * 100) / cantidadTotal;

            var porcientoAdecuado = (adecuada * 100) / cantidadTotal;

            var viewModel = new AnaliticaViewModel
            {
                PorcientoAdecuadas = Convert.ToInt32(porcientoAdecuado),
                PorcientoIndeterminado = Convert.ToInt32(porcientoIndeterminado),
                PorcientoNegativo = Convert.ToInt32(porcientoNegativo),
                PorcientoPositivo = Convert.ToInt32(porcientoPositivo),
                FechaFin = analiticaViewModel.FechaFin,
                FechaInicio = analiticaViewModel.FechaInicio,

                Negativo = negativo,
                Positivo = positivo,
                Indeterminado = indeterminado,
                Adecuado = adecuada,
                Total = cantidadTotal,
            };
            return View(viewModel);
            };
            return View(analiticaViewModel);
        }

        public ActionResult Index()
        {

            var cantidadTotal = db.Informe.ToList().Count;
            if (cantidadTotal!=0)
            {
                

                var positivo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Positivo).ToList().Count;

                var negativo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Negativo).ToList().Count;

                var indeterminado = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Indeterminado).ToList().Count;

                var adecuada = db.Informe.Where(x => x.Valoracion.Descripcion == Constantes.Adecuadas).ToList().Count;

                var porcientoPositivo = (positivo * 100) / cantidadTotal;

                var porcientoNegativo = (negativo * 100) / cantidadTotal;

                var porcientoIndeterminado = (indeterminado * 100) / cantidadTotal;

                var porcientoAdecuado = (adecuada * 100) / cantidadTotal;


                var fechaFin1 = DateTime.Now.Date;
                var fechaInicio1 = fechaFin1.AddMonths(-1);
                var viewModel = new AnaliticaViewModel
                {
                    PorcientoAdecuadas = Convert.ToInt32(porcientoAdecuado),
                    PorcientoIndeterminado = Convert.ToInt32(porcientoIndeterminado),
                    PorcientoNegativo = Convert.ToInt32(porcientoNegativo),
                    PorcientoPositivo = Convert.ToInt32(porcientoPositivo),
                    FechaFin = DateTime.Now.Date,
                    FechaInicio = fechaInicio1,

                    Negativo = negativo,
                    Positivo = positivo,
                    Indeterminado = indeterminado,
                    Adecuado = adecuada,

                    Total = cantidadTotal,
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