using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class FotoMascotaRepositorio : Repositorio<FotoMascota>, IFotoMascotaRepositiorio
    {
        public FotoMascotaRepositorio(Context context) : base(context)
        {
        }
    }
}
