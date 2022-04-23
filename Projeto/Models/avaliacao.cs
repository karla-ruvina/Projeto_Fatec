using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class avaliacao
    {
        [Key]
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public virtual usuario ClienteAvaliacao { get; set; }
        public int IdReserva { get; set; }
        public virtual reserva ReservaAvaliacao { get; set; }
        public string Mensagem { get; set; }
    }
}