<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SacarCajaScan.aspx.cs" Inherits="capadepresentacion.SacarCajaScan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <section class="content-header">
            <h1 style="text-align: center">Registro de Caja</h1>
        </section>
        <section class="content">
            <div class="row" align="center">
                <div class="col-md-12">
                    <div class="box-primary">
                        <div class="box-body">
                            <div class="form-group">
                                <label>Numero de Serie</label>
                            </div>
                            <div class="form-group">
                                <asp:TextBox ID="txtNumSerie" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div align="center">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnRegistrar" runat="server" Text="Sacar" Width="200px" CssClass="btn btn-primary" OnClick="btnRegistrar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCambiar" runat="server" Text="Ingresar Caja" Width="200px" CssClass="btn btn-danger" OnClick="btnCambiar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnLogOut" runat="server" Text="Salir" Width="200px" CssClass="btn btn-danger" OnClick="btnLogOut_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </section>
    </form>
</body>
</html>
