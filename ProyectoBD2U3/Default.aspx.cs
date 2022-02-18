using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoBD2U3.BACKEND;
using ProyectoBD2U3.POJOS;

namespace ProyectoBD2U3.FRONTEND
{
    public partial class frmLibros : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            actualizarTabla();
            btnEliminar.OnClientClick = "return(confirm('¿Estás seguro de que quieres eliminar el libro?'));";
        }

        private void actualizarTabla()
        {
            try
            {
                clsDaoLibros daoLibros = new clsDaoLibros();
                List<clsLibros> libros = daoLibros.ListaLibros();
                gvLibros.DataSource = libros;
                gvLibros.DataBind();
            }
            catch (NoControllerException ex)
            {
                //TODO: Investigar el equivalente a messagebox
                foreach (Control control in this.Controls)
                {
                    control.Visible = false;
                }
                Response.Write(ex.Message);
                //MessageBox.Show(this, ex.Message, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ConnectionException ex)
            {
                foreach (Control control in this.Controls)
                {
                    control.Visible = false;
                }
                Response.Write(ex.Message);
                //MessageBox.Show(this, ex.Message, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                foreach (Control control in this.Controls)
                {
                    control.Visible = false;
                }
                Response.Write("Ha ocurrido un error al realizar la operación");
                //MessageBox.Show(this, "Ha ocurrido un error al realizar la operación", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAgregarLibro.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAgregarLibro.aspx");
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //TODO:¿Ponemos un textbox para que el usuario escriba el ID del libro a eliminar o cómo?
        }
    }
}