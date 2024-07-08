namespace Desafio3.Api.Fiap.API.Models
{
    public class Entrevista
    {
        public Entrevista(string empresa, DateTime data, decimal salario, string responsavel)
        {
            Empresa = empresa;
            Data = data;
            Salario = salario;
            Responsavel = responsavel;
        }

        public string Empresa { get; set; }
        public DateTime Data { get; set; }
        public decimal Salario { get; set; }
        public string Responsavel { get; set; }
    }
}
