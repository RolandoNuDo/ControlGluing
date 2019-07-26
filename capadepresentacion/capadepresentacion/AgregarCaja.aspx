<%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="AgregarCaja.aspx.cs" Inherits="capadepresentacion.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="content-header">
        <h1 style="text-align:center">Registro de Caja</h1>
    </section>
    <section class="content">
        <div class="row">
            <div class ="col-md-12">
                <div class="box-primary">
                    <div class="box-body">                     
                        <div class="form-group">
                            <label>Numero de Serie</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtNumSerie" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>Rack</label>
                        </div>
                        <div class="form-group">
                            <asp:TextBox ID="txtRack" runat="server" Text="" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
       
            <div align="center">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btnRegistrar" runat="server" Text="Agregar" Width="200px" CssClass="btn btn-primary" OnClick="btnRegistrar_Click"/>
                        </td>
                        <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
                        <td>
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" Width="200px" CssClass="btn btn-danger"/>
                        </td>
                    </tr>
                </table>
            </div>
        <br />
        <div class="row">
            <div class="col-xs-12">
                <div class="box box-primary">
                    <div class="box-header">
                        <h3 class="box-title">Lista de Cajas</h3>
                    </div>
                    <div class="box-body table-responsive">
                        <table id="tbl_cajas" class="table table-bordered table-hover">
                            <thead>
                                <tr>                                   
                                    <th>Numero Serie</th>
                                    <th>Fecha/Hora Entrada</th>
                                    <th>Rack</th>
                                    <th>Nivel</th>
                                    <th>Fila</th>
                                    <th>Hora de Liberacion</th>
                                    <th>No Parte</th>
                                </tr>
                            </thead>
                            <tbody id="tbl_body_table">

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
