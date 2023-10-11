using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDBC.Servicios
{
    internal interface QueryInterface
    {
        public void insertLibro(string titulo, string autor, string isbn, int edicion, NpgsqlConnection conn);

        public void selectLibro(NpgsqlConnection conn);

        public void updateLibro(long idLibro, string titulo, string autor, string isbn, int edicion, NpgsqlConnection conn);

        public void deleteLibro(long idLibro, NpgsqlConnection conn);
    }
}
