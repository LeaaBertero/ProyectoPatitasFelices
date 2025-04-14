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
    [Route("api/Usuario")]
    public class UsuarioControllers : ControllerBase
    {
        private readonly IUsuarioRepositorio repositorio;
        private readonly IMapper mapper;

        #region Constructor
        public UsuarioControllers(IUsuarioRepositorio repositorio,
                                  IMapper mapper)

        {
            this.repositorio = repositorio;
            this.mapper = mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearUsuarioDTO entidadDTO)
        {
            try
            {
                Usuario entidad = mapper.Map<Usuario>(entidadDTO);
               
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




               

