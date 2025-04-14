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
    [Route("api/Reserva")]
    public class ReservaControllers : ControllerBase
    {
        private readonly IReservaRepositorio repositorio;
        private readonly IMapper mapper;

        public ReservaControllers(IReservaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearReservaDTO entidadDTO)
        {
            try
            {
                

                Reserva entidad = mapper.Map<Reserva>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        #endregion

        #region Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Reserva entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await repositorio.SelectById(id);

            if (Dummy == null)
            {
                return NotFound("No existe La reserva buscada");
            }

            Dummy.FechaHoraInicio = entidad.FechaHoraInicio;
            Dummy.FechaHoraFin = entidad.FechaHoraFin;
            Dummy.EstadoReserva = entidad.EstadoReserva;
           

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
                return NotFound($"La reserva {id} que se intenta borrar, no existe.");
            }
            if (await repositorio.Borrar(id)) 
            {
                return Ok();
            }
            else
            {
                return BadRequest($"La reserva {id} no se pudo borrar.");
            }



        }
        #endregion

      

       
    }
}
