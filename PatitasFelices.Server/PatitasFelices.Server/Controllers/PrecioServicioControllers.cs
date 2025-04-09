using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/PrecioServicio")]
    public class PrecioServicioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PrecioServicioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<PrecioServicio>>> Get()
        {
            return await context.PrecioServicio.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPrecioServicioDTO entidadDTO)
        {
            try
            {
               

                PrecioServicio entidad = mapper.Map<PrecioServicio>(entidadDTO);

                context.PrecioServicio.Add(entidad); // Fixed line
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        #endregion

        #region Método update
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] PrecioServicio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await context.PrecioServicio.Where(e => entidad.Id == id).FirstOrDefaultAsync();

            if (Dummy == null)
            {
                return NotFound("El precio del servicio, no existe");
            }

            Dummy.NombreServicio = entidad.NombreServicio;
            Dummy.Precio = entidad.Precio;
           


            try
            {
                context.PrecioServicio.Update(Dummy);
                await context.SaveChangesAsync();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }


            return Ok();
        }
        #endregion
    }
}
