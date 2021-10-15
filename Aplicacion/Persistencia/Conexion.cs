using Microsoft.EntityFrameworkCore;
using Dominio;

namespace Persistencia
{
    public class Conexion : DbContext
    {
        public DbSet<Empleado> Empleados { get; set; }

        public DbSet<Consola> Consolas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Venta> Ventas { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder conn)
        {
            if (!conn.IsConfigured)
            {
                conn.UseSqlServer("Data source = (localdb)\\MSSQLLocalDB; Initial Catalog = Exito");
            }
        }
    }
}