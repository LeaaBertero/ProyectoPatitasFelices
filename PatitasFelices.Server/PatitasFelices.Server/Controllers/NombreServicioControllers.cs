using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/NombreServicio")]
    public class NombreServicioControllers : ControllerBase
    {
        private readonly Context context;

        public NombreServicioControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<NombreServicio>>> Get()
        {
            return await context.NombreServicio.ToListAsync();
        }
    }
}
