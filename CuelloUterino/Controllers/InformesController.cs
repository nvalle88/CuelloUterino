using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CuelloUterino;

namespace CuelloUterino.Controllers
{
    public class InformesController : Controller
    {
        private Model db = new Model();

        // GET: Informes
        public async Task<ActionResult> Index()
        {
            var informe = db.Informe.Include(i => i.Anticoncepcion).Include(i => i.DiagnosticoCitologico).Include(i => i.Edades).Include(i => i.EstudioSolicitado).Include(i => i.Fechas).Include(i => i.Material).Include(i => i.MuestraPieza).Include(i => i.Paridad).Include(i => i.ResultadoPruebaHibrida).Include(i => i.TipoHistologico).Include(i => i.TipoHistologico1).Include(i => i.Valoracion);
            return View(await informe.ToListAsync());
        }

        // GET: Informes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = await db.Informe.FindAsync(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            return View(informe);
        }

        // GET: Informes/Create
        public ActionResult Create()
        {
            ViewBag.idAnticoncepcion = new SelectList(db.Anticoncepcion, "idAnticoncepcion", "Descripcion");
            ViewBag.idDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "idDiagnosticoCitologico", "Descripcion");
            ViewBag.idEdades = new SelectList(db.Edades, "idEdades", "Descripcion");
            ViewBag.idEstudio = new SelectList(db.EstudioSolicitado, "idEstudio", "descripcion");
            ViewBag.idFechas = new SelectList(db.Fechas, "idFechas", "Descripcion");
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "Descripcion");
            ViewBag.idMuestraPieza = new SelectList(db.MuestraPieza, "idMuestraPieza", "Descripcion");
            ViewBag.idParidad = new SelectList(db.Paridad, "idParidad", "Descripcion");
            ViewBag.idResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "idResultadoPruebaHibrida", "Descripcion");
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion");
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion");
            ViewBag.idValoracion = new SelectList(db.Valoracion, "idValoracion", "Descripcion");
            return View();
        }

        // POST: Informes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "idInforme,nombres,apellidos,edad,fecha_muestra,identificacion,historia_clinica,telefono_convencional,telefono_celular,correo,nombres_apellidos_referencia,grado_afinidad,telefono,terapia_hormonal,recomendaciones,idEstudio,idMaterial,idAnticoncepcion,idEdades,idParidad,idFechas,idDiagnosticoCitologico,idValoracion,idResultadoPruebaHibrida,idMuestraPieza,idTipoHistologico")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                db.Informe.Add(informe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.idAnticoncepcion = new SelectList(db.Anticoncepcion, "idAnticoncepcion", "Descripcion", informe.idAnticoncepcion);
            ViewBag.idDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "idDiagnosticoCitologico", "Descripcion", informe.idDiagnosticoCitologico);
            ViewBag.idEdades = new SelectList(db.Edades, "idEdades", "Descripcion", informe.idEdades);
            ViewBag.idEstudio = new SelectList(db.EstudioSolicitado, "idEstudio", "descripcion", informe.idEstudio);
            ViewBag.idFechas = new SelectList(db.Fechas, "idFechas", "Descripcion", informe.idFechas);
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "Descripcion", informe.idMaterial);
            ViewBag.idMuestraPieza = new SelectList(db.MuestraPieza, "idMuestraPieza", "Descripcion", informe.idMuestraPieza);
            ViewBag.idParidad = new SelectList(db.Paridad, "idParidad", "Descripcion", informe.idParidad);
            ViewBag.idResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "idResultadoPruebaHibrida", "Descripcion", informe.idResultadoPruebaHibrida);
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion", informe.idTipoHistologico);
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion", informe.idTipoHistologico);
            ViewBag.idValoracion = new SelectList(db.Valoracion, "idValoracion", "Descripcion", informe.idValoracion);
            return View(informe);
        }

        // GET: Informes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = await db.Informe.FindAsync(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            ViewBag.idAnticoncepcion = new SelectList(db.Anticoncepcion, "idAnticoncepcion", "Descripcion", informe.idAnticoncepcion);
            ViewBag.idDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "idDiagnosticoCitologico", "Descripcion", informe.idDiagnosticoCitologico);
            ViewBag.idEdades = new SelectList(db.Edades, "idEdades", "Descripcion", informe.idEdades);
            ViewBag.idEstudio = new SelectList(db.EstudioSolicitado, "idEstudio", "descripcion", informe.idEstudio);
            ViewBag.idFechas = new SelectList(db.Fechas, "idFechas", "Descripcion", informe.idFechas);
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "Descripcion", informe.idMaterial);
            ViewBag.idMuestraPieza = new SelectList(db.MuestraPieza, "idMuestraPieza", "Descripcion", informe.idMuestraPieza);
            ViewBag.idParidad = new SelectList(db.Paridad, "idParidad", "Descripcion", informe.idParidad);
            ViewBag.idResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "idResultadoPruebaHibrida", "Descripcion", informe.idResultadoPruebaHibrida);
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion", informe.idTipoHistologico);
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion", informe.idTipoHistologico);
            ViewBag.idValoracion = new SelectList(db.Valoracion, "idValoracion", "Descripcion", informe.idValoracion);
            return View(informe);
        }

        // POST: Informes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idInforme,nombres,apellidos,edad,fecha_muestra,identificacion,historia_clinica,telefono_convencional,telefono_celular,correo,nombres_apellidos_referencia,grado_afinidad,telefono,terapia_hormonal,recomendaciones,idEstudio,idMaterial,idAnticoncepcion,idEdades,idParidad,idFechas,idDiagnosticoCitologico,idValoracion,idResultadoPruebaHibrida,idMuestraPieza,idTipoHistologico")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.idAnticoncepcion = new SelectList(db.Anticoncepcion, "idAnticoncepcion", "Descripcion", informe.idAnticoncepcion);
            ViewBag.idDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "idDiagnosticoCitologico", "Descripcion", informe.idDiagnosticoCitologico);
            ViewBag.idEdades = new SelectList(db.Edades, "idEdades", "Descripcion", informe.idEdades);
            ViewBag.idEstudio = new SelectList(db.EstudioSolicitado, "idEstudio", "descripcion", informe.idEstudio);
            ViewBag.idFechas = new SelectList(db.Fechas, "idFechas", "Descripcion", informe.idFechas);
            ViewBag.idMaterial = new SelectList(db.Material, "idMaterial", "Descripcion", informe.idMaterial);
            ViewBag.idMuestraPieza = new SelectList(db.MuestraPieza, "idMuestraPieza", "Descripcion", informe.idMuestraPieza);
            ViewBag.idParidad = new SelectList(db.Paridad, "idParidad", "Descripcion", informe.idParidad);
            ViewBag.idResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "idResultadoPruebaHibrida", "Descripcion", informe.idResultadoPruebaHibrida);
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion", informe.idTipoHistologico);
            ViewBag.idTipoHistologico = new SelectList(db.TipoHistologico, "idTipoHistologico", "Descripcion", informe.idTipoHistologico);
            ViewBag.idValoracion = new SelectList(db.Valoracion, "idValoracion", "Descripcion", informe.idValoracion);
            return View(informe);
        }

        // GET: Informes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Informe informe = await db.Informe.FindAsync(id);
            if (informe == null)
            {
                return HttpNotFound();
            }
            return View(informe);
        }

        // POST: Informes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Informe informe = await db.Informe.FindAsync(id);
            db.Informe.Remove(informe);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
