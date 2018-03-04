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
            ViewBag.IdAnticoncepcion = new SelectList(db.Anticoncepcion, "IdAnticoncepcion", "Descripcion");
            ViewBag.IdDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "IdDiagnosticoCitologico", "Descripcion");
            ViewBag.IdEdades = new SelectList(db.Edades, "IdEdades", "Descripcion");
            ViewBag.IdEstudio = new SelectList(db.EstudioSolicitado, "IdEstudio", "descripcion");
            ViewBag.IdFechas = new SelectList(db.Fechas, "IdFechas", "Descripcion");
            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Descripcion");
            ViewBag.IdMuestraPieza = new SelectList(db.MuestraPieza, "IdMuestraPieza", "Descripcion");
            ViewBag.IdParidad = new SelectList(db.Paridad, "IdParidad", "Descripcion");
            ViewBag.IdResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "IdResultadoPruebaHibrida", "Descripcion");
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion");
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion");
            ViewBag.IdValoracion = new SelectList(db.Valoracion, "IdValoracion", "Descripcion");
            return View();
        }

        // POST: Informes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Informe informe)
        {
            if (ModelState.IsValid)
            {
                db.Informe.Add(informe);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.IdAnticoncepcion = new SelectList(db.Anticoncepcion, "IdAnticoncepcion", "Descripcion", informe.IdAnticoncepcion);
            ViewBag.IdDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "IdDiagnosticoCitologico", "Descripcion", informe.IdDiagnosticoCitologico);
            ViewBag.IdEdades = new SelectList(db.Edades, "IdEdades", "Descripcion", informe.IdEdades);
            ViewBag.IdEstudio = new SelectList(db.EstudioSolicitado, "IdEstudio", "descripcion", informe.IdEstudio);
            ViewBag.IdFechas = new SelectList(db.Fechas, "IdFechas", "Descripcion", informe.IdFechas);
            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Descripcion", informe.IdMaterial);
            ViewBag.IdMuestraPieza = new SelectList(db.MuestraPieza, "IdMuestraPieza", "Descripcion", informe.IdMuestraPieza);
            ViewBag.IdParidad = new SelectList(db.Paridad, "IdParidad", "Descripcion", informe.IdParidad);
            ViewBag.IdResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "IdResultadoPruebaHibrida", "Descripcion", informe.IdResultadoPruebaHibrida);
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion", informe.IdTipoHistologico);
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion", informe.IdTipoHistologico);
            ViewBag.IdValoracion = new SelectList(db.Valoracion, "IdValoracion", "Descripcion", informe.IdValoracion);
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
            ViewBag.IdAnticoncepcion = new SelectList(db.Anticoncepcion, "IdAnticoncepcion", "Descripcion", informe.IdAnticoncepcion);
            ViewBag.IdDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "IdDiagnosticoCitologico", "Descripcion", informe.IdDiagnosticoCitologico);
            ViewBag.IdEdades = new SelectList(db.Edades, "IdEdades", "Descripcion", informe.IdEdades);
            ViewBag.IdEstudio = new SelectList(db.EstudioSolicitado, "IdEstudio", "descripcion", informe.IdEstudio);
            ViewBag.IdFechas = new SelectList(db.Fechas, "IdFechas", "Descripcion", informe.IdFechas);
            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Descripcion", informe.IdMaterial);
            ViewBag.IdMuestraPieza = new SelectList(db.MuestraPieza, "IdMuestraPieza", "Descripcion", informe.IdMuestraPieza);
            ViewBag.IdParidad = new SelectList(db.Paridad, "IdParidad", "Descripcion", informe.IdParidad);
            ViewBag.IdResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "IdResultadoPruebaHibrida", "Descripcion", informe.IdResultadoPruebaHibrida);
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion", informe.IdTipoHistologico);
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion", informe.IdTipoHistologico);
            ViewBag.IdValoracion = new SelectList(db.Valoracion, "IdValoracion", "Descripcion", informe.IdValoracion);
            return View(informe);
        }

        // POST: Informes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "idInforme,Nombres,Apellidos,edad,TelefonoCelular,Identificacion,historiaclinica,TelefonoConvencional,TelefonoCelular,Correo,NombresApellidosReferencia,GradoAfinidad,Telefono,terapia_hormonal,Recomendaciones,IdEstudio,IdMaterial,IdAnticoncepcion,IdEdades,IdParidad,IdFechas,IdDiagnosticoCitologico,IdValoracion,IdResultadoPruebaHibrida,IdMuestraPieza,IdTipoHistologico")] Informe informe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(informe).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.IdAnticoncepcion = new SelectList(db.Anticoncepcion, "IdAnticoncepcion", "Descripcion", informe.IdAnticoncepcion);
            ViewBag.IdDiagnosticoCitologico = new SelectList(db.DiagnosticoCitologico, "IdDiagnosticoCitologico", "Descripcion", informe.IdDiagnosticoCitologico);
            ViewBag.IdEdades = new SelectList(db.Edades, "IdEdades", "Descripcion", informe.IdEdades);
            ViewBag.IdEstudio = new SelectList(db.EstudioSolicitado, "IdEstudio", "descripcion", informe.IdEstudio);
            ViewBag.IdFechas = new SelectList(db.Fechas, "IdFechas", "Descripcion", informe.IdFechas);
            ViewBag.IdMaterial = new SelectList(db.Material, "IdMaterial", "Descripcion", informe.IdMaterial);
            ViewBag.IdMuestraPieza = new SelectList(db.MuestraPieza, "IdMuestraPieza", "Descripcion", informe.IdMuestraPieza);
            ViewBag.IdParidad = new SelectList(db.Paridad, "IdParidad", "Descripcion", informe.IdParidad);
            ViewBag.IdResultadoPruebaHibrida = new SelectList(db.ResultadoPruebaHibrida, "IdResultadoPruebaHibrida", "Descripcion", informe.IdResultadoPruebaHibrida);
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion", informe.IdTipoHistologico);
            ViewBag.IdTipoHistologico = new SelectList(db.TipoHistologico, "IdTipoHistologico", "Descripcion", informe.IdTipoHistologico);
            ViewBag.IdValoracion = new SelectList(db.Valoracion, "IdValoracion", "Descripcion", informe.IdValoracion);
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
