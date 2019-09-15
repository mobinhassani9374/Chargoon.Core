using Chargoon.Messaging.Setting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Chargoon.Messaging
{
  public  class RequestProvider
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public RequestProvider(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        private void Validation<TModel>(TModel model, string requestUri)
        {
            if (string.IsNullOrEmpty(requestUri))
                throw new ArgumentNullException("requestUri");

            if (model == null)
                throw new ArgumentNullException("model");
        }
        public async Task<IResponse> PostAsync<TModel, TResponse>(TModel model, string requestUri, string token = "")
            where TResponse : IResponse
        {
            Validation(model, requestUri);
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(UrlAddress.BaseUrl);
            if (!string.IsNullOrEmpty(token)) client.DefaultRequestHeaders.Add(Header.HeaderToken, token);
            var json = JsonConvert.SerializeObject(model);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var result = await client.PostAsync(requestUri, byteContent);
            if (result.IsSuccessStatusCode)
            {
                var contentResult = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(contentResult);
            }
            return Response.Error();
        }
        public async Task<IResponse> GetAsync<TModel, TResponse>(TModel model, string requestUri, string token = "")
            where TResponse : IResponse
        {
            var queryString = "";

            var properties = model
                 .GetType()
                 .GetProperties()
                 .Where(c => c.GetValue(model) != null)
                 .ToList();

            foreach (var prop in properties)
            {
                queryString += $"{prop.Name}={prop.GetValue(model)}&";
            }
            if (queryString.EndsWith("&"))
                queryString = queryString.Substring(0, queryString.Length - 1);

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(UrlAddress.BaseUrl);
            if (!string.IsNullOrEmpty(token)) client.DefaultRequestHeaders.Add(Header.HeaderToken, token);
            var result = await client.GetAsync($"{requestUri}{queryString}");
            if (result.IsSuccessStatusCode)
            {
                var contentResult = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<TResponse>(contentResult);
            }
            return Response.Error();
        }
    }
}
