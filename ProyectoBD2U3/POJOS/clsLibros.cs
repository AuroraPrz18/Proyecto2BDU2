using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoBD2U3.POJOS
{
    public class clsLibros
    {
		private int id;
		private string isbn;
		private string titulo;
		private int numEdicion;
		private int anioPublicacion;
		private string nombresAutores;
		private string paisPublicacion;
		private string sinopsis;
		private string carrera;
		private string materia;

		public int ID
        {
            get { return id; }
            set { id = value; }
        }

		public string ISBN
        {
			get { return isbn; }
			set { isbn = value; }
        }
		
		public string Titulo
        {
			get { return titulo; }
			set { titulo = value; }
        }
		
		public int NumEdicion
        {
            get { return numEdicion; }
            set { numEdicion = value; }
        }

		public int AnioPublicacion
        {
			get { return anioPublicacion; }
            set { anioPublicacion = value; }
        }
		
		public string NombresAutores
        {
			get { return nombresAutores; }
			set { nombresAutores = value; }
        }

		public string PaisPublicacion
        {
            get { return paisPublicacion; }
            set { paisPublicacion = value; }
        }

		public string Sinopsis
        {
            get { return sinopsis; }
            set { sinopsis = value; }
        }

		public string Carrera
        {
            get { return carrera; }
            set { carrera = value; }
        }

		public string Materia
        {
            get { return materia; }
			set { materia = value; }
        }
	}
}