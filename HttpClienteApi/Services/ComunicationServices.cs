using HttpClienteApi.Models;
using HttpClienteApi.TratarErro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClienteApi.Services{

    public class ComunicationServices : IComunicationServices
    {
        private readonly HttpClient _httpClient;
        private readonly IExceptionHandler _exceptionHandler;

        public ComunicationServices(HttpClient client, IExceptionHandler exceptionHandler)
        {
            _httpClient = client;
            _exceptionHandler = exceptionHandler;
        }


        public async Task<IEnumerable<ConvenioDetail>> GetConveniosAsync()
        {
            var endpoint = new Uri("https://localhost:7228/api/ConvenioDetails");

            try
            {
                var response = await _httpClient.GetAsync(endpoint);
                _exceptionHandler.Handle(response);
                var json = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<IEnumerable<ConvenioDetail>>(json);
                return model;
            }

            catch (ApiException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

    }


}
