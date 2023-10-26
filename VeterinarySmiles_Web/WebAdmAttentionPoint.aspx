<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebAdmAttentionPoint.aspx.cs" Inherits="VeterinarySmiles_Web.WebAdmAttentionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <script type="text/javascript" src="https://www.bing.com/api/maps/mapcontrol?callback=loadMap" async defer></script>
    <script type="text/javascript">
        var map;
        var pin;

        function loadMap() {
            map = new Microsoft.Maps.Map(document.getElementById('mapContainer'), {
                credentials: '<%= "AotlFSLc9uB-7-9NO5Opn2pZjYwgsLlp8uFiI3xdNAPPWuiJtstw2J3PXhyxkHV_" %>',
                center: new Microsoft.Maps.Location(-17.3895, -66.1568),
                zoom: 10
            });

            Microsoft.Maps.Events.addHandler(map, 'click', function (e) {
                var latitud = document.getElementById('<%=txtLatitude.ClientID%>');
                var longitud = document.getElementById('<%=txtLongitude.ClientID%>');

                var location = e.location;
                var latitudValor = location.latitude.toFixed(6);
                var longitudValor = location.longitude.toFixed(6);

                latitud.value = latitudValor;
                longitud.value = longitudValor;

                if (pin) {
                    map.entities.remove(pin);
                }

                pin = new Microsoft.Maps.Pushpin(location);
                map.entities.push(pin);
            });
        }
    </script>



   
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
                <h1 style="text-align:center">Puntos de Atencion</h1>
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

                            <div class="form=group">
                                <asp:Label runat="server">Direccion :</asp:Label>
                            </div>

                            <div class="form=group">
                               <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                           

                            <div class="row">

                                <div class="col-md-6">
                                    <div class="form=group" style="visibility:hidden">
                                        <asp:Label runat="server">Departamento :</asp:Label>
                                    </div>

                                    <div class="form=group">
                                       <div class="form=group" >
                              
                                           <asp:DropDownList ID="selState" runat="server" class="box" style="visibility:hidden">

                                           </asp:DropDownList>
                                       </div>
                                   </div>

                                    <div class="form=group">
                                        <asp:Label runat="server">Localidad :</asp:Label>
                                    </div>

                                    <div class="form=group">
                                       <div class="form=group">
                              
                                            <asp:DropDownList ID="selTown" runat="server" class="box">

                                            </asp:DropDownList>
                                        </div>
                                    </div>
                           
                                </div>
                                 
                                <div class="col-md-6">
                                    <br /><br />
                                    <asp:Button ID="btnSave" Text="Guardar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' OnClick="btnSave_Click"/><br />

                                </div>
                            </div>

                            

                            <div class="row">

                                <div class="col-md-12">
                                    <div class="form=group" style="visibility:hidden">
                                        <asp:Label runat="server">Latitud :</asp:Label>
                                    </div>

                                    <div class="form=group" style="visibility:hidden">
                                       <asp:TextBox ID="txtLatitude" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="form=group" style="visibility:hidden">
                                        <asp:Label runat="server">Longitud :</asp:Label>
                                    </div>

                                    <div class="form=group" style="visibility:hidden">
                                       <asp:TextBox ID="txtLongitude" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>
                                

                            </div>
                            
                            
                            
                        </div>
                    </div>


                    <div class="col-md-7">

                        <div id="mapContainer" style="width: 600px; height: 400px;"></div>

                    </div>



                </div>
               <div class="row">
                    <div class="col-md-10">
                        <div class="box-body">
                            
                            <asp:Button ID="btnVerifica" Text="Verifica" runat="server" OnClick="btnVerifica_Click" Visible="false"/><br />
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>


               <div class="row">

                   <div class="col-md-12">

                         <div class="box-body">

                             <asp:GridView ID="gridData" runat="server" CssClass="table table-bordered table-striped dataTable dtr-inline">
                                 
                            </asp:GridView>                 

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
