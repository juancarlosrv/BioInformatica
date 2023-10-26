<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebUpdateVeterinaryDoctor.aspx.cs" Inherits="VeterinarySmiles_Web.WebUpdateVeterinaryDoctor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


            <style>

        .box {

  /* styling */
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
                <h1 style="text-align:center">Actualizacion de Veterinarios</h1>
            </section>
            <section class="content">

                <div class="row">


                    <div class="col-md-5">

                        <div class="box-body">

                            <div class="form=group">
                                <asp:Label runat="server">CI :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtCI" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            

                            <div class="form=group">
                                <asp:Label runat="server">Primer Apellido :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="row">


                                <div class="col-md-6">
                                    <div class="form=group">
                                        <asp:Label runat="server">Fecha de Nacimiento :</asp:Label>
                                    </div>

                                    <div class="form=group">
                                        <asp:TextBox ID="txtBirthDate" runat="server" TextMode="Date" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                

                                
                            </div>
                            

                            

                             <div class="form=group">
                                <asp:Label runat="server">Telefono :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                           
                            


                            

                            <div class="form=group">
                                <asp:Label runat="server">Codigo Veterinario :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtCodigoVet" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            

                        </div>

                    </div>
                    <div class="col-md-5">

                         <div class="form=group">
                                <asp:Label runat="server">Nombre :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            <div class="form=group">
                                    <asp:Label runat="server">Segundo Apellido :</asp:Label>
                                </div>

                                <div class="form=group">
                                   <asp:TextBox ID="txtSecondLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>



                              
                        <div class="form=group">
                                <asp:Label runat="server">Direccion :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        <div class="form=group">
                                <asp:Label runat="server">Especialidad :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtEspeciality" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                         
                            <br />
                        
                            
                        
                    </div>
                    <div class="col-md-2">
                        <div class="form=group">
                                <asp:Label runat="server">Genero :</asp:Label>
                        </div>

                        <div class="form=group">
                               <!--<asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox>-->
                            <asp:DropDownList ID="selGender" runat="server" class="box">
                            <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                            <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                    
                                </asp:DropDownList>
                        </div>

                            <br />

                        <div>
                            <asp:Button ID="btnSave" Text="Guardar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' Onclick="btnSave_Click" /><br />
                        </div>
                    </div>

                </div>

                <br />

                <div class="row">
                    <div class="col-md-10">
                        <div class="box-body">
                            <br />
                            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>

                

                

            </section>





             </div>
    </form>










</asp:Content>
