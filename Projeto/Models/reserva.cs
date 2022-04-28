using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class reserva
    {
        [Key]
        public int Id { get; set; }
        public string DataInicial { get; set; }
        public string DataFinal { get; set; }
        public int Ticket { get; set; }
        public double ValorTotal { get; set; }
        public int IdImovel { get; set; }
        public virtual imovel ImovelReserva { get; set; }
        public int IdCliente { get; set; }
        public virtual usuario ClienteReserva { get; set; }
    }
}