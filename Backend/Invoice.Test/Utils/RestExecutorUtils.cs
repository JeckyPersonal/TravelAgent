using Invoice.Test.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoice.Test.Utils
{
    internal class RestExecutorUtils
    {
        private readonly HttpClient _client;

        public RestExecutorUtils(HttpClient client)
        {
            _client = client;
        }

        public  async Task<HttpResponseDto> ExecuteGet(string url)
        {
            var response = await this._client.GetAsync(url);
            string content = await response.Content.ReadAsStringAsync();

            return new HttpResponseDto(response.StatusCode, content);
        }

        public async Task<HttpResponseDto> ExecutePost<T>(string url,T payloadDto)
        {
            string json = JsonConvert.SerializeObject(payloadDto);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await this._client.PostAsync(url, payload);
            var content = await response.Content.ReadAsStringAsync();

            return new HttpResponseDto(response.StatusCode, content);
        }

        internal async Task<HttpResponseDto> ExecutePut<T>(string url, T payloadDto)
        {
            string json = JsonConvert.SerializeObject(payloadDto);
            var payload = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await this._client.PutAsync(url, payload);
            var content = await response.Content.ReadAsStringAsync();

            return new HttpResponseDto(response.StatusCode, content);
        }
    }
}
