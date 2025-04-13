using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class PrecioRepositorio : Repositorio<Precio> , IPrecioRepositorio
    {
        public PrecioRepositorio(Context context) : base(context)
        {
        }
    }
}
