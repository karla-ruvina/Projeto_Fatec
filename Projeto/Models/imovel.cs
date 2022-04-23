using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Models
{
    public class imovel
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int CpfCnpj { get; set; }
        public int Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public double ValorDiaria { get; set; }
        public int IdProprietario { get; set; }
        public virtual usuario UsuarioProprietario { get; set; }
    }
}