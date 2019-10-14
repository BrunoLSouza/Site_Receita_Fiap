using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fiap.MasterChefReceitas.Core
{
    [Table("Receitas")]
    public class Receita
    {
        [Key]
        public long IdReceita { get; set; }

        public string TituloReceita { get; set; }

        public int Rendimento { get; set; }

        public int TempoPreparo { get; set; }

        public List<Ingrediente> Ingredientes { get; set; }

        public Preparo Preparos { get; set; }
    }
}
