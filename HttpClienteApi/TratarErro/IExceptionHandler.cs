using HttpClienteApi.Models;
using HttpClienteApi.TratarErro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClienteApi.TratarErro
{
    public interface IExceptionHandler
    {
        void Handle(HttpResponseMessage response);
    }
}