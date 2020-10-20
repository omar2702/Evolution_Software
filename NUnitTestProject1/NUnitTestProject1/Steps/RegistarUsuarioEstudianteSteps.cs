using InterLab.API.Resources;
using NUnit.Framework;
using RestSharp;
using RestSharp.Serialization.Json;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NUnitTestProject1.Steps
{
    [Binding]
    public class RegistarUsuarioEstudianteSteps
    {
        public static RestClient restClient;
        public static RestRequest restRequest;
        public static IRestResponse response;
        private static User new_user;

        [Given(@"como usuario ingreso point para registrarme")]
        public void GivenComoUsuarioIngresoPointParaRegistrarme()
        {
            restClient = new RestClient("https://localhost:44367/");
            restRequest = new RestRequest("api/users", Method.POST);
            restRequest.RequestFormat = DataFormat.Json;

        }

        [When(@"como usuario me registro con mis datos")]
        public void WhenComoUsuarioMeRegistroConMisDatos(Table table)
        {
            new_user = table.CreateInstance<User>();
            var obj = new User()
            {
                Username = new_user.Username,
                Password = new_user.Password,
                Email = new_user.Password,
                DateCreated = new_user.DateCreated
            };
            restRequest.AddBody(obj);
            response = restClient.Execute(restRequest);
        }
        
        [Then(@"registro mis datos de manera exitosa")]
        public void ThenRegistroMisDatosDeManeraExitosa()
        {
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<UserResource>(response);
            Console.WriteLine(output.Username);
            Assert.That("username1", Is.EqualTo(output.Username));


        }
    }
}
