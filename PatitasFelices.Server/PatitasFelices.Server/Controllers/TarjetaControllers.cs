using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Tarjeta")]
    public class TarjetaControllers : ControllerBase
    {
        private readonly Context context;

        public TarjetaControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Tarjeta>>> Get()
        {
            return await context.Tarjeta.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Tarjeta entidad)
        {
            try
            {
                context.Tarjeta.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Tarjeta entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await context.Tarjeta.Where(e => entidad.Id == id).FirstOrDefaultAsync();

            if (Dummy == null)
            {
                return NotFound("No existe el usuario buscado");
            }

            Dummy.NroTarjeta = entidad.NroTarjeta;
            Dummy.FechaVencimiento = entidad.FechaVencimiento;
            Dummy.CodigoSeguridad = entidad.CodigoSeguridad;
           


            try
            {
                context.Tarjeta.Update(Dummy);
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
