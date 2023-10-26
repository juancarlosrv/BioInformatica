<%@ Page Title="" Language="C#" MasterPageFile="~/SiteVeterinario.Master" AutoEventWireup="true" CodeBehind="WebMenuVeterinary.aspx.cs" Inherits="VeterinarySmiles_Web.WebMenuVeterinary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <h1>Actualiza Tus datos basales</h1>



        <form id="form1" runat="server">

        <div class="form-box">

            <section class="content-header">
                <h1 style="text-align:center">Actualiza Tus datos Para IMC</h1>
            </section>
            <section class="content">

                <div class="row">


                    <div class="col-md-5">

                        <div class="box-body">

                            <div class="form=group">
                                <asp:Label runat="server">Peso (kg) :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtPeso" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                            

                            <div class="form=group">
                                <asp:Label runat="server">Altura (CM) :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtCM" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                           
                            

                           
                           
                            

                            <div class="form=group">
                                    <asp:Label runat="server">Grado Diabetes :</asp:Label>
                            </div>

                            <div class="form=group">
                                   <!--<asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox>-->
                                    <asp:DropDownList ID="selGradoDiabetes" runat="server" class="box">
                                    <asp:ListItem Text="Muy Alto" Value="Muy Alto"></asp:ListItem>
                                    <asp:ListItem Text="Alto" Value="Alto"></asp:ListItem>
                                    <asp:ListItem Text="Medio" Value="Medio"></asp:ListItem>
                                    <asp:ListItem Text="Bajo" Value="Bajo"></asp:ListItem>
                                    <asp:ListItem Text="Muy Bajo" Value="Muy Bajo"></asp:ListItem>
            
                                    </asp:DropDownList>
                            </div>

                                <br />
                            

                            
                            

                        </div>

                    </div>
                    
                    <div class="col-md-2">
                        <div class="form=group">
                                <asp:Label runat="server">Genero :</asp:Label>
                        </div>

                        <div class="form=group">
                              
                            <asp:DropDownList ID="selGender" runat="server" class="box">
                                <asp:ListItem Text="Masculino" Value="M"></asp:ListItem>
                                <asp:ListItem Text="Femenino" Value="F"></asp:ListItem>
                                    
                                </asp:DropDownList>
                        </div>

                            <br />

                        <div>
                            <asp:Button ID="btnInsert" Text="Insertar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' OnClick="btnUpdate_Click"/>
                            
                            
                    </div>

                </div>

                <br />

                <div class="row">
                    <div class="col-md-12">
                       

                        <asp:Label ID="Label1" style="color:#690404" runat="server" Text=""></asp:Label>

                    </div>
                </div>

                <div class="row">

                    <div class="col-md-12">


                        <div class="box-body">

                            
                            <asp:Label ID="Label2" style="color:#690404" runat="server" Text=""></asp:Label>



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





















    <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>



</asp:Content>
