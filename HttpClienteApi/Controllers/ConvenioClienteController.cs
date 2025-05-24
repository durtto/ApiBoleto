using HttpClienteApi.Models;
using HttpClienteApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HttpClienteApi.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ConvenioClienteController : ControllerBase
    {
        private readonly IComunicationServices _comunicationServices;

        public ConvenioClienteController(IComunicationServices comunicationServices)
        {
            _comunicationServices = comunicationServices;
        }

        [HttpGet]
        public async Task<IEnumerable<ConvenioDetail>> GetConveniosAsync()
        //public string GetConveniosAsync()
        {
            return await _comunicationServices.GetConveniosAsync();
        }

    }
}
