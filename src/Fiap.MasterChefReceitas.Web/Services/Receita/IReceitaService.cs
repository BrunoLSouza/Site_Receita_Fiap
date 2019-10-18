using Fiap.MasterChefReceitas.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Services
{
    public interface IReceitaService
    {
       Task<List<ReceitaViewModel>> ObterReceitasPaginado(int skip, int take);

       Task<ReceitaViewModel> ObterReceitaPorId(long idReceita);

       Task AdicionarReceita(ReceitaViewModel receita);

        void DeletarReceita(long idReceita);

        Task AlterarReceita(ReceitaViewModel receita);
       
        
    }
}
