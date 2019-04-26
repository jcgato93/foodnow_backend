using BackEnd;
using BackEnd.DTOs;
using BackEnd.Services;
using Test.Mocks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;

namespace Test.IntegrationTest
{
    [TestClass]
    public class RestaurantControllerTest
    {
        private WebApplicationFactory<Startup> _factory;

        [TestInitialize]
        public void Initialize()
        {
            _factory = new WebApplicationFactory<Startup>();
        }

        // Configuracion del Web Host
        public WebApplicationFactory<Startup> ConstruirWebHostBuilderConfigurado()
        {
            return _factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {                   
                    services.AddScoped<IRestaurantService, RestaurantServiceMock>();
                });
            });
        }


        [TestMethod]
        public async Task Get_ObtieneElListadoDeRestaurantes()
        {
            var client = ConstruirWebHostBuilderConfigurado().CreateClient();

            var url = "/api/Restaurants/GetAll";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Assert.IsTrue(false, "Codigo de estatus no exitoso: " + response.StatusCode);
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<RestaurantDTO>>(await response.Content.ReadAsStringAsync());
            Assert.IsNotNull(result);
            Assert.AreEqual(expected: 2, actual: result.LongCount());
            Assert.AreEqual(expected: "Restaurant1", actual: result.ElementAt(0).Name);
        }
    }
}
