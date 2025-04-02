using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

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
    }
}
