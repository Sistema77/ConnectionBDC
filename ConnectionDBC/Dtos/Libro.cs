using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectionDBC.Dtos
{
    internal class Libro
    {
        //**Clase que nos usaremos para pasar a DTO*/

        //Atributos:
        private long idLibro;
        private string titulo;
        private string autor;
        private string isbn;
        private int edicion;

        //Getters / Setters:
        public long IdLibro { get => idLibro; set => idLibro = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string Autor { get => autor; set => autor = value; }
        public string Isbn { get => isbn; set => isbn = value; }
        public int Edicion { get => edicion; set => edicion = value; }
        //Metodos:

        //Constructores:
        public Libro(long idLibro, string titulo, string autor, string isbn, int edicion)
        {
            this.idLibro = idLibro;
            this.titulo = titulo;
            this.autor = autor;
            this.isbn = isbn;
            this.edicion = edicion;
        }
    }
}
