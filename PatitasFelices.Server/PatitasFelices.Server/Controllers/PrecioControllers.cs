using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Precio")]
    public class PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public PrecioControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Precio>>> Get()
        {
            return await context.Precio.ToListAsync();
        }
    }
}
