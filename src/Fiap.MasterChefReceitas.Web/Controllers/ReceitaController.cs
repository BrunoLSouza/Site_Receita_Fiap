using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fiap.MasterChefReceitas.Web.Models;
using Fiap.MasterChefReceitas.Web.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Fiap.MasterChefReceitas.Web.Controllers
{
    [Authorize]
    public class ReceitaController : Controller
    {
        private readonly ReceitaService _receitaService;

        public ReceitaController(ReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        // GET: Receita
        //public async Task<IActionResult> Index()
        //{
        //    var listaReceita = await _receitaService.ObterReceitasPaginado(0, 4);
        //    return View(listaReceita.ToList());
        //}
        
        // GET: Receita/Details/5
        public async Task<IActionResult> Detalhe(long id)
        {
            var receita = await _receitaService.ObterReceitaPorId(id);
            return View(receita);
        }

        // GET: Receita/Create
        public async Task<IActionResult> Novo()
        {
            return View();
        }

        // POST: Receita/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Novo(NovoReceitaViewModel receita)
        {
            try
            {
                // TODO: Add insert logic here
                if (receita != null)
                {
                    var data = receita.IngredientesTexto.Split("|");
                    var ingredientes = new List<IngredienteViewModel>();

                    foreach (var opcao in data)
                    {
                        var item = opcao.Split(",");
                        ingredientes.Add(new IngredienteViewModel() { NomeIngrediente = item[0], Quantidade = item[1]});
                    }

                    //var receitaViewModel = new ReceitaViewModel();

                    //receitaViewModel.TituloReceita = collection["TituloReceita"];
                    //receitaViewModel.Rendimento = Convert.ToInt32(collection["Rendimento"]);
                    //receitaViewModel.TempoPreparo = Convert.ToInt32(collection["TempoPreparo"]);

                    var receitaVM = new ReceitaViewModel()
                    {
                        TituloReceita = receita.TituloReceita,
                        Rendimento = receita.Rendimento,
                        TempoPreparo = receita.TempoPreparo,
                        Preparos = receita.Preparos
                    };

                    receitaVM.Ingredientes = ingredientes;
                    var retorno = _receitaService.AdicionarReceita(receitaVM);
                    //return Json(new { Resultado = retorno.Id });
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Receita/Edit/5
        public async Task<IActionResult> Editar(long id)
        {
            var receita = await _receitaService.ObterReceitaPorId(id);
            return View(receita);
        }

        // POST: Receita/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(long id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic hereif (collection != null)
                if (collection != null && id == Convert.ToInt64(collection["IdReceita"]))
                {
                    var receitaViewModel = new ReceitaViewModel();

                    receitaViewModel.IdReceita = Convert.ToInt32(collection["IdReceita"]);
                    receitaViewModel.TituloReceita = collection["TituloReceita"];
                    receitaViewModel.Rendimento = Convert.ToInt32(collection["Rendimento"]);
                    receitaViewModel.TempoPreparo = Convert.ToInt32(collection["TempoPreparo"]);

                    var idReceita = _receitaService.AlterarReceita(receitaViewModel);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Receita/Delete/5
        public async Task<IActionResult> Deletar(long id)
        {
            return View();
        }

        // POST: Receita/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Deletar(long id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                //return RedirectToAction(nameof(Index));
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}