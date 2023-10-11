using ConnectionDBC.Dtos;
using NpgsqlTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Npgsql;
using System.Threading.Tasks;
using System.Data;

namespace ConnectionDBC.Servicios
{
    internal class Query : QueryInterface
    {
        //** Clase que realiza el CRUD */
        public void insertLibro(string titulo, string autor, string isbn, int edicion, NpgsqlConnection conn)
        {
            /** Insertar un nuevo libro en la base de Datos */
            string query = "INSERT INTO public.gbp_alm_cat_libros( titulo, autor, isbn, edicion ) VALUES ( @titulo, @autor, @isbn, @edicion );";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("titulo", titulo);
                cmd.Parameters.AddWithValue("autor", autor);
                cmd.Parameters.AddWithValue("isbn", isbn);
                cmd.Parameters.AddWithValue("edicion", edicion);

                cmd.ExecuteNonQuery();

                Console.WriteLine("[INFO: Libro Insertado con exito]");
                cmd.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error: Query-insertLibro]" + ex.Message);
            }
        }
        public void selectLibro(NpgsqlConnection conn)
        {
            /**Muestra todos los Libros que hay en la base de datos */
            try {
                string query = "SELECT * FROM public.gbp_alm_cat_libros";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                using (NpgsqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Crear un objeto Libro para almacenar los datos
                        Libro libro = new Libro(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4));

                        // Imprimir los datos del libro
                        Console.WriteLine("Id: " + libro.IdLibro);
                        Console.WriteLine("Titulo: " + libro.Titulo);
                        Console.WriteLine("Autor: " + libro.Autor);
                        Console.WriteLine("Isbn: " + libro.Isbn);
                        Console.WriteLine("Editor: " + libro.Edicion);
                        Console.WriteLine();
                    }
                }
                cmd.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error: Query-selectLibro]" + ex.Message);
            }
        }

        public void updateLibro(long idLibro, string titulo, string autor, string isbn, int edicion, NpgsqlConnection conn)
        {
            /** Actualiza un Libro ya existente */
            
            try
            {
                string query = "UPDATE public.gbp_alm_cat_libros SET titulo= @titulo, autor= @autor, isbn= @isbn, edicion= @edicion WHERE id_libro = @idLibro;";

                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("idLibro", idLibro);
                cmd.Parameters.AddWithValue("titulo", titulo);
                cmd.Parameters.AddWithValue("autor", autor);
                cmd.Parameters.AddWithValue("isbn", isbn);
                cmd.Parameters.AddWithValue("edicion", edicion);

                cmd.ExecuteNonQuery();

                Console.WriteLine("[INFO: Libro UpDate con exito]");
                cmd.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error: Query-insertLibro]" + ex.Message);
            }
        }
        public void deleteLibro(long idLibro, NpgsqlConnection conn)
        {
            /** Elimina un libro */
            string query = "DELETE FROM public.gbp_alm_cat_libros WHERE id_libro = @idLibro;";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);

                cmd.Parameters.AddWithValue("idLibro", idLibro);

                cmd.ExecuteNonQuery();

                Console.WriteLine("[INFO: Dato Borrado con exito]");

                cmd.Cancel();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error: Query-deleteLibro]" + ex.Message);
            }
        }
    }
}