using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Foto")]
    public class FotoControllers : ControllerBase
    {
        private readonly Context context;

        public FotoControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Foto>>> Get()
        {
            return await context.Foto.ToListAsync();
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

        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Foto.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La foto {id} que se intenta borrar, no existe.");
            }

            Foto entidadBorrar = new Foto();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
        #endregion
    }
}
