﻿using PatitasFelices.BD.Data;
using PatitasFelices.BD.Data.Entity;

namespace PatitasFelices.Server.Repositorio
{
    public class NombreServicioRepositorio : Repositorio<NombreServicio>, INombreServicioRepositorio
    {
        public NombreServicioRepositorio(Context context) : base(context)
        {
        }
    }
}
