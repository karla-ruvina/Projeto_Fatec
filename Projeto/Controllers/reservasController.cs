using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Anexs.Lib.Extensoes;
using Projeto.Models;

namespace Projeto.Controllers
{
    public class reservasController : Controller
    {
        private contexto db = new contexto();

        // GET: reservas
        public ActionResult Index()
        {
            return View(db.Reservas.ToList());
        }

        // GET: reservas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // GET: reservas/Create
        public ActionResult Create(int idImovel)
        {
            var imb = db.Imoveis.First(c => c.Id == idImovel);

            ViewBag.NomeImovel = imb.BreveDescricao;
            ViewBag.Cidade = imb.Cidade;
            ViewBag.Estado = imb.Estado;
            ViewBag.Imovel = idImovel;
            ViewBag.ValorDiaria = imb.ValorDiaria.ToString().Replace(",", ".");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(reserva model)
        {
            try
            {
                var obj = model.Id > 0 ? db.Reservas.SingleOrDefault(c => c.Id == model.Id) : new reserva();
                obj.DataInicial = model.DataInicial;
                obj.DataFinal = model.DataFinal;
                obj.IdImovel = model.IdImovel;
                obj.IdCliente = Models.Credential.Current.Id;
                obj.ValorTotal = model.ValorTotal;

                if (obj.Id == 0)
                {
                    db.Reservas.Add(obj);
                }
                db.SaveChanges();

                return RedirectToAction("Index", new { id = Models.Credential.Current.Id });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Create", model);
            }

        }

        // GET: reservas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: reservas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataInicial,DataFinal,Ticket,ValorTotal,IdImovel,IdCliente")] reserva reserva)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reserva).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reserva);
        }

        // GET: reservas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            reserva reserva = db.Reservas.Find(id);
            if (reserva == null)
            {
                return HttpNotFound();
            }
            return View(reserva);
        }

        // POST: reservas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            reserva reserva = db.Reservas.Find(id);
            db.Reservas.Remove(reserva);
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

        public JsonResult VerificarAgenda(DateTime datainicio, DateTime datafim, int idImovel = 0)
        {
            var horario = db.Reservas.Where(c =>
            c.IdImovel == idImovel).ToList();
            
            horario = horario.Where(c => c.DataInicial.ToDate() <= datainicio && c.DataFinal.ToDate() >= datafim).ToList();

            if (horario.Count() > 0)
            {
                var exists = true;

                return Json(exists, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var exists = false;
                return Json(exists, JsonRequestBehavior.AllowGet);

            }
        }
    }
}
