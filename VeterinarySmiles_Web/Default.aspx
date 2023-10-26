<%@ Page Title="" Language="C#" MasterPageFile="~/SiteLogin1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="VeterinarySmiles_Web.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



    <style>
        .fondo{
            background-color:#657ea4;
        }

        .logoMio{
            
            width:300px;
            height:60px;
            text-align:center;
            position:relative;
            display:block;
            margin:10px;
            
        }

        .logoMio2{
            
            width:300px;
            //height:100px;
            text-align:center;
            position:relative;
            display:block;
            margin-bottom:30px;
            
        }


        .botonMio{
            //width:300px;
            //height:100px;
            margin:auto;
            text-align:center;
            position:relative;
            display:block;
            
            
        }



    </style>




</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   
    <div class="login-box">
  <div class="login-logo" >
    
  </div>
  <!-- /.login-logo -->
  <div class="card">
    <div class="card-body fondo login-card-body ">
      <p class="login-box-msg logoMio" style="color:aliceblue">SIGN IN</p>
        <i class="fas fa-user fa-10x logoMio2" style="color:#2a3547"></i>
      <form id="formLogin" runat="server">
        <div class="input-group mb-3">
          <asp:TextBox ID="txtLogin" runat="server" CssClass="form-control" placeholder="Login"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-user" style="color:#2a3547"></span>
            </div>
          </div>
        </div>
        <div class="input-group mb-3">
          <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Password"></asp:TextBox>
          <div class="input-group-append">
            <div class="input-group-text">
              <span class="fas fa-lock" style="color:#2a3547"></span>
            </div>
          </div>
        </div>
        <div class="row">
          
          <!-- /.col -->
          <div class="col-12" style="text-align:center">
           
              <asp:Button ID="btnIngresar" class='btn btn-secondary botonMio' style='background-color:#2a3547' Text="Ingresar" runat="server" OnClick="btnIngresar_OnClick" /><br />
              
          </div>


        <div>
            <a href="WebAdmUser.aspx" class="nav-link">Registro Usuarios</a>
        </div>
          <!-- /.col -->
        </div>

        <div class="row">
            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
        </div>
      </form>
      <!-- /.social-auth-links -->

      
    </div>
    <!-- /.login-card-body -->
  </div>
</div>
   


</asp:Content>
