using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class imovelsController : Controller
    {
        private contexto db = new contexto();

        // GET: imovels
        public ActionResult Index()
        {
            return View(db.Imoveis.ToList());
        }

        // GET: imovels
        public ActionResult List()
        {
            return View(db.Imoveis.ToList());
        }

        // GET: imovels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imovel imovel = db.Imoveis.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            return View(imovel);
        }

        // GET: imovels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: imovels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,CpfCnpj,Cep,Estado,Cidade,Rua,Bairro,Numero,ValorDiaria,IdProprietario")] imovel imovel)
        {
            if (ModelState.IsValid)
            {
                db.Imoveis.Add(imovel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imovel);
        }

        // GET: imovels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imovel imovel = db.Imoveis.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            return View(imovel);
        }

        // POST: imovels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,CpfCnpj,Cep,Estado,Cidade,Rua,Bairro,Numero,ValorDiaria,IdProprietario")] imovel imovel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imovel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imovel);
        }

        // GET: imovels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            imovel imovel = db.Imoveis.Find(id);
            if (imovel == null)
            {
                return HttpNotFound();
            }
            return View(imovel);
        }

        // POST: imovels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            imovel imovel = db.Imoveis.Find(id);
            db.Imoveis.Remove(imovel);
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
