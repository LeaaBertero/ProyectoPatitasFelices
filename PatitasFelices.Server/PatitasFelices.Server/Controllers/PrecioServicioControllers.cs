using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class PrecioServicioControllers : ControllerBase
    {
        private readonly Context context;

        public PrecioServicioControllers(Context context)
        {
            this.context = context;
        }
    }
}
