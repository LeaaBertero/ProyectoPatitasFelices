using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Mascota")]
    public class MascotaControllers : ControllerBase
    {
        private readonly Context context;

        public MascotaControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Mascota>>> Get()
        {
            return await context.Mascota.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(Mascota entidad)
        {
            try
            {
                context.Mascota.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] Mascota entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await context.Mascota.Where(e => entidad.Id == id).FirstOrDefaultAsync();

            if (Dummy == null)
            {
                return NotFound("No existe la mascota buscada");
            }

            Dummy.Nombre = entidad.Nombre;
            Dummy.Raza = entidad.Raza;
            Dummy.Edad = entidad.Edad;
            Dummy.Tamaño = entidad.Tamaño;
            Dummy.Foto = entidad.Foto;
            Dummy.NecesidadesEspeciales = entidad.NecesidadesEspeciales;


            try
            {
                context.Mascota.Update(Dummy);
                await context.SaveChangesAsync();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }


            return Ok();
        }
        #endregion

        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Mascota.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La mascota {id} que se intenta borrar, no existe.");
            }

            Mascota entidadBorrar = new Mascota();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
        #endregion
    }
}
