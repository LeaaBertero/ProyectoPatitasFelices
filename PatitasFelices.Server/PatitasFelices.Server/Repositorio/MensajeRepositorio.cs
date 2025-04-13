using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class MensajeRepositorio : Repositorio<Mensaje>, IMensajeRepositorio
    {
        public MensajeRepositorio(Context context) : base(context)
        {
        }
    }
}
