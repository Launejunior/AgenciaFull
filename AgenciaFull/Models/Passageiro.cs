
namespace AgenciaFull.Models
{
    public class Passageiro
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Endereco { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public Pacote? Pacote { get; set; }
        public int PacoteId { get; set; }
        public Passageiro() { }
        public Passageiro(string? name, string? endereco, string? email, string? telefone, Pacote? Pacote)
        {
            Name = name;
            Endereco = endereco;
            Email = email;
            Telefone = telefone;
            
        }

        internal static void Add(Passageiro passageiro)
        {
            throw new NotImplementedException();
        }
    }
}

