using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Proiect.EntityModel
{
    public partial class BibliotecaContext : DbContext
    {
        public BibliotecaContext()
            : base("name=BibliotecaContext")
        {
        }

        public virtual DbSet<Autori> Autoris { get; set; }
        public virtual DbSet<Bibliotecar> Bibliotecars { get; set; }
        public virtual DbSet<Carti> Cartis { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Imprumuturi> Imprumuturis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Carti>()
                .HasMany(e => e.Bibliotecars)
                .WithOptional(e => e.Carti)
                .HasForeignKey(e => e.id_carte);

            modelBuilder.Entity<Carti>()
                .HasMany(e => e.Clients)
                .WithOptional(e => e.Carti)
                .HasForeignKey(e => e.id_carte);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Imprumuturis)
                .WithOptional(e => e.Client)
                .HasForeignKey(e => e.cnp_client);
        }
    }
}
