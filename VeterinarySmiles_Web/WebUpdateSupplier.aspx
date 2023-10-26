<%@ Page Title="Actualiza" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebUpdateSupplier.aspx.cs" Inherits="VeterinarySmiles_Web.WebUpdateSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form id="form1" runat="server">

        <div class="form-box">

            <section class="content-header">
                <h1 style="text-align:center">Administracion de Proveedores</h1>
            </section>
            <section class="content">

                <div class="row">


                    <div class="col-md-5">

                        <div class="box-body">

                            <div class="form=group">
                                <asp:Label runat="server">Nombre :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form=group">
                                <asp:Label runat="server">Telefono :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            

                            

                        </div>


                    </div>
                    <div class="col-md-5">

                          <div class="box-body">

                              <div class="form=group">
                                <asp:Label runat="server">Direccion :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form=group">
                                <asp:Label runat="server">Email :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>


                            </div>


                    </div>

                    <div class="col-md-2">
                        <br /><br />
                        

                   </div>

                </div>
               <br />  <br /> 
               <div class="row">
                   <br /><br />
                    <div class="col-md-10" style="text-align:center">
                        <div class="box-body">
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' OnClick="btnSave_Click"/><br />
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </section>
       </div>
    </form>

</asp:Content>
