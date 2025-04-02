using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Foto")]
    public class FotoControllers : ControllerBase
    {
        private readonly Context context;

        public FotoControllers(Context context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Foto>>> Get()
        {
            return await context.Foto.ToListAsync();
        }
    }
}
