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
    [Route("api/Mascota")]
    public class MascotaControllers : ControllerBase
    {
        private readonly IMascotaRepositorio repositorio;
        private readonly IMapper mapper;

        public MascotaControllers(IMascotaRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Mascota>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearMascotaDTO entidadDTO)
        {
            try
            {
                

                Mascota entidad = mapper.Map<Mascota>(entidadDTO);

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
        public async Task<ActionResult> Put(int id, [FromBody] Mascota entidad)
        {
            if (id != entidad.Id)
            {
                return BadRequest("Datos incorrectos");
            }

            var Dummy = await repositorio.SelectById(id);

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
                await repositorio.Update(id, Dummy);

                return Ok();
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
                return NotFound($"La mascota {id} que se intenta borrar, no existe.");
            }
            if (await repositorio.Borrar(id))
            {
                return Ok();
            }
            else
            {
                return BadRequest($"La mascota {id} no se pudo borrar.");
            }

        }
        #endregion
    }
}
