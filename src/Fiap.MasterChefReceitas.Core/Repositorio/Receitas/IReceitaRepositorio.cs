using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Core
{
    public interface IReceitaRepositorio
    {
        void Salvar(Receita obj);
        Receita ObterPorId(long id);
        IEnumerable<Receita> ObterTodosPaginado(int t, int s);
        Receita Alterar(Receita obj);
        bool VerificaExiste(long id);
        bool Remover(long id);
    }
}
