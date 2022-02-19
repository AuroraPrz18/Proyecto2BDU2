using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProyectoBD2U3.POJOS;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ProyectoBD2U3.BACKEND
{
    public class clsDaoLibros
    {
        public bool EliminarLibro(string id)
        {
            SqlCommand delete = new SqlCommand(
                @"delete from Libros where ID=@id");

            delete.Parameters.AddWithValue("@id", id);

            int resultado = Conexion.ejecutarSentencia(delete);

            return (resultado > 0);
        }

        public bool InsertarLibro(clsLibros libro)
        {
            SqlCommand insert = new SqlCommand(
                @"insert into Libros (ISBN, Titulo, NumEdicion, AnioPublicacion, NombresAutores, "
                + "PaisPublicacion, Sinopsis, Carrera, Materia) "
                + "values(@isbn, @titulo, @numEdicion, @anioPublicacion, @nombresAutores, "
                + "@paisPublicacion, @sinopsis, @carrera, @materia)");

            insert.Parameters.AddWithValue("@isbn", libro.ISBN);
            insert.Parameters.AddWithValue("@titulo", libro.Titulo);
            insert.Parameters.AddWithValue("@numEdicion", libro.NumEdicion);
            insert.Parameters.AddWithValue("@anioPublicacion", libro.AnioPublicacion);
            insert.Parameters.AddWithValue("@nombresAutores", libro.NombresAutores);
            insert.Parameters.AddWithValue("@paisPublicacion", libro.PaisPublicacion);
            insert.Parameters.AddWithValue("@sinopsis", libro.Sinopsis);
            insert.Parameters.AddWithValue("@carrera", libro.Carrera);
            insert.Parameters.AddWithValue("@materia", libro.Materia);

            int resultado = Conexion.ejecutarSentencia(insert);

            return (resultado > 0);
        }

        public bool ActualizarLibro(clsLibros libro)
        {

            SqlCommand update = new SqlCommand(@"update Libros "
                + "set ISBN = @isbn, Titulo = @titulo, NumEdicion = @numEdicion, AnioPublicacion = @anioPublicacion, "
                + "NombresAutores = @nombresAutores, PaisPublicacion = @paisPublicacion, Sinopsis =  @sinopsis, "
                + "Carrera = @carrera, Materia = @materia"
                + "where ID = @id");

            update.Parameters.AddWithValue("@id", libro.ID);
            update.Parameters.AddWithValue("@isbn", libro.ISBN);
            update.Parameters.AddWithValue("@titulo", libro.Titulo);
            update.Parameters.AddWithValue("@numEdicion", libro.NumEdicion);
            update.Parameters.AddWithValue("@anioPublicacion", libro.AnioPublicacion);
            update.Parameters.AddWithValue("@nombresAutores", libro.NombresAutores);
            update.Parameters.AddWithValue("@paisPublicacion", libro.PaisPublicacion);
            update.Parameters.AddWithValue("@sinopsis", libro.Sinopsis);
            update.Parameters.AddWithValue("@carrera", libro.Carrera);
            update.Parameters.AddWithValue("@materia", libro.Materia);

            int resultado = Conexion.ejecutarSentencia(update);

            return (resultado > 0);
        }

        public List<clsLibros> ListaLibros()
        {
            SqlCommand consulta =
                new SqlCommand(@"select * from Libros");

            DataTable resultado = Conexion.ejecutarConsulta(consulta);
            List<clsLibros> lstLibros = new List<clsLibros>();

            if (resultado != null)
            {
                foreach (DataRow fila in resultado.Rows)
                {
                    clsLibros libro = new clsLibros();
                    libro.ID = Convert.ToInt32(fila[0]);
                    libro.ISBN = fila[1].ToString();
                    libro.Titulo = fila[2].ToString();
                    libro.NumEdicion = Convert.ToInt32(fila[3]);
                    libro.AnioPublicacion = Convert.ToInt32(fila[4]);
                    libro.NombresAutores = fila[5].ToString();
                    libro.PaisPublicacion = fila[6].ToString();
                    libro.Sinopsis = fila[7].ToString();
                    libro.Carrera = fila[8].ToString();
                    libro.Materia = fila[9].ToString();
                    lstLibros.Add(libro);
                }
            }

            return lstLibros;
        }


        public clsLibros ObtenerLibro(String idLibro)
        {
            SqlCommand consulta =
                new SqlCommand(@"select * from Libros where ID=@id");

            consulta.Parameters.AddWithValue("@id", idLibro);

            DataTable resultado = Conexion.ejecutarConsulta(consulta);

            if (resultado != null && resultado.Rows.Count > 0)
            {
                DataRow fila = resultado.Rows[0];
                clsLibros libro = new clsLibros();
                libro.ID = Convert.ToInt32(fila[0]);
                libro.ISBN = fila[1].ToString();
                libro.Titulo = fila[2].ToString();
                libro.NumEdicion = Convert.ToInt32(fila[3]);
                libro.AnioPublicacion = Convert.ToInt32(fila[4]);
                libro.NombresAutores = fila[5].ToString();
                libro.PaisPublicacion = fila[6].ToString();
                libro.Sinopsis = fila[7].ToString();
                libro.Carrera = fila[8].ToString();
                libro.Materia = fila[9].ToString();
                return libro;
            }
            else
                return null;
        }
    }
}