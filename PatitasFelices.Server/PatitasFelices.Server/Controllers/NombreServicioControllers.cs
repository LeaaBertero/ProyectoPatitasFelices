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
    [Route("api/NombreServicio")]
    public class NombreServicioControllers : ControllerBase
    {
        private readonly INombreServicioRepositorio repositorio;
        private readonly IMapper mapper;

        public NombreServicioControllers(INombreServicioRepositorio repositorio, IMapper mapper)
        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<NombreServicio>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearNombreServicioDTO entidadDTO)
        {
            try
            {
                
                NombreServicio entidad = mapper.Map<NombreServicio>(entidadDTO);

                return await repositorio.Insert(entidad);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
        #endregion
    }
}
