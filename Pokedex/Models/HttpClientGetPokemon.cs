using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using Pokedex.Models;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net;

namespace Pokedex.Models
{
    public class HttpClientGetPokemon
    {

            public static HttpClient client = new HttpClient();

            public static async Task<string> GetPokemonAsync(string path)
            {
                // Product product = null;
                HttpResponseMessage response = await client.GetAsync(path);
                //if (response.IsSuccessStatusCode)
                //{
                var product = await response.Content.ReadAsStringAsync();
                //}
                return product;
            }

            public static async Task RunAsync()
            {
                var baseAddress = "https://pokeapi.co/api/v2/pokemon/1";
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Get the product
                    var result = await GetPokemonAsync(baseAddress);
                    Console.WriteLine("yes");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

                Console.ReadLine();
            }

    }
}