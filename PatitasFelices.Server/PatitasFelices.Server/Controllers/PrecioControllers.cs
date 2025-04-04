using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Precio")]
    public class PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public PrecioControllers(Context context)
        {
            this.context = context;
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
        public async Task<ActionResult<int>> Post(Precio entidad)
        {
            try
            {
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
