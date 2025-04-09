using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/NombreServicio")]
    public class NombreServicioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public NombreServicioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<NombreServicio>>> Get()
        {
            return await context.NombreServicio.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearNombreServicioDTO entidadDTO)
        {
            try
            {
                
                NombreServicio entidad = mapper.Map<NombreServicio>(entidadDTO);

                context.NombreServicio.Add(entidad);
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
