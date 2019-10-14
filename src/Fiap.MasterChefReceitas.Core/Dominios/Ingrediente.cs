using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fiap.MasterChefReceitas.Core
{
    [Table("Ingredientes")]
    public class Ingrediente
    {
        [Key]
        public long IdIngrediente { get; set; }

        public string NomeIngrediente { get; set; }

        public int Quantidade { get; set; }

        [ForeignKey("IdReceita")]
        public long IdReceita { get; set; }
    }
}
