using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class ServicioRepositorio : Repositorio<Servicio>, IServicioRepositorio
    {
        public ServicioRepositorio(Context context) : base(context)
        {
        }
    }
}


