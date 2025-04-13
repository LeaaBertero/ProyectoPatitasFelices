using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class TarjetaRepositorio : Repositorio<Tarjeta>, ITarjetaRepositorio
    {
        public TarjetaRepositorio(Context context) : base(context)
        {
        }
    }
    
}
