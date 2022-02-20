using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoBD2U3.POJOS;
using ProyectoBD2U3.BACKEND;
using System.Text.RegularExpressions;

namespace ProyectoBD2U3.FRONTEND
{
    public partial class frmAgregarLibro : System.Web.UI.Page
    {
        string idLibro = "";
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Request.Params["parametro"] != null)
                {
                    idLibro = Request.Params["parametro"];

                    txtID.Visible = true;
                    txtID.Enabled = false;
                    Label1.Visible = true;
                    txtID.Text = idLibro;

                    this.Title = "Editar libro " + idLibro;
                    clsDaoLibros daoLibro=new clsDaoLibros();
                try{
                    if (!Page.IsPostBack)
                    {
                        clsLibros libro = daoLibro.ObtenerLibro(idLibro);
                        txtID.Text = idLibro;
                        txtISBN.Text = libro.ISBN;
                        txtTitulo.Text = libro.Titulo;
                        txtNumEdicion.Text = Convert.ToString(libro.NumEdicion);
                        txtAnio.Text = Convert.ToString(libro.AnioPublicacion);
                        txtAutores.Text = libro.NombresAutores;
                        txtPais.Text = libro.PaisPublicacion;
                        txtSinopsis.Text = libro.Sinopsis;
                        txtCarrera.Text = libro.Carrera;
                        txtMateria.Text = libro.Materia;
                    }
                }
                catch (NoControllerException ex)
                {
                    string mensaje = string.Format("alert('{0}');", ex.Message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                }
                catch (ConnectionException ex)
                {
                    string mensaje = string.Format("alert('{0}');", ex.Message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                }
                catch (Exception ex)
                {
                    string mensaje = "alert('Operacion fallida.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                }
                }
                else
                {
                    txtID.Visible = false;
                    Label1.Visible = false;
                    this.Title = "Agregar libro";
                }
            
        }
    

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            if (esValido())
            {
                clsLibros libro = llenarDatos();
                clsDaoLibros daoLibros = new clsDaoLibros();
                bool seAgrego = false;
                

                //TODO: Avisar si se agrego o no
                try
                {
                    if (idLibro.Length == 0){ //Dato nuevo, INSERT
                        seAgrego = daoLibros.InsertarLibro(libro);
                    }
                    else{ //Dato a actualizar, UPDATE
                        libro.ID = Convert.ToInt32(txtID.Text);
                        seAgrego = daoLibros.ActualizarLibro(libro);
                    }
                    if (seAgrego)
                    {
                        string mensaje = "alert('Libro almacenado correctamente');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                        Response.Redirect("Default.aspx");
                    }
                    else {
                        string mensaje = "alert('No fue posible almacenar el libro');";
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                        Response.Redirect("Default.aspx");
                    }
                }
                catch (NoControllerException ex){
                    string mensaje = string.Format("alert('{0}');", ex.Message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                }
                catch (Exception ex)
                {
                    string mensaje = string.Format("alert('{0}');", ex.Message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                }
            }

        }

        private clsLibros llenarDatos() {
            clsLibros libro = new clsLibros();
            libro.ISBN = txtISBN.Text;
            libro.Titulo = txtTitulo.Text;
            libro.NumEdicion = Convert.ToInt32(txtNumEdicion.Text);
            libro.NombresAutores = txtAutores.Text;
            libro.PaisPublicacion = txtPais.Text;
            libro.Sinopsis = txtSinopsis.Text;
            libro.Carrera = txtCarrera.Text;
            libro.Materia = txtMateria.Text;
            libro.AnioPublicacion = Convert.ToInt32(txtAnio.Text);
            return libro; 
        }

        private bool esValido()
        {
            bool camposValidos = true;
            Regex erISBN = new Regex("^[0-9]{13}$");
            string ISBN = txtISBN.Text.Trim();
            if (ISBN.Equals(""))
            {
                string mensaje = "alert('Debe escribir un ISBN para el libro');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            } else if (!erISBN.IsMatch(ISBN)) {
                string mensaje = "alert('Debe escribir un ISBN de 13 dígitos');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            string titulo = txtTitulo.Text.Trim();
            if (titulo.Equals(""))
            {
                string mensaje = "alert('Debe agregar el Titulo del libro');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            Regex erEdicion = new Regex("^[0-9]+$");
            string numEdicion = txtNumEdicion.Text.Trim();
            if (numEdicion.Equals(""))
            {
                string mensaje = "alert('Debe agregar un número de edición');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }
            else if (!erEdicion.IsMatch(numEdicion)) {
                string mensaje = "alert('Debe escribir un número de edición en formato numérico');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            string autores = txtAutores.Text.Trim();
            if (autores.Equals(""))
            {
                string mensaje = "alert('Debe agreguar el/los autor(s) del libro');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            string pais = txtPais.Text.Trim();
            if (pais.Equals(""))
            {
                string mensaje = "alert('Debe agregar el país de publicación del libro');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            string sinopsis = txtSinopsis.Text.Trim();
            if (sinopsis.Equals(""))
            {
                string mensaje = "alert('Debe agregar la sinopsis del libro');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            string carrera = txtCarrera.Text.Trim();
            if (carrera.Equals(""))
            {
                string mensaje = "alert('Debe agregar una carrera');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            string materia = txtMateria.Text.Trim();
            if (materia.Equals(""))
            {
                string mensaje = "alert('Debe agregar una materia');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            DateTime fecha = DateTime.Now;
            int anioAct = fecha.Year;
            Regex erAnio = new Regex("^[0-9]{4}$");
            if (txtAnio.Text.Trim().Equals("")) {
                string mensaje = "alert('Debe agregar un año de publicación que no sobrepase el año actual.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }

            if (!erAnio.IsMatch(txtAnio.Text.Trim()))
            {
                string mensaje = "alert('Debe agregar un año de publicación en formato numérico.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                camposValidos = false;
            }
            else {
                if (Convert.ToInt32(txtAnio.Text.Trim()) > anioAct) {
                    string mensaje = "alert('Debe agregar un año de publicación que no sobrepase el año actual.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                    camposValidos = false;
                }
            }

           

            return camposValidos;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

       
    }
}