using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp.API
{
    public class Program
    {
        static async Task Main(string[] args)
        {
           var httpClient = new HttpClient();

            var response =  await httpClient.GetAsync("https://jsonplaceholder.typicode.com/users/6");

               response.EnsureSuccessStatusCode(); // patikrinimo eilute

               var responseBody = await response.Content.ReadAsStringAsync(); // visur kur bus Async reikes prideti await

               var responseObject = JsonConvert.DeserializeObject<Post>(responseBody);


                var responseTwo = await httpClient.GetAsync("https://jsonplaceholder.typicode.com/posts?userId=6");

                var responseTwoBody = await responseTwo.Content.ReadAsStringAsync();

                var responseTwoObject = JsonConvert.DeserializeObject<List<Get>>(responseTwoBody); // nurodoma, kad isspausdintu sarasa

        }
    }
}
