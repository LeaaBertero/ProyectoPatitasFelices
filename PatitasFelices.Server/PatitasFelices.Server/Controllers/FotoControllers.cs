using Microsoft.AspNetCore.Mvc;
using PatitasFelices.BD.Data;

namespace PatitasFelices.Server.Controllers
{
    public class FotoControllers : ControllerBase
    {
        private readonly Context context;

        public FotoControllers(Context context)
        {
            this.context = context;
        }
    }
}
