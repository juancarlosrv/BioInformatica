<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebUpdateTypeProduct.aspx.cs" Inherits="VeterinarySmiles_Web.WebUpdateTypeProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">




    <form id="form1" runat="server">

       <div class="form-box">
           <section class="content-header">
                <h1 style="text-align:center">Actualizacion de Tipos de Productos</h1>
            </section>

           <section class="content">
                <div class="row">
                    <div class="col-md-6">

                        <div class="box-body">

                            <div class="form=group">
                                <asp:Label runat="server">Nombre :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form=group">
                                <asp:Label runat="server">Descripcion :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            
                           
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                        </div>
                    </div>

                    <div class="col-md-6">
                        <br /><br />
                        <asp:Button ID="btnSave" Text="Guardar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' OnClick="btnSave_Click"/><br />
                    </div>
                </div>
               <div class="row">
                    <div class="col-md-6">
                        <div class="box-body">
                            
                            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
       </div>
    </form>
</asp:Content>
