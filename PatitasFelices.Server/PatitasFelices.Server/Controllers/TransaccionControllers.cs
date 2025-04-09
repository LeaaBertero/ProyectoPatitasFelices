using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;
using PatitasFelices.Shared.DTO;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Transaccion")]
    public class TransaccionControllers : ControllerBase
    {
        private readonly Context context;
        private readonly IMapper mapper;

        #region Constructor
        public TransaccionControllers(Context context, IMapper Mapper)
        {
            this.context = context;
            mapper = Mapper;
        }
        #endregion

        #region Método Get
        [HttpGet]
        public async Task<ActionResult<List<Transaccion>>> Get()
        {
            return await context.Transaccion.ToListAsync();
        }
        #endregion

        #region Método Post
        [HttpPost]
        public async Task<ActionResult<int>> Post(CrearTransaccionDTO entidadDTO)
        {
            try
            {
                

                Transaccion entidad = mapper.Map<Transaccion>(entidadDTO);


                context.Transaccion.Add(entidad);
                await context.SaveChangesAsync();
                return entidad.Id;
            }
            catch (Exception err)
            {

                return BadRequest(err.Message);
            }
        }
        #endregion
    }
}
