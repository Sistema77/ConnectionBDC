using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace ConnectionDBC.Servicios
{
    internal class connection : ConnectionInterface
    {
        /** Clase para abrir y cerrar la conexion con la base de datos */
        public NpgsqlConnection generarConexion()
        {
            /** Genera una conexion con la base de datos */
            string stringConexionPostgresql = ConfigurationManager.ConnectionStrings["stringConexion"].ConnectionString;
            Console.WriteLine("[INFORMACIÓN-ConexionPostgresqlImplementacion-generarConexionPostgresql] Cadena conexión: " + stringConexionPostgresql);
            NpgsqlConnection conn = null;
            string estado;

            if (!string.IsNullOrWhiteSpace(stringConexionPostgresql))
            {
                try
                {
                    conn = new NpgsqlConnection(stringConexionPostgresql);
                    conn.Open();

                    estado = conn.State.ToString();

                    if (estado.Equals("Open"))
                    {
                        Console.WriteLine("[INFORMACIÓN-connection-generarConexion] Estado conexión: " + estado);
                    }
                    else
                    {
                        conn = null;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("[ERROR-connection-generarConexion] Error al generar la conexión: " + e);
                    conn = null;
                    return conn;
                }
            }
            return conn;
        }

        public void cerrarConexion(NpgsqlConnection conn)
        {
            /** Cierra la conexion con la base de datos*/
            try
            {
                conn.Close();
                Console.WriteLine("[INFORMACIÓN-connection-cerrarConexion] Conexion Cerrada ");
            }
            catch (Exception e)
            {
                Console.WriteLine("[Error-connection-cerrarConexion] " + e);
            }
        }
    }
}