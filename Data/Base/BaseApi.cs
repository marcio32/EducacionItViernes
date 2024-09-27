using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace Data.Base
{
    public class BaseApi : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> PostToApi(string metodoController, object model, string token)
        {
            var client = _httpClientFactory.CreateClient("UseApi");

            if (token != "")
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }

            var response = await client.PostAsJsonAsync(metodoController, model);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return BadRequest(response);
        }

        public async Task<IActionResult> GetToApi(string metodoController, string token = "")
        {
            var client = _httpClientFactory.CreateClient("UseApi");

            if(token != "")
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            }

            var response = await client.GetAsync(metodoController);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return Ok(content);
            }

            return BadRequest(response);
        }
   
    }
}
