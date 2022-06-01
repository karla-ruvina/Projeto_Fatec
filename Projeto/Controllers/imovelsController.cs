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
        public ActionResult Index(int? id)
        {
            return View(db.Imoveis.Where(c=> c.IdProprietario == id).ToList());
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
        public ActionResult Salvar(imovel model)
        {
            try
            {
                var obj = model.Id > 0 ? db.Imoveis.SingleOrDefault(c => c.Id == model.Id) : new imovel();
                obj.Descricao = model.Descricao;
                obj.BreveDescricao = model.BreveDescricao;
                obj.Cep = model.Cep;
                obj.Estado = model.Estado;
                obj.Cidade = model.Cidade;
                obj.Rua = model.Rua;
                obj.Bairro = model.Bairro;
                obj.Numero = model.Numero;
                obj.ValorDiaria = model.ValorDiaria;
                obj.IdProprietario = Credential.Current.Id;
                obj.TipoImovel = model.TipoImovel;
                obj.QtdQuartos = model.QtdQuartos;
                obj.QtdBanheiros = model.QtdBanheiros;
                obj.Tamanho = model.Tamanho;

                if (obj.Id == 0)
                {
                    db.Imoveis.Add(obj);
                }
                db.SaveChanges();

                return RedirectToAction("Index", new { id = Credential.Current.Id});
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return RedirectToAction("Create", model);
            }
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
