using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class FotoRepositorio : Repositorio<Foto>, IFotoRepositorio
    {
        public FotoRepositorio(Context context) : base(context)
        {
        }
    }
}
