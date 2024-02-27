

namespace AgenciaFull.Models
{
    public class Pacote
    {
        public int Id { get; set; }
        public string? Origem { get; set; }
        public string? Destino { get; set; }
        public DateTime DateTime { get; }
        public DateTime Ida { get; set; }
       
        public DateTime Volta { get; set; }
        public int Quarto { get; set;}
        public int Viajantes { get; set;}
        public ICollection<Passageiro> Passageiro { get; set;} = new HashSet<Passageiro>();
        public Pacote() { }
        public Pacote(string? origem, string? destino, DateTime ida, DateTime volta, int quarto, int viajantes)
        {
            Origem = origem;
            Destino = destino;
            DateTime = ida; 
            Volta = volta;
            Quarto = quarto;
            Viajantes = viajantes;

        }

        public void AddPassageiro(Passageiro passageiro)
        {
            Passageiro.Add(passageiro);
        }

    }
}


