<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAdmSupplier.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmSupplier" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


       
       <style>

        .box {

  /* styling */
  color:white;
  background-color: white;
  border: thin solid black;
  border-radius: 4px;
  display: inline-block;
  font: inherit;
  line-height: 1.5em;
  padding: 0.5em 3.5em 0.5em 1em;

  /* reset */


}


.box::before {
  content: "\f13a";
  font-family: FontAwesome;
  position: absolute;
  top: 0;
  right: 0;
  width: 20%;
  height: 100%;
  text-align: center;
  font-size: 28px;
  line-height: 45px;
  color: rgba(255, 255, 255, 0.5);
  background-color: rgba(255, 255, 255, 0.1);
  pointer-events: none;
}




    </style>






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
                        <asp:Button ID="btnInsert" Text="Insertar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' onclick="btnInsert_Click"/><br />

                   </div>

                </div>
               <br />  <br /> 

                <div class="row">

                    <div class="col-md-12">

                        <div class="box-body">

                             <asp:GridView ID="gridData" runat="server" CssClass="table table-bordered table-striped dataTable dtr-inline">
                                 
                            </asp:GridView>                 

                        </div>

                        <div class="box-body">

                            
                            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                        </div>


                    </div>




                </div>

            </section>




        </div>
    </form>


    
     <script>
         function ConfirmDelete() {
             return confirm('¿Estás seguro de que deseas eliminar este elemento?');
         }
    </script>
    

</asp:Content>
