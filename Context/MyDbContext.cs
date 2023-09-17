using ClinicaVeterinaria.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore;

namespace ClinicaVeterinaria.Context
{
    public partial class MyDbContext : DbContext
    {
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseMySql("server=localhost; port=3306; user id=root; password=curso4311; database=ClinicaVeterinaria", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-MySqlCharSetAttribute"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}