using Newtonsoft.Json;
using System;
using ConsumindoApiViaCep.Entities;
using System.Threading.Tasks;

namespace ConsumindoApiViaCep.Entities.Services
{
    internal class EnderecoServices
    {
        public async Task<Endereco> Integracao(string cep) 
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            var jsonString = await response.Content.ReadAsStringAsync();

            var jsonObject = JsonConvert.DeserializeObject<Endereco>(jsonString);

            if(jsonObject is not null)
            {
                return jsonObject;
            }
            else
            {
                return new Endereco
                {
                    Verificacao = true
                };
            }
        }
    }
}
