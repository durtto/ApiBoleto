using System;
using System.Net.Http;
using System.Net;

namespace HttpClienteApi.TratarErro
{
    public class ExceptionHandler : IExceptionHandler
    {
        public void Handle(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                switch (response.StatusCode)
                {
                    case HttpStatusCode.BadRequest:
                        throw new ApiException("Servidor não encontrado", (int)response.StatusCode);
                    case HttpStatusCode.Unauthorized:
                        throw new ApiException("Não Autorizado", (int)response.StatusCode);
                    case HttpStatusCode.NotFound:
                        throw new ApiException("Endereço Não Encontrado", (int)response.StatusCode);
                    case HttpStatusCode.ServiceUnavailable:
                        throw new ApiException("Serviço não disponível", (int)response.StatusCode);
                    case HttpStatusCode.Forbidden:
                        throw new ApiException("Acesso negado", (int)response.StatusCode);

                    default:
                        throw new ApiException("Erro ocorreu", (int)response.StatusCode);
                }
            }
        }
    }
}
