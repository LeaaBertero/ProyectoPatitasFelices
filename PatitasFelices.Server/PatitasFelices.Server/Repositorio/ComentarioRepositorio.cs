using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class ComentarioRepositorio : Repositorio<Comentario>, IComentarioRepositorio
    {
        public ComentarioRepositorio(Context context) : base(context)
        {
        }
    }
}
