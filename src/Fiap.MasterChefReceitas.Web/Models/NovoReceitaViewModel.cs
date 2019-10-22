using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Models
{
    public class NovoReceitaViewModel
    {
        [Key]
        public long IdReceita { get; set; }
        [MinLength(3, ErrorMessage = "A receita precisa ter no minimo 3 caracteres")]
        public string TituloReceita { get; set; }
        [Range(0.0, int.MaxValue, ErrorMessage = "Valor Invalido")]
        public int Rendimento { get; set; }
        [Range(0.0, int.MaxValue, ErrorMessage = "Valor Invalido")]
        public int TempoPreparo { get; set; }

        public string IngredientesTexto { get; set; }
        [NotMapped]
        public string Preparo { get; set; }

        public PreparoViewModel Preparos { get; set; }
    }
}
