<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLibros.aspx.cs" Inherits="ProyectoBD2U3.FRONTEND.frmLibros" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
        .auto-style2 {
            width: 40%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    
    <p>
        <asp:Table ID="tblLibros" runat="server">
        </asp:Table>
        </p>
        <p>
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" />
            <asp:Button ID="btnModificar" runat="server" Text="Modificar" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
        </p>
    </form>
    
    </body>
</html>
