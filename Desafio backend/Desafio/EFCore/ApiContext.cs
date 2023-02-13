using Desafio.Models;
using Microsoft.EntityFrameworkCore;
namespace Desafio.EFCore
{
    public class ApiContext:DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DesafioVentas");
        }
        public DbSet<Asesor> Asesores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Venta> Ventas { get; set; }
    }
}
