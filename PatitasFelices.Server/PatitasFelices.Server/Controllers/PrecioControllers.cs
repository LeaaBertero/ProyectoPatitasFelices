using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Precio")]
    public class PrecioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public PrecioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Precio>>> Get()
        {
            return await context.Precio.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPrecioDTO entidadDTO)
        {
            try
            {
                

                Precio entidad = mapper.Map<Precio>(entidadDTO);


                context.Precio.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Precio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await context.Precio.Where(e => entidad.Id == id).FirstOrDefaultAsync();

            if (Dummy == null)
            {
                return NotFound("No existe el precio buscado");
            }

            Dummy.PrecioDia = entidad.PrecioDia;
            Dummy.PrecioHora = entidad.PrecioHora;
           


            try
            {
                context.Precio.Update(Dummy);
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
