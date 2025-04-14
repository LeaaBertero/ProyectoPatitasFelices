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
    [Route("api/FotoMascota")]
    public class FotoMascotaControllers : ControllerBase
    {
        private readonly IFotoMascotaRepositiorio repositorio;
        private readonly IMapper mapper;

        public FotoMascotaControllers(IFotoMascotaRepositiorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<FotoMascota>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearFotoMascotaDTO entidadDTO)
        {
            try
            {
              

                FotoMascota entidad = mapper.Map<FotoMascota>(entidadDTO);

                return await repositorio.Insert(entidad);
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

            var Dummy = await repositorio.SelectById(id);

            if (Dummy == null)
            {
                return NotFound("No existe la foto mascota buscada");
            }

            Dummy.UrlFoto = entidad.UrlFoto;
            Dummy.Descripcion = entidad.Descripcion;




            try
            {
                await repositorio.Update(id, Dummy);

                return Ok();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        #endregion

        //Método Delete
        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"La foto de la mascota {id} que se intenta eliminar, no existe.");
            }
            if (await repositorio.Borrar(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest($"La foto de la mascota {id} no se pudo eliminar.");
            }

        }
        #endregion
    }
}
