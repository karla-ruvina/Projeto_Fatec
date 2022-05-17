//using Anexs.Lib.Extensoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class Credential
    {

        public Credential() { }

        public Credential(string login, string nome, int id)
            : this()
        {
            this.Login = login;
            this.Nome = nome;
            this.Id = id;

        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }

        //public static Credential Current
        //{
        //    get
        //    {
        //        if (HttpContext.Current != null && HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.Name != "")
        //            return JSON.Deserialize<Credential>(HttpContext.Current.User.Identity.Name);
        //        return new Credential();
        //    }
        //}

        public static class CustomRoles
        {
            public const string Administrator = "ADM";
            public const string User = "Customer";
            public const string AdministratorOrUser = Administrator + "," + User;
        }

    }
}