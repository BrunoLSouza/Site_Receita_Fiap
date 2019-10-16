using Microsoft.EntityFrameworkCore;
using System;
using System.Text;

namespace Fiap.MasterChefReceitas.Core
{
    public class RepositorioBase
    {
        //protected ApplicationDbContext Db;
        //protected DbSet<TEntity> DbSet;

        //public RepositorioBase()
        //{
        //    Db = new ApplicationDbContext();
        //    DbSet = Db.Set<TEntity>();
        //}

        //public virtual TEntity Salvar(TEntity obj)
        //{
        //    var returnObj = DbSet.Add(obj);
        //    SaveChanges();

        //    return returnObj;
        //}

        //public virtual TEntity ObterPorId(int id)
        //{
        //    return DbSet.Find(id);
        //}

        //public IEnumerable<TEntity> ObterTodosPaginado(int t, int s)
        //{
        //    return DbSet.Take(t).Skip(s).ToList();
        //}

        //public virtual IEnumerable<TEntity> ObterTodos()
        //{
        //    return DbSet.ToList();
        //}

        //public virtual TEntity Alterar(TEntity obj)
        //{
        //    var entry = Db.Entry(obj);
        //    DbSet.Attach(obj);
        //    entry.State = EntityState.Modified;
        //    SaveChanges();

        //    return obj;
        //}

        //public virtual void Remover(int id)
        //{
        //    DbSet.Remove(DbSet.Find(id));
        //    SaveChanges();
        //}

        //public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return DbSet.Where(predicate);
        //}

        //public int SaveChanges()
        //{
        //    return Db.SaveChanges();
        //}

        //public void Dispose()
        //{
        //    Db.Dispose();
        //    GC.SuppressFinalize(this);
        //}
    }
}
