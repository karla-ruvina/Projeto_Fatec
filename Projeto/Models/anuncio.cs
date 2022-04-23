using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class anuncio
    {
        [Key]
        public int Id { get; set; }
        public string InfoImovel { get; set; }
        public virtual imovel ImovelAnuncio { get; set; }
    }
}