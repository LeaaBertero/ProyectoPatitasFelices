using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class PrecioControllers : ControllerBase
    {
        private readonly Context context;

        public PrecioControllers(Context context)
        {
            this.context = context;
        }
    }
}
