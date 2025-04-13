using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class FotoUsuarioRepositorio : Repositorio<FotoUsuario>, IFotoUsuarioRepositorio
    {
        public FotoUsuarioRepositorio(Context context) : base(context)
        {
        }
    }
}
