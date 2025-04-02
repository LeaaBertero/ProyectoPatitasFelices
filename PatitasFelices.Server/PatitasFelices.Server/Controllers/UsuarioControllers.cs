using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class UsuarioControllers : ControllerBase
    {
        private readonly Context context;

        public UsuarioControllers( Context context)
        {
            this.context = context;
        }
    }
}
