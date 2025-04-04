using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/FotoUsuario")]
    public class FotoUsuarioControllers : ControllerBase
    {
        private readonly Context context;

        public FotoUsuarioControllers(Context context)
        {
            this.context = context;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<FotoUsuario>>> Get()
        {
            return await context.FotoUsuario.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(FotoUsuario entidad)
        {
            try
            {
                context.FotoUsuario.Add(entidad);
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
        public async Task<ActionResult> Put(int id, [FromBody] FotoUsuario entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await context.FotoUsuario.Where(e => entidad.Id == id).FirstOrDefaultAsync();

            if (Dummy == null)
            {
                return NotFound("No existe la foto del usuario");
            }

            Dummy.UrlFoto = entidad.UrlFoto;
            Dummy.Descripcion = entidad.Descripcion;
           


            try
            {
                context.FotoUsuario.Update(Dummy);
                await context.SaveChangesAsync();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }


            return Ok();
        }
        #endregion

        //método eliminar poner acá
    }
}
