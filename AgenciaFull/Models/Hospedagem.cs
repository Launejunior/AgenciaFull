namespace AgenciaFull.Models
{
    public class Hospedagem
    {
        public int Id { get; set; }
        public string? Destino { get; set; }
        public string? Hoteis { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Saida { get; set; }
        public int Quarto { get; set; }
        public int Viajantes { get; set; }


    }
}

