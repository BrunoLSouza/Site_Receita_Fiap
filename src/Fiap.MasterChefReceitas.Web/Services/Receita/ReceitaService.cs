using Fiap.MasterChefReceitas.Core;
using Fiap.MasterChefReceitas.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Services
{
    public class ReceitaService : IReceitaService
    {
        HttpClient client = new HttpClient();

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly IMemoryCache _memoryCache;

        public ReceitaService(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMemoryCache memoryCache)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this._memoryCache = memoryCache;
            var token = string.Empty;
            if (signInManager?.Context?.User?.Identity?.Name != null)
                _memoryCache.TryGetValue(signInManager.Context.User.Identity.Name, out token);

            client.DefaultRequestHeaders.Authorization
                 = new AuthenticationHeaderValue("Bearer", token);
        }

        public async Task<List<ReceitaViewModel>> ObterReceitasPaginado(int skip, int take)
        {
            try
            {
                string url = "http://localhost:51380/api/Receitas/{0}/{1}";
                var uri = new Uri(string.Format(url, skip, take));
                var response = await client.GetStringAsync(uri);
                var produtos = JsonConvert.DeserializeObject<List<ReceitaViewModel>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ReceitaViewModel> ObterReceitaPorId(long idReceita)
        {
            try
            {
                string url = "http://localhost:51380/api/Receitas/{0}";
                var uri = new Uri(string.Format(url, idReceita));
                var response = await client.GetStringAsync(uri);
                var produto = JsonConvert.DeserializeObject<ReceitaViewModel>(response);
                return produto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AdicionarReceita(ReceitaViewModel receita)
        {
            try
            {
                string url = "https://localhost:5001/api/Receitas";
                var data = JsonConvert.SerializeObject(receita);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PostAsync(url, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao incluir receita");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async void DeletarReceita(long idReceita)
        {
            try
            {
                string url = "https://localhost:5001/api/Receitas/{0}";
                var uri = new Uri(string.Format(url, idReceita));
                var response = await client.DeleteAsync(uri);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AlterarReceita(ReceitaViewModel receita)
        {
            try
            {
                string url = "https://localhost:5001/api/Receitas/{0}";
                var data = JsonConvert.SerializeObject(receita);
                var uri = new Uri(string.Format(url, receita.IdReceita));
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = null;
                response = await client.PutAsync(uri, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception("Erro ao alterar receita");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
