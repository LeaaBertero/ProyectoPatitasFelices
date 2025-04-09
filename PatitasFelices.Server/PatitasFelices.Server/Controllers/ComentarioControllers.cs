using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Comentario")]
    public class ComentarioControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        public ComentarioControllers(Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Comentario>>> Get()
        {
            return await context.Comentario.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearComentarioDTO entidadDTO)
        {
            try
            {
               

                Comentario entidad = mapper.Map<Comentario>(entidadDTO);


                context.Comentario.Add(entidad);
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
            var existe = await context.Comentario.AnyAsync(x => x.Id == id);

            if (!existe)
            {
                return NotFound($"El comentario {id} que se intenta borrar, no existe.");
            }

            Comentario entidadBorrar = new Comentario();
            entidadBorrar.Id = id;

            context.Remove(entidadBorrar);
            await context.SaveChangesAsync();
            return Ok();

        }
        #endregion

    }
}
        
