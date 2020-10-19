using InterLab.API.Resources;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NUnitTestProject1.Features
{
    [Binding]
    public class RegistrarUsuarioEmpresaSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static Company new_company;

        [Given(@"como usuario ingreso a la pagina web")]
        public void GivenComoUsuarioIngresoALaPaginaWeb()
        {
            restClient = new RestClient("https://localhost:44367/");
            restRequest = new RestRequest("api/companies", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;

        }

        [When(@"como usuario me registro con los datos")]
        public void WhenComoUsuarioMeRegistroConLosDatos( Table table)
        {
            new_company = table.CreateInstance<Company>();
            var obj = new Company()
            {
                Name = new_company.Name,
                Description = new_company.Description,
                Sector = new_company.Sector,
                Email = new_company.Email,
                Phone = new_company.Phone,
                Address = new_company.Address,
                Country = new_company.Country,
                City = new_company.City
            };
            restRequest.AddBody(obj);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"se registra mis datos con exito")]
        public void ThenSeRegistraMisDatosConExito()
        {
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<CompanyResource>(response);
            Console.WriteLine(output.Name);
            Assert.That("Interlab", Is.EqualTo(output.Name));


        }
    }
}
