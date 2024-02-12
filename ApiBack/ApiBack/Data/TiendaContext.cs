using ApiBack.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBack.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<DetallesPedidos> DetallePedidos { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<ImagenProductos> ProductoImagenes { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<TraduccionCategorias> TraduccionCategorias { get; set; }
        public DbSet<TraduccionProductos> TraduccionProductos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Productos>()
               .Property(p => p.Precio)
               .HasColumnType("decimal(18, 2)");

            // Índices y propiedades únicas
            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Categorias>()
                .Property(c => c.Nombre)
                .IsRequired()
                .HasMaxLength(100);
            modelBuilder.Entity<Categorias>()
                .HasIndex(c => c.Nombre)
                .IsUnique();

            // Relación uno a muchos: Usuario (como Cliente) puede tener muchos Pedidos
            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Cliente) // Usa la propiedad de navegación 'Cliente' en 'Pedidos'
                .WithMany(u => u.Pedidos) // Asegúrate de que la clase 'Usuario' tenga una propiedad 'Pedidos'
                .HasForeignKey(p => p.ClienteId); // Esto establece 'ClienteId' como la clave foránea


            // Relación uno a muchos: Productos a DetallesPedidos
            modelBuilder.Entity<Productos>()
                .HasMany(p => p.DetallesPedidos)
                .WithOne(dp => dp.Producto)
                .HasForeignKey(dp => dp.ProductoId);

            // Configuración para DetallesPedidos
            modelBuilder.Entity<DetallesPedidos>()
                .HasKey(dp => new { dp.PedidoId, dp.ProductoId });
            modelBuilder.Entity<DetallesPedidos>()
                .Property(dp => dp.PrecioUnitario)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<DetallesPedidos>()
                .Property(dp => dp.Descuento)
                .HasColumnType("decimal(18,2)");

            // Configuraciones adicionales según necesidades
            // Por ejemplo, validaciones específicas, relaciones adicionales, etc.

            // Desactivar el borrado en cascada para todas las relaciones
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}