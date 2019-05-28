using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VilaItalia.Models;

namespace VilaItalia.Controllers
{
    public class Receita_IngredienteController : Controller
    {
        private VilaItaliaContext db = new VilaItaliaContext();

        // GET: Receita_Ingrediente
        public ActionResult Index()
        {
            var receita_Ingrediente = db.Receita_Ingrediente.Include(r => r.Ingrediente).Include(r => r.Receita);
            return View(receita_Ingrediente.ToList());
        }

        // GET: Receita_Ingrediente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita_Ingrediente receita_Ingrediente = db.Receita_Ingrediente.Find(id);
            if (receita_Ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(receita_Ingrediente);
        }

        // GET: Receita_Ingrediente/Create
        public ActionResult Create()
        {
            ViewBag.IngredienteId = new SelectList(db.Ingredientes, "IngredienteId", "Nome");
            ViewBag.ReceitaId = new SelectList(db.Receitas, "ReceitaId", "Nome");
            return View();
        }

        // POST: Receita_Ingrediente/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Receita_IngredienteId,IngredienteId,ReceitaId,PrecoM,PrecoG,PrecoF,QuantidadeM,QuantidadeG,QuantidadeF")] Receita_Ingrediente receita_Ingrediente,
            List<int> ingredienteId)
        {
            if (ModelState.IsValid)
            {
                foreach (var id in ingredienteId)
                {
                    receita_Ingrediente.IngredienteId = id ;
                    db.Receita_Ingrediente.Add(receita_Ingrediente);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index");
            }

            ViewBag.IngredienteId = new SelectList(db.Ingredientes, "IngredienteId", "Nome", receita_Ingrediente.IngredienteId);
            ViewBag.ReceitaId = new SelectList(db.Receitas, "ReceitaId", "Nome", receita_Ingrediente.ReceitaId);
            return View(receita_Ingrediente);
        }

        // GET: Receita_Ingrediente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita_Ingrediente receita_Ingrediente = db.Receita_Ingrediente.Find(id);
            if (receita_Ingrediente == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredienteId = new SelectList(db.Ingredientes, "IngredienteId", "Nome", receita_Ingrediente.IngredienteId);
            ViewBag.ReceitaId = new SelectList(db.Receitas, "ReceitaId", "Nome", receita_Ingrediente.ReceitaId);
            return View(receita_Ingrediente);
        }

        // POST: Receita_Ingrediente/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Receita_IngredienteId,IngredienteId,ReceitaId,PrecoM,PrecoG,PrecoF,QuantidadeM,QuantidadeG,QuantidadeF")] Receita_Ingrediente receita_Ingrediente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita_Ingrediente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredienteId = new SelectList(db.Ingredientes, "IngredienteId", "Nome", receita_Ingrediente.IngredienteId);
            ViewBag.ReceitaId = new SelectList(db.Receitas, "ReceitaId", "Nome", receita_Ingrediente.ReceitaId);
            return View(receita_Ingrediente);
        }

        // GET: Receita_Ingrediente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita_Ingrediente receita_Ingrediente = db.Receita_Ingrediente.Find(id);
            if (receita_Ingrediente == null)
            {
                return HttpNotFound();
            }
            return View(receita_Ingrediente);
        }

        // POST: Receita_Ingrediente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita_Ingrediente receita_Ingrediente = db.Receita_Ingrediente.Find(id);
            db.Receita_Ingrediente.Remove(receita_Ingrediente);
            db.SaveChanges();
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
