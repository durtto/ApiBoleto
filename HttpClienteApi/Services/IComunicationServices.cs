using HttpClienteApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpClienteApi.Services
{
    public interface IComunicationServices
    {
        Task<IEnumerable<ConvenioDetail>> GetConveniosAsync();

    }
}
