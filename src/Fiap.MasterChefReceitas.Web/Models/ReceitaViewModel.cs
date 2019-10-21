﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Models
{
    public class ReceitaViewModel
    {
        [Key]
        public long IdReceita { get; set; }

        public string TituloReceita { get; set; }

        public int Rendimento { get; set; }

        public int TempoPreparo { get; set; }

        public List<IngredienteViewModel> Ingredientes { get; set; }

        public PreparoViewModel Preparos { get; set; }
    }
}