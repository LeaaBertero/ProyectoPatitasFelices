using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Server.Repositorio;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Foto")]
    public class FotoControllers : ControllerBase
    {
        private readonly IFotoRepositorio repositorio;
        private readonly IMapper mapper;

        public FotoControllers(IFotoRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Foto>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearFotoDTO entidadDTO)
        {
            try
            {
                

                Foto entidad = mapper.Map<Foto>(entidadDTO);

                return await repositorio.Insert(entidad);
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
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"La foto {id} que se intenta eliminar, no existe.");
            }
            if (await repositorio.Borrar(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest($"La foto {id} no se pudo eliminar.");
            }

        }
        #endregion
    }
}
