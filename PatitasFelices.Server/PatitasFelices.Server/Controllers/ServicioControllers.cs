using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Servicio")]
    public class ServicioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ServicioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Servicio>>> Get()
        {
            return await context.Servicio.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearServicioDTO entidadDTO)
        {
            try
            {
              
                Servicio entidad = mapper.Map<Servicio>(entidadDTO);

                context.Servicio.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        #endregion
    }
}
