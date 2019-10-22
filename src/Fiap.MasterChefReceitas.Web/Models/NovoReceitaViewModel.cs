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

        public string TituloReceita { get; set; }

        public int Rendimento { get; set; }

        public int TempoPreparo { get; set; }

        public string IngredientesTexto { get; set; }

        public List<IngredienteViewModel> Ingredientes { get; set; }

        [NotMapped]
        public string Preparo { get; set; }

        public PreparoViewModel Preparos { get; set; }
    }
}
