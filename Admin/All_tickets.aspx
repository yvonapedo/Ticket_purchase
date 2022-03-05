<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="All_tickets.aspx.cs" Inherits="ticket_purchase_system.Admin.All_tickets"   MasterPageFile="~/Static/AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="headSearch">
        
           
                <asp:Button class="btn" runat="server" Text="ALL" ID="Button1" OnClick="Button1_Click" ></asp:Button>
           
                <asp:Button class="btn" runat="server" Text="SAVED" ID="Button2" OnClick="Button2_Click"  ></asp:Button>
       
                 <asp:Button class="btn" runat="server" Text="PURCHASED" ID="Button3" OnClick="Button3_Click" ></asp:Button>
        <asp:Button class="btn" runat="server" Text="CANCEL" ID="Button4" OnClick="Button4_Click" ></asp:Button>
         
    </div>
    <br />


    <asp:Repeater ID="DataList1" runat="server">
         
        <HeaderTemplate>
            <%--<h2>My Tickets</h2>--%>
            <br />
        </HeaderTemplate>
 
        <ItemTemplate>       
                <div class="ticket tilt" >
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Static/img/ticket.png" />
                    <h4> <asp:Label ID="Label1" runat="server" Text='<%# Eval("username") %>'> </asp:Label></h4>
                    <div>
                        <h5>
                            <asp:Label ID="Label12" runat="server" Text='<%# Eval("source") %>'></asp:Label></h5>
                        <h5>
                            <asp:Label ID="Label13" runat="server" Text='<%# Eval("destination") %>'></asp:Label></h5>
                    </div>
                    <h4 style="margin-bottom: 20px;">¥ 
                        <asp:Label ID="Label14" runat="server" Text='<%# Eval("price") %>'></asp:Label></h4>
                   
                       <a href='Admin_FlightDetails.aspx?ID=<%# Eval("flightID") %>'> Detail</a>
                </div>
                <br />

             
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .btn {
            /*width: 100px;*/
            /*float: right;*/
            /*height: 35px;*/
            border-radius: 5px;
            /*border: 2px solid #d4062f;*/
            background: #fdfdfd;
            color: #d4062f;
            border: none;
            padding: 5px 20px;
            font-size:20px;
           font-weight:600;
        }

       .btn:hover {
                color: #d4062f;
                background: #f0f0f0;
                border: 2px solid #d4062f;
       }
          </style>
</asp:Content>

    <%--<form id="form1" runat="server">
        <div>
            
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

        <div>          
              
                <asp:DataList ID="DataList1" runat="server">
                    <HeaderTemplate>
                      <h2>All Tickets</h2>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <h3>Username: <asp:Label ID="Label12" runat="server" Text='<%# Eval("username") %>'></asp:Label></h3>
                       <h3>Flight date: <asp:Label ID="Label4" runat="server" Text='<%# Eval("flightDate") %>'></asp:Label></h3>
                        <h3>Flight duration: <asp:Label ID="Label2" runat="server" Text='<%# Eval("duration") %>'></asp:Label></h3>
                        <h3>Flight price: <asp:Label ID="Label3" runat="server" Text='<%# Eval("price") %>'></asp:Label></h3>
                        <h3>Flight Baggage: <asp:Label ID="Label5" runat="server" Text='<%# Eval("baggage") %>'></asp:Label></h3>
                        <h3>Quantity: <asp:Label ID="Label11" runat="server" Text='<%# Eval("quantity") %>'></asp:Label></h3>
                        <h3>Flight Number: <asp:Label ID="Label6" runat="server" Text='<%# Eval("flightNum") %>'></asp:Label></h3>
                        <h3>Flight Source: <asp:Label ID="Label7" runat="server" Text='<%# Eval("source") %>'></asp:Label></h3>
                        <h3>Flight Destination: <asp:Label ID="Label8" runat="server" Text='<%# Eval("destination") %>'></asp:Label></h3>
                        <h3>Flight Aircraft: <asp:Label ID="Label9" runat="server" Text='<%# Eval("MFR") %>'></asp:Label> - <asp:Label ID="Label10" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label>  </h3>
                        <a href='TicketDetails.aspx?ID=<%# Eval("ticketID") %>'> Detail Info</a>
                                                
                        <br />
                        <hr />
                    </ItemTemplate>
                </asp:DataList>
            
         
        </div>
    </form>
    --%>
 
