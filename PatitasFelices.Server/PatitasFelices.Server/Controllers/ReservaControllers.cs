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
                return NotFound("No existe el usuario buscado");
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
    }
}
