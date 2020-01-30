using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ASPNetCoreWebAPI.Models;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            if (System.IO.File.Exists("data.json"))
            {
                String JSONtxt = System.IO.File.ReadAllText("data.json");
                List<Person> people = JsonConvert.DeserializeObject<List<Person>>(JSONtxt);

                Console.WriteLine("Előzőleg bevitt adatok:\n");
                Console.WriteLine(JsonConvert.SerializeObject(people, Formatting.Indented));
                Console.WriteLine();
            }

            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureServices(services => services.AddMvc())
                .Configure(app => app.UseMvc())
                .UseUrls("http://*:80")
                .Build()
                .Run();
        }
    }
}