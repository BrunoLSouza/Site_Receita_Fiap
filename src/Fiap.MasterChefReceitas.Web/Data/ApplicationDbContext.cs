using System;
using System.Collections.Generic;
using System.Text;
using Fiap.MasterChefReceitas.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Fiap.MasterChefReceitas.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReceitaViewModel> Receitas { get; set; }
        public DbSet<PreparoViewModel> Preparos { get; set; }
        public DbSet<IngredienteViewModel> Ingredientes { get; set; }

    }
}
