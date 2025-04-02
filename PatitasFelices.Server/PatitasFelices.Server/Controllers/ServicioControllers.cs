using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class ServicioControllers : ControllerBase
    {
        private readonly Context context;

        public ServicioControllers(Context context)
        {
            this.context = context;
        }
    }
}
