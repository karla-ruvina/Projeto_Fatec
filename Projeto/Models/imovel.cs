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
        public string BreveDescricao { get; set; }
        public string CpfCnpj { get; set; }
        public string Cep { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Numero { get; set; }
        public double ValorDiaria { get; set; }
        public int IdProprietario { get; set; }
        public string TipoImovel { get; set; }
        public int QtdQuartos { get; set; }
        public int QtdBanheiros { get; set; }
        public int Tamanho { get; set; }
        public virtual usuario UsuarioProprietario { get; set; }
    }
}