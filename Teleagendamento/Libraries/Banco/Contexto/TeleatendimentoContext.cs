using Microsoft.EntityFrameworkCore;
using Teleagendamento.Models;

namespace Teleagendamento.Libraries.Banco.Contexto
{
    public class TeleatendimentoContext : DbContext
    {
        public TeleatendimentoContext(DbContextOptions opcoes) : base(opcoes)
        {
        }

        public DbSet<Clinica> Clinica { get; set; }
        public DbSet<Endereco> Endereco { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
    }
}
