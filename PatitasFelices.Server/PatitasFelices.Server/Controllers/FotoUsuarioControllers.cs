using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/FotoUsuario")]
    public class FotoUsuarioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public FotoUsuarioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
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
        public async Task<ActionResult<int>> Post(CrearFotoUsuarioDTO entidadDTO)
        {
            try
            {
               

                FotoUsuario entidad = mapper.Map<FotoUsuario>(entidadDTO);

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
        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.FotoUsuario.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"La foto del usuario {id} que se intenta borrar, no existe.");
            }

            FotoUsuario entidadBorrar = new FotoUsuario();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
        #endregion
    }
}
