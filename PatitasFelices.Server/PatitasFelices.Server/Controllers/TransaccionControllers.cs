using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Transaccion")]
    public class TransaccionControllers : ControllerBase
    {
        private readonly Context context;

        public TransaccionControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Transaccion>>> Get()
        {
            return await context.Transaccion.ToListAsync();
        }
    }
}
