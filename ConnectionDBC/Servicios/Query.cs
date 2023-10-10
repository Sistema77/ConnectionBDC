﻿using ConnectionDBC.Dtos;
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
    internal class Query
    {
        public void insertLibro(long idLibro, string titulo, string autor, string isbn, int edicion)
        {

        }
        public void selectLibro(NpgsqlConnection conn)
        {
            string query = "SELECT * FROM public.gbp_alm_cat_libros";
            try { 
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
            }catch (Exception ex)
            {
                Console.WriteLine("[Error: Query-selectLibro]" + ex.Message);
            }
        }

        public void updateLibro(long idLibro, string titulo, string autor, string isbn, int edicion, NpgsqlConnection conn)
        {

        }
        public void deleteLibro(long idLibro, NpgsqlConnection conn)
        {
            string query = "DELETE FROM public.gbp_alm_cat_libros WHERE id_libro = @idLibro;";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("id", idLibro);

                cmd.ExecuteReader();

                Console.WriteLine("[INFO: Dato Borrado con exito]");

            }
            catch (Exception ex)
            {
                Console.WriteLine("[Error: Query-deleteLibro]" + ex.Message);
            }
        }
    }
}