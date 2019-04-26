using BackEnd;
using BackEnd.DTOs;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Mocks;

namespace Test.IntegrationTest
{
    [TestClass]
    public class ProductsControllerTest
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
                    services.AddScoped<IProductService, ProductServiceMock>();
                });
            });
        }

        [TestMethod]
        public async Task Get_ObtieneElListadoDeProductosPorCategoria()
        {
            var client = ConstruirWebHostBuilderConfigurado().CreateClient();

            var url = "/api/Products/GetProductsByCategoryId/1";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Assert.IsTrue(false, "Codigo de estatus no exitoso: " + response.StatusCode);
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(await response.Content.ReadAsStringAsync());
            Assert.IsNotNull(result);
            Assert.AreEqual(expected: 2, actual: result.LongCount());
            Assert.AreEqual(expected: "Product1", actual: result.ElementAt(0).Name);
        }

        [TestMethod]
        public async Task Get_ObtieneUnListadoVacioDeProductos_CuandoNoEncuentraLaCategoria()
        {
            var client = ConstruirWebHostBuilderConfigurado().CreateClient();

            var url = "/api/Products/GetProductsByCategoryId/0";
            var response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                Assert.IsTrue(false, "Codigo de estatus no exitoso: " + response.StatusCode);
            }

            var result = JsonConvert.DeserializeObject<IEnumerable<ProductDTO>>(await response.Content.ReadAsStringAsync());
            Assert.IsNotNull(result);
            Assert.AreEqual(expected: 0, actual: result.LongCount());
        }
    }


}

