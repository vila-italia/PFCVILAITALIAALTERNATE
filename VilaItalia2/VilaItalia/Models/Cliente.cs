using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VilaItalia.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Celular { get; set; }
        public string CPF { get; set; }
        public int Dia_Aniversario { get; set; }
        public int Mes_Aniversario { get; set; }
        public string Email { get; set; }
        public string CEP { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public string Cidade { get; set; }
        public string Complemento { get; set; }
        public string Referencia { get; set; }
        public string Observacao { get; set; }
    }
}