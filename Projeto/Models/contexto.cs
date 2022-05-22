using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class contexto : DbContext
    {

        public contexto() : base("Database1")
        {

        }

        public DbSet<imovel> Imoveis { get; set; }
        public DbSet<usuario> Usuarios { get; set; }
        public DbSet<reserva> Reservas { get; set; }
        public DbSet<anuncio> Anuncios { get; set; }
        public DbSet<avaliacao> Avaliacaos { get; set; }
    }
}