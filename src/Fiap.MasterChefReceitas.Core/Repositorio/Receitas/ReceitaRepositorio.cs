﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Fiap.MasterChefReceitas.Core
{
    public class ReceitaRepositorio : IReceitaRepositorio
    {
        private ApplicationDbContext _context;

        public ReceitaRepositorio(ApplicationDbContext context)
        {
            _context = context;
        }

        public virtual void Salvar(Receita obj)
        {
            var returnObj = _context.Receitas.Add(obj);
            _context.SaveChanges();
        }

        public Receita ObterPorId(long id)
        {
            return _context.Receitas.Include(r => r.Ingredientes).Where(r => r.IdReceita == id).FirstOrDefault();
        }

        public IEnumerable<Receita> ObterTodosPaginado(int t, int s)
        {
            return _context.Receitas.Take(t).Skip(s).ToList();
        }

        public virtual Receita Alterar(Receita obj)
        {
            try
            {
                _context.Ingredientes.RemoveRange(_context.Ingredientes.Where(p => p.IdReceita == obj.IdReceita));
                //_context.Preparos.RemoveRange(_context.Preparos.Where(p => p.IdReceita == obj.IdReceita));
                obj.Ingredientes.ForEach(
                    p => p.IdIngrediente = 0
                    );
                //obj.Preparos.IdPreparo = 0;
                var entry = _context.Entry(obj);
                _context.Receitas.Attach(obj);
                entry.State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

            }


            return obj;
        }

        public virtual bool Remover(long id)
        {
            _context.Ingredientes.RemoveRange(_context.Ingredientes.Where(p => p.IdReceita == id));
            _context.Receitas.Remove(_context.Receitas.Find(id));
            _context.SaveChanges();

            var existe = VerificaExiste(id);
            return !existe;
        }

        public bool VerificaExiste(long id)
        {
            return _context.Receitas.Any(e => e.IdReceita == id);
        }

    }
}
