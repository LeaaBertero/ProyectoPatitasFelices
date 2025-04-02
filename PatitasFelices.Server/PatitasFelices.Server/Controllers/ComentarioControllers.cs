using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class ComentarioControllers : ControllerBase
    {
        private readonly Context context;

        public ComentarioControllers(Context context)
        {
            this.context = context;
        }
    }
}
