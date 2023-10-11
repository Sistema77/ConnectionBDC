using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDBC.Servicios
{
    internal interface ConnectionInterface
    {
        public NpgsqlConnection generarConexion();

        public void cerrarConexion(NpgsqlConnection conn);
    }
}
