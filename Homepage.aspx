<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Homepage.aspx.cs" Inherits="ticket_purchase_system.Homepage" MasterPageFile="~/Static/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 

        <div class="headSearch">
              FROM:  <div><asp:DropDownList ID="DropSource" CssClass="drop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropSource_SelectedIndexChanged" Font-Size="12pt" BackColor="#f0efef" width="200px"></asp:DropDownList>
  </div>
              TO:    <div>  <asp:DropDownList ID="DropDestination" CssClass="drop" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDestination_SelectedIndexChanged" Font-Size="12pt" BackColor="#f0efef" width="200px"></asp:DropDownList>
    </div>
            Date:     <div> <asp:TextBox ID="TextBox1" runat="server" TextMode="Date" Font-Size="12pt" BackColor="#f0efef" width="200px" CssClass="drop" AutoPostBack="True" OnTextChanged="TextBox1_TextChanged"></asp:TextBox></div>
            </div>
  

    <div>
        <asp:DataList ID="DataList1" runat="server">
            <HeaderTemplate>
                <h2>All flights</h2>
            </HeaderTemplate>
            <ItemTemplate>

                <div class="flights tilt">

                    <div class="source"> 
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Static/img/plane.png"  height="40px" />

                        <ul>
                           <b> <li><asp:Label ID="Label13" runat="server" Text='<%# Eval("flightDate") %>'></asp:Label></li></b>
                           <b>  <li> <asp:Label ID="Label14" runat="server" Text='<%# Eval("MFR") %>'></asp:Label>
                    -
                        <asp:Label ID="Label15" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label></li></b>
                           <b>  <li class="txtGrey"><asp:Label ID="Label16" runat="server" Text='<%# Eval("source") %>'></asp:Label></li></b>
                            <b> <li class="txtGrey">Aircraft</li></b>
                        </ul>
                        <div class="vertical"></div>
                        <h1 style="color:#d4062f; font-size:30px;"> ¥ <asp:Label ID="Label17" runat="server" Text='<%# Eval("price") %>'></asp:Label></h1>

                    </div>

                    <div class="source">
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Static/img/plane1.png"  height="40px" />

                        <ul>
                           <b><li><asp:Label ID="Label19" runat="server" Text='<%# Eval("flightDate") %>'></asp:Label></li></b>
                            <b> <li> <asp:Label ID="Label20" runat="server" Text='<%# Eval("MFR") %>'></asp:Label>
                    -
                        <asp:Label ID="Label21" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label></li> </b>
                            <b> <li class="txtGrey"><asp:Label ID="Label18" runat="server" Text='<%# Eval("destination") %>'></asp:Label></li></b>
                           <b>  <li class="txtGrey">Aircraft</li></b>
                        </ul>
                        <div class="vertical"></div>
                        <h1 > <a style=" " href='FlightDetails.aspx?ID=<%# Eval("flightID") %>'>Detail Info</a>  &nbsp;&nbsp;<asp:Label ID="Label11" runat="server" Text='<%# Eval("seat") %>'></asp:Label> <span style="font-size:10px;">SEATS</span></h1>

                    </div>
                    <h3 class="status" id="status" onload="getStatus();"><asp:Label ID="Label4" runat="server" Text='<%# Eval("status") %>'></asp:Label></h3>
                </div>

              

                <br />
                <hr />
            </ItemTemplate>
        </asp:DataList>

    </div>
</asp:Content>
