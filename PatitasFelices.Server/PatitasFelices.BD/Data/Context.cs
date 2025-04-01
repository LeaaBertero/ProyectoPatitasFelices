using Azure;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatitasFelices.BD.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Foto> Foto { get; set; }
        public DbSet<FotoMascota> FotoMascota { get; set; }
        public DbSet<FotoUsuario> FotoUsuario { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<Mensaje> Mensaje { get; set; }
        public DbSet<NombreServicio> NombreServicio { get; set; }
        public DbSet<Precio> Precio { get; set; }
        public DbSet<PrecioServicio> PrecioServicio { get; set; }
        public DbSet<Reserva> Reserva { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<Transaccion> Transaccion { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        //protected Context( Context contex)
        //{
        //}

        //codigo que evita que un registro de la base de datos, pueda borrarse en cascada
        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Éste codigo sirve para evitar que se borren los datos en cascada en la base de datos
            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                            .SelectMany(t => t.GetForeignKeys())
                                            .Where(fk => !fk.IsOwnership
                                                        && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {        //Elimina el cmportamiento               
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
        }
        #endregion
    }
}

           


