using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatitasFelices.BD.Migrations
{
    /// <inheritdoc />
    public partial class inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComentarioId = table.Column<int>(type: "int", nullable: false),
                    UsuarioAutoId = table.Column<int>(type: "int", nullable: false),
                    UsuarioDestinatarioId = table.Column<int>(type: "int", nullable: false),
                    TextoComentario = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaPublicacion = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Foto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoId = table.Column<int>(type: "int", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    UrlFoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FotoMascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoMascotaId = table.Column<int>(type: "int", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    UrlFoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoMascota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FotoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FotoUsuarioId = table.Column<int>(type: "int", nullable: false),
                    UrlFoto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FotoUsuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mascota",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Raza = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Edad = table.Column<int>(type: "int", nullable: false),
                    Tamaño = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Foto = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NecesidadesEspeciales = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mascota", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MensajeId = table.Column<int>(type: "int", nullable: false),
                    UsuarioEmisorId = table.Column<int>(type: "int", nullable: false),
                    UsuarioReceptorId = table.Column<int>(type: "int", nullable: false),
                    ContenidoMensaje = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaHoraMensaje = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensaje", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NombreServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioServicioId = table.Column<int>(type: "int", nullable: false),
                    NombreDeServicio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NombreServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioId = table.Column<int>(type: "int", nullable: false),
                    PrecioHora = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioDia = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecioServicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrecioServicioId = table.Column<int>(type: "int", nullable: false),
                    NombreServicio = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioServicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reserva",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    MascotaId = table.Column<int>(type: "int", nullable: false),
                    FechaHoraInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaHoraFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EstadoReserva = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reserva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    NombreServicio = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tarjeta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TarjetaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    NroTarjeta = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    FechaVencimiento = table.Column<DateOnly>(type: "date", nullable: false),
                    CodigoSeguridad = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarjeta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transaccion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransaccionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    TarjetaId = table.Column<int>(type: "int", nullable: false),
                    ReservaId = table.Column<int>(type: "int", nullable: false),
                    ServicioId = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MetodoPago = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaccion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorreoElectronico_Usuario = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Contrasenia = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    FotoPerfil = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    Rol = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "ComentarioId_UQ",
                table: "Comentario",
                column: "ComentarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "TextoComentario_FechaPublicacion",
                table: "Comentario",
                columns: new[] { "TextoComentario", "FechaPublicacion" });

            migrationBuilder.CreateIndex(
                name: "FotoId_UQ",
                table: "Foto",
                column: "FotoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UrlFoto_Descripcion",
                table: "Foto",
                columns: new[] { "UrlFoto", "Descripcion" });

            migrationBuilder.CreateIndex(
                name: "FotoMascotaId_UQ",
                table: "FotoMascota",
                column: "FotoMascotaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UrlFoto_Descripcion",
                table: "FotoMascota",
                columns: new[] { "UrlFoto", "Descripcion" });

            migrationBuilder.CreateIndex(
                name: "FotoUsuarioId_UQ",
                table: "FotoUsuario",
                column: "FotoUsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UrlFoto_Descripcion",
                table: "FotoUsuario",
                columns: new[] { "UrlFoto", "Descripcion" });

            migrationBuilder.CreateIndex(
                name: "MascotaId_UQ",
                table: "Mascota",
                column: "MascotaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Nombre_Raza_Edad_Tamaño_Foto_NecesidadesEspeciales",
                table: "Mascota",
                columns: new[] { "Nombre", "Raza", "Edad", "Tamaño", "Foto", "NecesidadesEspeciales" });

            migrationBuilder.CreateIndex(
                name: "ContenidoMensaje_FechaHoraMensaje",
                table: "Mensaje",
                columns: new[] { "ContenidoMensaje", "FechaHoraMensaje" });

            migrationBuilder.CreateIndex(
                name: "MensajeId_UQ",
                table: "Mensaje",
                column: "MensajeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NombreDeServicio_Precio",
                table: "NombreServicio",
                columns: new[] { "NombreDeServicio", "Precio" });

            migrationBuilder.CreateIndex(
                name: "PrecioServicioId_UQ",
                table: "NombreServicio",
                column: "PrecioServicioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "PrecioHora_PrecioDia",
                table: "Precio",
                columns: new[] { "PrecioHora", "PrecioDia" });

            migrationBuilder.CreateIndex(
                name: "PrecioId_UQ",
                table: "Precio",
                column: "PrecioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NombreServicio_Precio",
                table: "PrecioServicio",
                columns: new[] { "NombreServicio", "Precio" });

            migrationBuilder.CreateIndex(
                name: "PrecioServicioId_UQ",
                table: "PrecioServicio",
                column: "PrecioServicioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "FechaHoraInicio_FechaHoraFin_EstadoReserva",
                table: "Reserva",
                columns: new[] { "FechaHoraInicio", "FechaHoraFin", "EstadoReserva" });

            migrationBuilder.CreateIndex(
                name: "ReservaId_UQ",
                table: "Reserva",
                column: "ReservaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "NombreServicio",
                table: "Servicio",
                column: "NombreServicio");

            migrationBuilder.CreateIndex(
                name: "ServicioId_UQ",
                table: "Servicio",
                column: "ServicioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Fecha_CodigoSeguridad",
                table: "Tarjeta",
                columns: new[] { "FechaVencimiento", "CodigoSeguridad" });

            migrationBuilder.CreateIndex(
                name: "TarjetaId_UQ",
                table: "Tarjeta",
                column: "TarjetaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Monto_MetodoPago",
                table: "Transaccion",
                columns: new[] { "Monto", "MetodoPago" });

            migrationBuilder.CreateIndex(
                name: "TransaccionId_UQ",
                table: "Transaccion",
                column: "TransaccionId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Foto");

            migrationBuilder.DropTable(
                name: "FotoMascota");

            migrationBuilder.DropTable(
                name: "FotoUsuario");

            migrationBuilder.DropTable(
                name: "Mascota");

            migrationBuilder.DropTable(
                name: "Mensaje");

            migrationBuilder.DropTable(
                name: "NombreServicio");

            migrationBuilder.DropTable(
                name: "Precio");

            migrationBuilder.DropTable(
                name: "PrecioServicio");

            migrationBuilder.DropTable(
                name: "Reserva");

            migrationBuilder.DropTable(
                name: "Servicio");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Transaccion");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
