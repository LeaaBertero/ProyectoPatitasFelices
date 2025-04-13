using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class TransaccionRepositorio : Repositorio<Transaccion>, ITransaccionRepositorio
    {
        public TransaccionRepositorio(Context context) : base(context)
        {
        }
    }
    
}
