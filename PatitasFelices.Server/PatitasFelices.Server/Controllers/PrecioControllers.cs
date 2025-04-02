using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Servicio")]
    public class PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public PrecioControllers(Context context)
        {
            this.context = context;
        }
    }
}
