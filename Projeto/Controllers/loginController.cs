using Anexs.Lib.Extensoes;
using Projeto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Projeto.Controllers
{
    public class loginController : Controller
    {

        contexto db = new contexto();

        // GET: login
        public ActionResult Index(string msg = null, string ReturnUrl = null)
        {
            if (Models.Credential.Current.Id > 0)
            {
                return RedirectToAction("Index", "Home");
            }

            if (msg != null)
                ViewBag.Msg = msg;


            if (Url.IsLocalUrl(ReturnUrl) && !string.IsNullOrEmpty(ReturnUrl))
            {
                ViewBag.ReturnURL = ReturnUrl;
            }

            return View();
        }


        [HttpPost]
        public ActionResult Logar(string login, string senha, string ReturnURL = null)
        {
            string msg = "";
            int erro = 0;

            if (login == null || senha == null)
            {
                msg = "Preencha o login e senha.";
                erro = 1;
            }

            try
            {
                var infouser = db.Usuarios.SingleOrDefault(c => c.Senha == senha && c.Email.Trim() == login.Trim());

                if (infouser != null)
                {
                    FormsAuthentication.SignOut();

                    Models.Credential user = new Models.Credential(login, infouser.Nome, infouser.Id, infouser.TipoUsuario);

                    var authTicket = new FormsAuthenticationTicket(
                             1,                                    // version
                             JSON.Serialize<Models.Credential>(user),
                             DateTime.Now,                         // created
                             DateTime.Now.AddMinutes(60),          // expires
                             false,                                // persistent?
                             ""                                    // can be used to store roles
                             );

                    string encryptedTicket = FormsAuthentication.Encrypt(authTicket);

                    var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                    authCookie.Expires = DateTime.Now.AddDays(10);
                    Request.Cookies.Add(authCookie);
                    Response.Cookies.Add(authCookie);
                    HttpContext.Response.Cookies.Add(authCookie);
                    HttpContext.Request.Cookies.Add(authCookie);
                    string decodedUrl = "";

                    if (!string.IsNullOrEmpty(ReturnURL))
                        decodedUrl = Server.UrlDecode(ReturnURL);
                    if (!string.IsNullOrEmpty(ReturnURL) && Url.IsLocalUrl(decodedUrl))
                    {
                        return Redirect(decodedUrl);
                    }
                    else
                    {

                        return RedirectToAction("Index", "Home");
                    }

                }
                else
                {
                    msg = "Usuário não encontrado";
                    erro = 1;
                    return RedirectToAction("Index", "Login", new { msg = msg, erro = erro, ReturnUrl = ReturnURL });
                }

            }
            catch (Exception ex)
            {
                msg = ex.Message;
                erro = 1;
            }

            return RedirectToAction("Index", "Login", new { msg = msg, erro = erro, ReturnUrl = ReturnURL });

        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

    }
}