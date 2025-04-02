using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class MascotaControllers : ControllerBase
    {
        private readonly Context context;

        public MascotaControllers(Context context)
        {
            this.context = context;
        }
    }
}
