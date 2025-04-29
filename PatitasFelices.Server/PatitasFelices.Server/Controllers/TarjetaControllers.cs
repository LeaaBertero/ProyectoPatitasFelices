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
    [Route("api/Tarjeta")]
    public class TarjetaControllers : ControllerBase
    {
        private readonly ITarjetaRepositorio repositorio;
        private readonly IMapper mapper;

        #region Constructor
        public TarjetaControllers(ITarjetaRepositorio repositorio ,IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Tarjeta>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTarjetaDTO entidadDTO)
        {
            try
            {
               

                Tarjeta entidad = mapper.Map<Tarjeta>(entidadDTO);

                
                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        #endregion

        #region Método Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tarjeta entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await repositorio.SelectById(id);

            if (Dummy == null)
            {
                return NotFound("No existe la tarjeta buscada buscado");
            }

            Dummy.NroTarjeta = entidad.NroTarjeta;
            Dummy.FechaVencimiento = entidad.FechaVencimiento;
            Dummy.CodigoSeguridad = entidad.CodigoSeguridad;
           


            try
            {
                await repositorio.Update(id, Dummy);

                return Ok();
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }


            return Ok();
        }
        #endregion
    }


}
