<%@ Page Title="" Language="C#" MasterPageFile="~/SiteCajero.Master" AutoEventWireup="true" CodeBehind="WebMuestraIngredientes.aspx.cs" Inherits="VeterinarySmiles_Web.WebMuestraIngredientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<form id="form1" runat="server">

    <div class="form-box">

        <section class="content-header">
            <h2 style="text-align:center">Lista de Ingredientes que componen este Plato </h2>
        </section>
        <section class="content">

            

                    <div>
                        <!--<asp:Button ID="btnInsert" Text="Insertar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' /> -->
                        
                        
                    </div>

           

            <div class="row">

                <div class="col-md-12">


                    <div class="box-body">

                        
                        <asp:Label ID="Label1" style="color:#690404" runat="server" Text=""></asp:Label>



                            <div class="box-body">
                                <br /><br />
                                 <asp:GridView ID="gridData" runat="server" CssClass="table table-bordered table-striped dataTable dtr-inline">
                             
                                 </asp:GridView>                 

                            </div>
                     </div>


               </div>

            </div>


         

            

       </section>




    </div>
</form>





</asp:Content>
