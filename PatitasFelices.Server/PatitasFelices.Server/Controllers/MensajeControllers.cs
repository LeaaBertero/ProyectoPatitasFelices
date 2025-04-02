using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Mensaje")]
    public class MensajeControllers : ControllerBase
    {
        private readonly Context context;

        public MensajeControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Mensaje>>> Get()
        {
            return await context.Mensaje.ToListAsync();
        }
    }
}
