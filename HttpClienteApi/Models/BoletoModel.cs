using System;

namespace HttpClienteApi.Models
{
    public class BoletoModel
    {
        public string SeuNumero { get; set; }
        public decimal ValorNominal { get; set; }
        public DateTime DataVencimento { get; set; }
        public string NumTituloCliente { get; set; }
        public string Mensagem { get; set; }
        public string CpfCnpjPagador { get; set; }
        public string NomePagador { get; set; }
        public string EnderecoPagador { get; set; }
        public string BairroPagador { get; set; }
        public string CidadePagador { get; set; }
        public string UfPagador { get; set; }
        public string CepPagador { get; set; }
    }
} 