using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Models
{
    public class PreparoViewModel
    {
        [Key]
        public long IdPreparo { get; set; }

        public string Instrucoes { get; set; }
    }
}
