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
    [Route("api/PrecioServicio")]
    public class PrecioServicioControllers : ControllerBase
    {
        private readonly IPrecioServicioRepositorio repositorio;
        private readonly IMapper mapper;

        public PrecioServicioControllers(IPrecioServicioRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<PrecioServicio>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearPrecioServicioDTO entidadDTO)
        {
            try
            {



                PrecioServicio entidad = mapper.Map<PrecioServicio>(entidadDTO);

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
        public async Task<ActionResult> Put(int id, [FromBody] PrecioServicio entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await repositorio.SelectById(id);

            if (Dummy == null)
            {
                return NotFound("No existen precios cargados");
            }

            Dummy.NombreServicio = entidad.NombreServicio;
            Dummy.Precio = entidad.Precio;
            


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
                return NotFound($"El precio del servicio {id} que se intenta borrar, no existe.");
            }
            if (await repositorio.Borrar(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest($"El precio del servicio {id} no se pudo borrar.");
            }



        }
        #endregion
    }
    
}
