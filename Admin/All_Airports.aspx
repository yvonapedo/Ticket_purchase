<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="All_Airports.aspx.cs" Inherits="ticket_purchase_system.Admin.All_Airports"  MasterPageFile="~/Static/AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <link rel="stylesheet" href="https://unpkg.com/leaflet@1.0.3/dist/leaflet.css" integrity="sha512-07I2e+7D8p6he1SIM+1twR5TIrhUQn9+I6yjqD53JQjFiMf8EtC93ty0/5vJTZGF8aAocvHYNEDJajGdNx1IsQ==" crossorigin=""/>
    <script src="https://unpkg.com/leaflet@1.0.3/dist/leaflet.js" integrity="sha512-A7vV8IFfih/D732iSSKi20u/ooOfj/AGehOKq0f4vLT1Zr2Y+RX7C+w8A1gaSasGtRUZpF/NZgzSAu4/Gc41Lg==" crossorigin=""></script>


 
        <div>

            <br />

            <asp:Repeater ID="Repeater1" runat="server">
                <HeaderTemplate>
                    <table border="0" class="airport">
                        <tr style="background:#d4062f; color:white; margin-top:100px; padding:0px 5px;">
                            <td width="50px">AIRPORTID</td>
                            <td width="470px">NAME</td>
                            <td width="100px">CITY</td>
                            <td width="180px">COUNTRY</td>
                            <td width="100px">IATA</td>
                            <td width="100px">ICAO</td>
                            <td width="50px">Tzone</td>
                            <td width="50px">DST</td>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr>
                        <td style="color: green"><%#  Eval("AirportID") %></td>
                        <td style="color: red"><%#  Eval("Name") %></td>
                        <td><%#  Eval("City") %></td>
                        <td ><%#  Eval("Country") %></td>
                        <td><%#  Eval("IATA") %></td>
                        <td><%#  Eval("ICAO") %></td>
                        <td><%#  Eval("Timezone") %></td>
                        <td><%#  Eval("DST") %></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>

        </div>
        <div>
            <center>
                <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Home page</asp:LinkButton>
    &nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="23px">1</asp:TextBox>
        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">Go</asp:LinkButton>
    &nbsp;Page
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
    &nbsp;Total
        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    &nbsp;pages
        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">Previous page</asp:LinkButton>
    &nbsp;<asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">Next page</asp:LinkButton>
    &nbsp;<asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">Last page</asp:LinkButton>
    &nbsp;<asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" TextMode="Number" Width="37px">30</asp:TextBox>
    &nbsp;data per page
            </center>
        </div>
        <br /> 

    <div id="mapid" style="width: 100%; height: 350px;"></div>

        <script>

            var mymap = L.map('mapid').setView([51.505, -0.09], 13);

            L.tileLayer('https://api.tiles.mapbox.com/v4/{id}/{z}/{x}/{y}.png?access_token=pk.eyJ1IjoibWFwYm94IiwiYSI6ImNpejY4NXVycTA2emYycXBndHRqcmZ3N3gifQ.rJcFIG214AriISLbB6B5aw', {
                maxZoom: 18,
                attribution: 'Map data &copy; <a href="http://openstreetmap.org">OpenStreetMap</a> contributors, ' +
                    '<a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>, ' +
                    'Imagery © <a href="http://mapbox.com">Mapbox</a>',
                id: 'mapbox.streets'
            }).addTo(mymap);
        </script>
 
      
</asp:Content>