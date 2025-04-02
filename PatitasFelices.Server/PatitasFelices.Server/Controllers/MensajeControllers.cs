using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

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
    }
}
