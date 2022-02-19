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
                btnAgregar.Visible = false;
                string mensaje = string.Format("alert('{0}');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
                //Response.Write(ex.Message);
            }
            catch (ConnectionException ex)
            {
                btnAgregar.Visible = false;
                string mensaje = string.Format("alert('{0}');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
            }
            catch (Exception ex)
            {
                btnAgregar.Visible = false;
                string mensaje = "alert('Ha ocurrido un error al realizar la operación');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Response.Redirect("frmAgregarLibro.aspx");
        }

        protected void gvLibros_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int pos = e.RowIndex;
            clsDaoLibros daoLibros = new clsDaoLibros();
            string mensaje;
            try
            {
                if (daoLibros.EliminarLibro(gvLibros.Rows[pos].Cells[1].Text))
                {
                    mensaje = "alert('Libro eliminado exitosamente');";
                    actualizarTabla();
                }
                else
                {
                    mensaje = "alert('Ha ocurrido un error al eliminar el libro');";
                }
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
            }
            catch (NoControllerException ex)
            {
                mensaje = string.Format("alert('{0}');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
            }
            catch (ConnectionException ex)
            {
                mensaje = string.Format("alert('{0}');", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
            }
            catch (Exception ex)
            {
                mensaje = "alert('Ha ocurrido un error al realizar la operación');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", mensaje, true);
            }
        }

        protected void gvLibros_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int pos = e.NewEditIndex;
            Response.Redirect("frmAgregarLibro.aspx?parametro="+gvLibros.Rows[pos].Cells[1].Text);
        }

        protected void gvLibros_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton db = (LinkButton)e.Row.Cells[0].Controls[2];
                db.OnClientClick = "return confirm('¿Está seguro de que desea eliminar el libro?');";
            }
        }
    }
}