using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Models
{
    public class IngredienteViewModel
    {
        [Key]
        public long IdIngrediente { get; set; }

        public string NomeIngrediente { get; set; }

        public int Quantidade { get; set; }
    }
}
