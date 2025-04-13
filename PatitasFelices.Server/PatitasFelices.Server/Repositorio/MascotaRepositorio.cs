using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class MascotaRepositorio : Repositorio<Mascota>, IMascotaRepositorio
    {
        public MascotaRepositorio(Context context) : base(context)
        {
        }
    }
}
