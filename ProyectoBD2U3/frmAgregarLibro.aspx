<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmAgregarLibro.aspx.cs" Inherits="ProyectoBD2U3.FRONTEND.frmAgregarLibro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Libro</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.1.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-1BmE4kWBq78iYhFldvKuhfTAU6auU8tT94WrHftjDbrCEXSU1oBoqyl2QvZ6jIW3" crossorigin="anonymous"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
</head>
<body>
    <h2 style="margin-top:0px; text-align:center; padding-top:20px; padding-bottom:20px;background-color: rgb(21,76,121); color: rgb(255,255,255);">Gestionar Libro</h2>
    <div id="encierraForm1" style="margin-left:20%; margin-right:20%">
        <form id="form1" runat="server">
            <div class="form-group" >
                <div class="form-group col-1" style="margin:20px">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="ID"></asp:Label>
                    <asp:TextBox ID="txtID" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-3" style="margin:20px">
                    <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="ISBN"></asp:Label>
                    <asp:TextBox ID="txtISBN" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-12" style="margin:20px">
                    <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Titulo"></asp:Label>
                    <asp:TextBox ID="txtTitulo" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-3" style="margin:20px">
                    <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="No. de Edición"></asp:Label>
                    <asp:TextBox ID="txtNumEdicion" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-3" style="margin:20px">
                    <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Año de Publicación"></asp:Label>
                    <asp:TextBox ID="txtAnio" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-12" style="margin:20px">
                    <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Nombre De Los Autores"></asp:Label>
                    <asp:TextBox ID="txtAutores" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-3" style="margin:20px">
                    <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="País de Publicación"></asp:Label>
                    <asp:TextBox ID="txtPais" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-12" style="margin:20px">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Sinopsis "></asp:Label>
                    <asp:TextBox ID="txtSinopsis" class="form-control" runat="server" style="margin-left: 0px"></asp:TextBox>
                </div>
                <div class="form-group col-md-12" style="margin:20px">
                    <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Carrera"></asp:Label>
                    <asp:TextBox ID="txtCarrera" class="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group col-md-12" style="margin:20px">
                    <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Materia "></asp:Label>
                    <asp:TextBox ID="txtMateria" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
           <div class="container" align="center">
            <asp:Button ID="btnCancelar" class="btn btn-primary" style="margin: 20px; padding-left: 20px; padding-right: 20px; padding-top: 10px; padding-bottom: 10px; background-color:rgb(74, 92, 128); color:rgb(255,255,255)" runat="server" Font-Bold="True" Text="Cancelar" OnClick="btnCancelar_Click" />
            <asp:Button ID="btnGuardar" class="btn btn-primary" style="margin: 20px; padding-left: 20px; padding-right: 20px; padding-top: 10px; padding-bottom: 10px; background-color:rgb(74, 92, 128); color:rgb(255,255,255)" runat="server" Font-Bold="True" Text="Guardar" OnClick="btnGuardar_Click" />
           </div> 
        </form>

    </div>
</body>
</html>
