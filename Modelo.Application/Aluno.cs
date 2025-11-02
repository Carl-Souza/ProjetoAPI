namespace Modelo.Application
{
    public class Aluno
    {
        public int Codigo { get; set; }
        public string Matricula { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Numero { get; set; }
        public DateOnly DataNascimento { get; set; }

    }
}
