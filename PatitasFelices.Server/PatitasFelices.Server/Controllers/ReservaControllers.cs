using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class ReservaControllers : ControllerBase
    {
        private readonly Context context;

        public ReservaControllers(Context context)
        {
            this.context = context;
        }
    }
}
