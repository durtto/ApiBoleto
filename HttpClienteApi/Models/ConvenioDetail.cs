using System;

namespace HttpClienteApi.Models
{
    public class ConvenioDetail
    {      
        public Guid Id { get; set; }
        public int CdEmp { get; set; }
        public int CdFilial { get; set; }
        public string? DsConvenio { get; set; }
    }
}
