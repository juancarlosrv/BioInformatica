<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebUpdateAttentionPoint.aspx.cs" Inherits="VeterinarySmiles_Web.WebUpdateAttentionPoint" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">




    

    <script type="text/javascript" src="https://www.bing.com/api/maps/mapcontrol?callback=loadMap" async defer></script>
<script type="text/javascript">
    var map;
    var pin;
    var txtLatitude;
    var txtLongitude;
    var ddlDepartments; // Referencia al ComboBox

    // Mapeo de los departamentos de Bolivia con sus coordenadas de centro
    var departmentCenters = {
        'La Paz': { latitude: -16.5000, longitude: -68.1500 },
        'Santa Cruz': { latitude: -17.8000, longitude: -63.1667 },
        'Cochabamba': { latitude: -17.3833, longitude: -66.1667 },
        // Agrega los demás departamentos y sus coordenadas aquí
    };

    function loadMap() {
        map = new Microsoft.Maps.Map(document.getElementById('mapContainer'), {
            credentials: 'Apa57c1xOrdhQocxLvY5bCdwj07SN7tU4LBEMtPICJK2Q1UHO-bfhq0v2x9clMPE',
            zoom: 10
        });

        Microsoft.Maps.Events.addHandler(map, 'click', function (e) {
            var location = e.location;
            var latitudValor = location.latitude.toFixed(6);
            var longitudValor = location.longitude.toFixed(6);

            updateCoordinates(latitudValor, longitudValor);

            if (pin) {
                map.entities.remove(pin);
            }

            pin = new Microsoft.Maps.Pushpin(location);
            map.entities.push(pin);
        });

        // Obtener las referencias a los elementos de TextBox y ComboBox
        txtLatitude = document.getElementById('<%=txtLatitude.ClientID%>');
        txtLongitude = document.getElementById('<%=txtLongitude.ClientID%>');
        ddlDepartments = document.getElementById('<%=selState.ClientID%>');

        // Agregar manejadores de eventos para actualizar el mapa cuando se cambien las coordenadas
        txtLatitude.addEventListener('input', updateMap);
        txtLongitude.addEventListener('input', updateMap);

        // Agregar manejador de evento para el cambio de selección en el ComboBox
        ddlDepartments.addEventListener('change', updateMap);

        // Llamar a la función updateMap para mostrar el punto inicial
        updateMap();
    }

    function updateMap() {
        var latitude = parseFloat(txtLatitude.value);
        var longitude = parseFloat(txtLongitude.value);
        var selectedDepartment = ddlDepartments.value; // Obtener el valor seleccionado del ComboBox

        if (!isNaN(latitude) && !isNaN(longitude)) {
            var location = new Microsoft.Maps.Location(latitude, longitude);

            if (departmentCenters.hasOwnProperty(selectedDepartment)) {
                var departmentCenter = departmentCenters[selectedDepartment];
                var centerLocation = new Microsoft.Maps.Location(departmentCenter.latitude, departmentCenter.longitude);
                map.setView({ center: centerLocation });
            } else {
                // Departamento no válido, mantener el centro del mapa en las coordenadas actuales
                map.setView({ center: location });
            }

            updateCoordinates(latitude.toFixed(6), longitude.toFixed(6));

            if (pin) {
                map.entities.remove(pin);
            }

            pin = new Microsoft.Maps.Pushpin(location);
            map.entities.push(pin);
        }
    }

    function updateCoordinates(latitude, longitude) {
        txtLatitude.value = latitude;
        txtLongitude.value = longitude;
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
                <h1 style="text-align:center">Actualizacion de Puntos de Atencion</h1>
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
                                       <div class="form=group" style="visibility:hidden">
                              
                                           <asp:DropDownList ID="selState" runat="server" class="box">

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
                                     <asp:Button ID="btnSave" Text="Guardar" runat="server" class='btn btn-secondary' style='background-color:#2a3547' Onclick="btnSave_Click"/><br />

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
                    <div class="col-md-6">
                        <div class="box-body">
                           
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            <asp:Label ID="lblError" style="color:#690404" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>


              
            </section>
       </div>
    </form>







</asp:Content>
