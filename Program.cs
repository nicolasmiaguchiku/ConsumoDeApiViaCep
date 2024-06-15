using ConsumindoApiViaCep.Entities;
using ConsumindoApiViaCep.Entities.Services;
using System;

namespace ConsumindoApidViaCep
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            Console.Write("Informe o cep: ");
            string? cep = Console.ReadLine();


            EnderecoServices? enderecoServices = new EnderecoServices();

            Endereco enderecoEncontrado = await enderecoServices.Integracao(cep);

            if (!enderecoEncontrado.Verificacao)
            {
                Console.WriteLine("Endereco encontrado: ");
                Console.WriteLine("Cep: "+ enderecoEncontrado.Cep);
                Console.WriteLine("Logradouro: " + enderecoEncontrado.Logradouro);
                Console.WriteLine("Complemento: " + enderecoEncontrado.Complemento);
                Console.WriteLine("Bairro: " + enderecoEncontrado.Bairro);
                Console.WriteLine("Localidade: " + enderecoEncontrado.Localidade);
                Console.WriteLine("Uf: " + enderecoEncontrado.Uf);
            }
            else
            {
               Console.WriteLine("Endereco não encontrado");
            }
        }
    }
}