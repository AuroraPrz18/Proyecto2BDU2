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
                //MessageBox.Show(this, ex.Message, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ConnectionException ex)
            {
                //MessageBox.Show(this, ex.Message, "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(this, "Ha ocurrido un error al realizar la operación", "Operación fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAgregarLibro.aspx");
        }
    }
}