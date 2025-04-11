using AutoMapper;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Util
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CrearUsuarioDTO, Usuario>();
            CreateMap<Usuario, CrearUsuarioDTO>();

            CreateMap<CrearTransaccionDTO, Transaccion>();
            CreateMap<Transaccion, CrearTransaccionDTO>();

            CreateMap<CrearTarjetaDTO, Tarjeta>();
            CreateMap<Tarjeta, CrearTarjetaDTO>();

            CreateMap<CrearServicioDTO, Servicio>();
            CreateMap<Servicio, CrearServicioDTO>();

            CreateMap<CrearReservaDTO, Reserva>();
            CreateMap<Reserva, CrearReservaDTO>();

            CreateMap<CrearPrecioServicioDTO, PrecioServicio>();
            CreateMap<PrecioServicio, CrearPrecioServicioDTO>();

            CreateMap<CrearPrecioDTO, Precio>();
            CreateMap<Precio, CrearPrecioDTO>();

            CreateMap<CrearNombreServicioDTO, NombreServicio>();
            CreateMap<NombreServicio, CrearNombreServicioDTO>();

            CreateMap<CrearMensajeDTO, Mensaje>();
            CreateMap<Mensaje, CrearMensajeDTO>();

            CreateMap<CrearMascotaDTO, Mascota>();
            CreateMap<Mascota, CrearMascotaDTO>();

            CreateMap<CrearFotoUsuarioDTO, FotoUsuario>();
            CreateMap<FotoUsuario, CrearFotoUsuarioDTO>();

            CreateMap<CrearFotoMascotaDTO, FotoMascota>();
            CreateMap<FotoMascota, CrearFotoMascotaDTO>();

            CreateMap<CrearFotoDTO, Foto>();
            CreateMap<Foto, CrearFotoDTO>();

            CreateMap<CrearComentarioDTO, Comentario>();
            CreateMap<Comentario, CrearComentarioDTO>();

        }

        
    }
}






       
