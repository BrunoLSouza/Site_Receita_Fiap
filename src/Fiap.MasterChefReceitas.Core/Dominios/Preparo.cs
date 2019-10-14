using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Fiap.MasterChefReceitas.Core
{
    [Table("Preparos")]
    public class Preparo
    {
        [Key]
        public long IdPreparo { get; set; }
        
        public string Instrucoes { get; set; }

        [ForeignKey("IdReceita")]
        public long IdReceita { get; set; }
    }
}
