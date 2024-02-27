using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AgenciaFull.Models;

namespace AgenciaFull.Data
{
    public class AgenciaFullContext : DbContext
    {
        public AgenciaFullContext (DbContextOptions<AgenciaFullContext> options)
            : base(options)
        {
        }

        public DbSet<AgenciaFull.Models.Hospedagem> Hospedagem { get; set; } = default!;

        public DbSet<AgenciaFull.Models.Pacote>? Pacote { get; set; }

        public DbSet<AgenciaFull.Models.Passageiro>? Passageiro { get; set; }

        public DbSet<AgenciaFull.Models.Passagem>? Passagem { get; set; }

        public DbSet<AgenciaFull.Models.Login>? Login { get; set; }

        public DbSet<AgenciaFull.Models.Pagamento>? Pagamento { get; set; }
    }
}
