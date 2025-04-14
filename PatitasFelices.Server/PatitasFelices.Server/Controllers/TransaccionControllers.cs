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
    [Route("api/Transaccion")]
    public class TransaccionControllers : ControllerBase
    {
        private readonly ITransaccionRepositorio repositorio;
        private readonly IMapper mapper;

        #region Constructor
        public TransaccionControllers(ITransaccionRepositorio repositorio, IMapper Mapper)
        {
            this.repositorio = repositorio;
            this.mapper = Mapper;
        }
        #endregion
           

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Transaccion>>> Get()
        {
            return await repositorio.Select();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTransaccionDTO entidadDTO)
        {
            try
            {
                Transaccion entidad = mapper.Map<Transaccion>(entidadDTO);

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

               
                


