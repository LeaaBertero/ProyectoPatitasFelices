using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Reserva")]
    public class ReservaControllers : ControllerBase
    {
        private readonly Context context;

        public ReservaControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> Get()
        {
            return await context.Reserva.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Reserva entidad)
        {
            try
            {
                context.Reserva.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        #endregion

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Reserva entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await context.Reserva.Where(e => entidad.Id == id).FirstOrDefaultAsync();

            if (Dummy == null)
            {
                return NotFound("No existe La reserva buscada");
            }

            Dummy.FechaHoraInicio = entidad.FechaHoraInicio;
            Dummy.FechaHoraFin = entidad.FechaHoraFin;
            Dummy.EstadoReserva = entidad.EstadoReserva;
           

            try
            {
                context.Reserva.Update(Dummy);
                await context.SaveChangesAsync();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }


            return Ok();
        }

        //metodo eliminar
        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Reserva.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La reserva {id} que se intenta borrar, no existe.");
            }

            Reserva entidadBorrar = new Reserva();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
        #endregion
    }
}
