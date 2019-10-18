using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Fiap.MasterChefReceitas.Web.Models;
using Fiap.MasterChefReceitas.Web.Services;

namespace Fiap.MasterChefReceitas.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ReceitaService _receitaService;

        public HomeController(ReceitaService receitaService)
        {
            _receitaService = receitaService;
        }

        public async Task<IActionResult> Index()
        {
            var listaReceita = await _receitaService.ObterReceitasPaginado(0, 4);
            return View(listaReceita.ToList());
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
