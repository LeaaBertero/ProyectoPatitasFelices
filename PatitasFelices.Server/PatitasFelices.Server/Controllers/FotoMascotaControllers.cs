using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    [ApiController]
    [Route("api/FotoMascota")]
    public class FotoMascotaControllers : ControllerBase
    {
        private readonly Context context;

        public FotoMascotaControllers(Context context)
        {
            this.context = context;
        }
    }
}
