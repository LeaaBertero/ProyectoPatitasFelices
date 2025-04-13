using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class ReservaRepositorio : Repositorio<Reserva>, IReservaRepositorio
    {
        public ReservaRepositorio(Context context) : base(context)
        {
        }
    }
}
