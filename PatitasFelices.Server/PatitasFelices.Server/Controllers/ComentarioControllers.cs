using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Comentario")]
    public class ComentarioControllers : ControllerBase
    {
        private readonly Context context;

        public ComentarioControllers(Context context)
        {
            this.context = context;
        }

       
    }
}
        
