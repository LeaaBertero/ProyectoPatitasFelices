using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/FotoMascota")]
    public class FotoMascotaControllers : ControllerBase
    {
        private readonly Context context;

        public FotoMascotaControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<FotoMascota>>> Get()
        {
            return await context.FotoMascota.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(FotoMascota entidad)
        {
            try
            {
                context.FotoMascota.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] FotoMascota entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await context.FotoMascota.Where(e => entidad.Id == id).FirstOrDefaultAsync();

            if (Dummy == null)
            {
                return NotFound("No la foto de la mascota");
            }

            Dummy.UrlFoto = entidad.UrlFoto;
            Dummy.Descripcion = entidad.Descripcion;
           


            try
            {
                context.FotoMascota.Update(Dummy);
                await context.SaveChangesAsync();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }


            return Ok();
        }
        #endregion

        //Método Delete
        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.FotoMascota.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La foto de la mascota {id} que se intenta borrar, no existe.");
            }

            FotoMascota entidadBorrar = new FotoMascota();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
        #endregion
    }
}
