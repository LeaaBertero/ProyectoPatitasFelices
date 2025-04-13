using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Context context) : base(context)
        {
        }
    }
}
