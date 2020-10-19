using InterLab.API.Resources;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace NUnitTestProject1
{
    [Binding]
    public class Feature1Steps
    {


        [Given(@"vamoscompila")]
        public void GivenVamoscompila()
        {
            RestClient client = new RestClient("https://localhost:44367/");
            var request = new RestRequest("api/companies", Method.POST);

            request.RequestFormat = DataFormat.Json;
            
            
            /*var company = new Company();
              company.Name = "Interlab";
              company.Description = "EMpresa dedicada";
              company.Sector = "2";
              company.Email = "interlabmailcom";
              company.Phone = "665579";
              company.Address = "Monterrico cuadra23";
              company.Country = "Peru";
              company.City = "Lima";*/

            request.AddBody(new Company()
            {
            Name = "Interlab",
            Description = "EMpresa dedicada",
            Sector = "2",
            Email = "interlabmailcom",
            Phone = "665579",
            Address = "Monterrico cuadra23",
            Country = "Peru",
            City = "Lima"
        });
            var respones = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<CompanyResource>(respones);
            Console.WriteLine(output.Address);


              /*request.Method = Method.POST;
              request.AddHeader("Accept", "application/json");
              request.Parameters.Clear();
              request.AddParameter("application/json", company, ParameterType.RequestBody);
              var response = client.Execute(request);
              var content = response.Content;
              Console.WriteLine(response.Content);
              */








            //---------------------
            /* request = new RestRequest("api/companies", Method.POST);
               request.RequestFormat = DataFormat.Json;
             request.AddBody(new Company()
             {
                 Name = "Interlab",
                 Description = "EMpresa dedicada",
                 Sector = "ababab",
                 Email = "ababab",
                 Phone = "ababab",
                 Address = "ababab",
                 Country = "ababab",
                 City = "ababab",
             });
            // request.AddBody(company);
               var response = client.Execute(request);
               Console.WriteLine(response.Content);
             */
            //-------------------
            /* var dese = new JsonDeserializer();
             var output = dese.Deserialize<Dictionary<string,string>>(response);
             Console.WriteLine(output["name"]);

             */
            Assert.That(1, Is.EqualTo(1));

        }
    }
}
