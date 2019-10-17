using Fiap.MasterChefReceitas.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Fiap.MasterChefReceitas.Web.Services
{
    public class ReceitaService
    {
        HttpClient client = new HttpClient();

        public async Task<List<ReceitaViewModel>> ObterReceitasPaginado(int skip, int take)
        {
            try
            {
                string url = "https://localhost:5001/api/Receitas?skip={0}&take={1}";
                var uri = new Uri(string.Format(url, skip, take));
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<ReceitaViewModel>>(response);
                return produtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<ReceitaViewModel>> ObterReceitaPorId(long idReceita)
        {
            try
            {
                string url = "https://localhost:5001/api/Receitas/{0}";
                var uri = new Uri(string.Format(url, idReceita));
                var response = await client.GetStringAsync(url);
                var produtos = JsonConvert.DeserializeObject<List<ReceitaViewModel>>(response);
                return produtos;
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
                string url = "https://localhost:5001/api/Receitas";
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
