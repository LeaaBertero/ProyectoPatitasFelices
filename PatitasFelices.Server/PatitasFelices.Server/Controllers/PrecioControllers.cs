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
    [Route("api/Precio")]
    public class PrecioControllers : ControllerBase
    {
        private readonly IPrecioRepositorio repositorio;
        private readonly IMapper mapper;

        public PrecioControllers(IPrecioRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Precio>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPrecioDTO entidadDTO)
        {
            try
            {
                

                Precio entidad = mapper.Map<Precio>(entidadDTO);



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
        public async Task<ActionResult> Put(int id, [FromBody] Precio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await repositorio.SelectById(id);

            if (Dummy == null)
            {
                return NotFound("No existe el precio buscado");
            }

            Dummy.PrecioHora = entidad.PrecioHora;
            Dummy.PrecioDia = entidad.PrecioDia;
          


            try
            {
                await repositorio.Update(id, Dummy);

                return Ok();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }


            //return Ok();
        }
        #endregion

        //metodo eliminar
        #region Método Delete
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existe = await repositorio.Existe(id);

            if (!existe)
            {
                return NotFound($"El precio {id} que se intenta borrar, no existe.");
            }
            if (await repositorio.Borrar(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest($"El precio {id} no se pudo borrar.");
            }
        }
        #endregion
    }
}
