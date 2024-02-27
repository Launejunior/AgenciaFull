namespace AgenciaFull.Models
{
    public class Passagem
    {
        public int Id { get; set; }
        public string? Origem { get; set; }
        public string? Destino { get; set; }
        public DateTime Ida { get; set; }
        public DateTime Volta { get; set; }
        public int Viajantes { get; set; }
        public Passagem () { }

 


    }
}

