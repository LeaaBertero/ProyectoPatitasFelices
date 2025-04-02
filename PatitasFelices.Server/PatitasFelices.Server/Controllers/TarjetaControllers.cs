using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/Tarjeta")]
    public class TarjetaControllers : ControllerBase
    {
        private readonly Context context;

        public TarjetaControllers(Context context)
        {
            this.context = context;
        }
    }
}
