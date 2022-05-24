using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projeto.Controllers
{
    public class HomeController : Controller
    {
        private contexto db = new contexto();

        public ActionResult Index()
        {
            var lista = (from i in db.Imoveis
                         select new
                         {
                             i.Id,
                             i.TipoImovel,
                             i.ValorDiaria,
                             i.BreveDescricao,
                             i.Cidade,
                             i.Estado,
                             i.Tamanho,
                             i.QtdQuartos,
                             i.QtdBanheiros
                         }).ToList()
                             .Select(c => new imovel
                             {
                                 Id = c.Id,
                                 TipoImovel = c.TipoImovel,
                                 ValorDiaria = c.ValorDiaria,
                                 BreveDescricao = c.BreveDescricao,
                                 Cidade = c.Cidade,
                                 Estado = c.Estado,
                                 Tamanho = c.Tamanho,
                                 QtdQuartos = c.QtdQuartos,
                                 QtdBanheiros = c.QtdBanheiros,

                             }).ToList().Take(3);

            return View(lista);
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