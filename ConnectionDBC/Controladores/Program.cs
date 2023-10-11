using ConnectionDBC.Servicios;
using Npgsql;
using System.Configuration;
public class program 
{
    public static void Main(string[] args) 
    {
        // Initialize
        
        NpgsqlConnection conn;
        connection con = new connection();
        Query consultas = new Query();
        byte opcion = 0;
        long idLibro = 0;
        string titulo = null;
        string autor = null;
        string isbn = null;
        int edicion = 0;
        string entrada = null;

        // Algorithm

        conn = con.generarConexion();
        
        do
        {
            Console.WriteLine("-----Menu-----");
            Console.WriteLine();
            Console.WriteLine("1 - Seleccionar Libros");
            Console.WriteLine("2 - Insertar Libro");
            Console.WriteLine("3 - Borrar Libro");
            Console.WriteLine("4 - Actualizar Libro");
            Console.WriteLine("5 - Salir");
            Console.WriteLine();
            Console.WriteLine("--------------");

            Console.Write("Opcion: ");

            
            if (byte.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("--------------");

                switch (opcion)
                {
                    case 1:
                                    // SELECT
                        consultas.selectLibro(conn);
                    break;
                    case 2:
                                    // INSERT
                        do
                        {
                            Console.WriteLine("---Insertar Libro---");

                            try
                            {
                                Console.Write("Titulo: ");
                                titulo = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("Autor: ");
                                autor = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("ISBN: ");
                                isbn = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("Edicion: ");
                                edicion = int.Parse(Console.ReadLine()); 
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }

                        } while (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(autor) || string.IsNullOrEmpty(isbn) || 
                        string.IsNullOrEmpty(edicion.ToString()) || edicion == 0);

                        consultas.insertLibro(titulo, autor, isbn, edicion, conn);

                        break;
                    case 3:
                                        // DELETER
                        Console.Write("Ponga el id del Libro que desea Eliminar: ");
  
                        entrada = Console.ReadLine();

                        if (long.TryParse(entrada, out idLibro))
                        {
                            consultas.deleteLibro(idLibro, conn);
                        }
                        else
                        {
                            Console.WriteLine($"'{entrada}' no es un número válido.");
                        }
                        
                    break;
                    case 4:
                                // UPDATE
                        do
                        {
                            Console.WriteLine("---Update Libro---");

                            try
                            {
                                Console.Write("Id Libro: ");
                                idLibro = long.Parse(Console.ReadLine());
                                Console.WriteLine();

                                Console.Write("Titulo: ");
                                titulo = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("Autor: ");
                                autor = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("ISBN: ");
                                isbn = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("Edicion: ");
                                edicion = int.Parse(Console.ReadLine());
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Error: " + ex.Message);
                            }

                        } while ( string.IsNullOrEmpty(idLibro.ToString()) || idLibro == 0 || string.IsNullOrEmpty(titulo) || 
                        string.IsNullOrEmpty(autor) || string.IsNullOrEmpty(isbn) || string.IsNullOrEmpty(edicion.ToString()) || 
                        edicion == 0);

                        consultas.updateLibro(idLibro, titulo, autor, isbn, edicion, conn);

                        break;
                    case 5:
                                // EXIT
                        Console.WriteLine("Adiós!");
                    break;
                    default:
                        Console.WriteLine("Opción no válida");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Por favor, introduce un número válido.");
            }
        } while (opcion != 5);

        con.cerrarConexion(conn);
    }
}