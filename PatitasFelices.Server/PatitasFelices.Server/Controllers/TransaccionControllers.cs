using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

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
    }
}
