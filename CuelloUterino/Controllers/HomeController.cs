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

        public ActionResult Index()
        {
            var fechaActual = DateTime.Now;

           var cantidadTotal= db.Informe.ToList().Count;

           // var positivo=db.Informe.Where(x=>x.)
           var muestrasDiario= db.Informe.Where(x => x.FechaMuestra.Day == fechaActual.Day 
                                        && x.FechaMuestra.Month == fechaActual.Month 
                                        && x.FechaMuestra.Year == fechaActual.Year)
                                        .ToList().Count;

            var muestrasMensual = db.Informe.Where(x=>x.FechaMuestra.Month == fechaActual.Month
                                                   && x.FechaMuestra.Year == fechaActual.Year)
                                                   .ToList().Count;

            var muestrasAnual = db.Informe.Where(x =>x.FechaMuestra.Year == fechaActual.Year)
                                                 .ToList().Count;



            var positivo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion ==Constantes.Positivo).ToList().Count;

            var negativo = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Negativo).ToList().Count;

            var indeterminado = db.Informe.Where(x => x.ResultadoPruebaHibrida.Descripcion == Constantes.Indeterminado).ToList().Count;

            var adecuada = db.Informe.Where(x => x.Valoracion.Descripcion == Constantes.Adecuadas).ToList().Count;

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

                Negativo=negativo,
                Positivo=positivo,
                Indeterminado=indeterminado,
                Adecuado=adecuada,

                Anual=muestrasAnual,
                Diario=muestrasDiario,
                Mensual=muestrasMensual,
                Total=cantidadTotal,
            };
            return View(viewModel);
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