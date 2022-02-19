using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoBD2U3.POJOS;
using ProyectoBD2U3.BACKEND;

namespace ProyectoBD2U3.FRONTEND
{
    public partial class frmAgregarLibro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Params["type"] != null)
            {
                string type = Request.Params["type"];
                if (type.Equals("0")) //Agregar
                {
                    txtID.Visible = false;
                    Label1.Visible = false;
                }
                else //Modificar
                {
                    //TODO: revisar si tiene el parametro de ID, si si cargar los datos
                    txtID.Visible = true;
                    Label1.Visible = true;
                }

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            clsLibros libro = new clsLibros();
            //TODO:Faltan validaciones
            libro.ISBN = txtISBN.Text;
            libro.Titulo = txtTitulo.Text;
            libro.NumEdicion = Convert.ToInt32(txtNumEdicion.Text);
            libro.NombresAutores = txtAutores.Text;
            libro.PaisPublicacion = txtPais.Text;
            libro.Sinopsis = txtSinopsis.Text;
            libro.Carrera = txtCarrera.Text;
            libro.Materia = txtMateria.Text;
            libro.AnioPublicacion = Convert.ToInt32(txtAnio.Text);
            clsDaoLibros daoLibros = new clsDaoLibros();
            bool seAgrego = daoLibros.InsertarLibro(libro);
            //TODO: Avisar si se agrego o no
            if (seAgrego)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}