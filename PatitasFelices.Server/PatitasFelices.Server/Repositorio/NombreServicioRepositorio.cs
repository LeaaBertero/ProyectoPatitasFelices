using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class NombreServicioRepositorio : Repositorio<NombreServicio>, INombreServicio
    {
        public NombreServicioRepositorio(Context context) : base(context)
        {
        }
    }
}
