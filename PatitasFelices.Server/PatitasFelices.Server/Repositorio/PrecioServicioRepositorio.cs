using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class PrecioServicioRepositorio : Repositorio<PrecioServicio>, IPrecioServicio
    {
        public PrecioServicioRepositorio(Context context) : base(context)
        {
        }
    }
}
