﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Fiap.MasterChefReceitas.Core;
using Microsoft.AspNetCore.Authorization;

namespace Fiap.MasterChefReceitas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private IReceitaRepositorio _receitaRepositorio;

        public ReceitasController(ApplicationDbContext context)
        {
            _receitaRepositorio = new ReceitaRepositorio(context);
        }

        // GET: api/Receitas
        [HttpGet("{id}/{id2}")]
        public async Task<ActionResult<IEnumerable<Receita>>> GetReceitas(int id, int id2)
        {
            // skip = pula - take = pegar
            return _receitaRepositorio.ObterTodosPaginado(id2,id).ToList();
        }

        // GET: api/Receitas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receita>> GetReceita(long id)
        {
            var receita = _receitaRepositorio.ObterPorId(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // PUT: api/Receitas/5
        [HttpPut("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> PutReceita(long id, Receita receita)
        {
            if (id != receita.IdReceita)
            {
                return BadRequest();
            }
            
            try
            {
                _receitaRepositorio.Alterar(receita);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Receitas
        [HttpPost]
        [Authorize("Bearer")]
        public async Task<ActionResult<Receita>> PostReceita(Receita receita)
        {
            _receitaRepositorio.Salvar(receita);

            return CreatedAtAction("GetReceita", new { id = receita.IdReceita }, receita);
        }

        //// DELETE: api/Receitas/5
        [HttpDelete("{id}")]
        [Authorize("Bearer")]
        public async Task<IActionResult> DeleteReceita(long id)
        {
            var existe = _receitaRepositorio.VerificaExiste(id);
            if (!existe)
            {
                return NotFound();
            }

            var excluido = _receitaRepositorio.Remover(id);

            return NoContent();
        }

        private bool ReceitaExists(long id)
        {
            return _receitaRepositorio.VerificaExiste(id);
        }
    }
}
