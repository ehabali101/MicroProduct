using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Product.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Product.Web.ApiClient
{
    public class ProductApiClient : IProductApiClient
    {
        private readonly IConfiguration _configration;
        private readonly HttpClient _client;

        public ProductApiClient(IConfiguration configration, HttpClient client)
        {
            _configration = configration;
            _client = client;

            var createUrl = _configration.GetSection("ProductApi").GetValue<string>("Create");
            _client.BaseAddress = new Uri(createUrl);
            _client.DefaultRequestHeaders.Add("Content-type", "application/json");
        }

        public async Task<ProductViewModel> Create(ProductViewModel viewModel)
        {
            var jsonModel = JsonConvert.SerializeObject(viewModel);
            var response = await _client.PostAsync(_client.BaseAddress, new StringContent(jsonModel)).ConfigureAwait(false);
            var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var createProductResponse = JsonConvert.DeserializeObject<ProductViewModel>(responseJson);

            return createProductResponse;
        }
    }
}
