<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FlightDetails.aspx.cs" Inherits="ticket_purchase_system.FlightDetails" MasterPageFile="~/Static/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="ticket-detail">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Static/img/log1.jpg" />
        <div class="container" >

            <table >
                <tr height="40px">
                    <td class="head_title">Flight date:</td>
                    <td>
                        <asp:Label ID="LblDate" runat="server" Text='<%# Eval("flightDate") %>'></asp:Label>
                    </td>
                </tr>
                 <tr height="40px">
                    <td class="head_title">Flight Price:</td>
                    <td>
                        <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("price") %>'></asp:Label>
                    </td>
                </tr>
                <tr height="40px">
                    <td class="head_title">Flight Baggage:</td>
                    <td>
                        <asp:Label ID="LblBaggage" runat="server" Text='<%# Eval("baggage") %>'></asp:Label>
                    </td>
                </tr>
              <tr height="40px">
                    <td class="head_title">Seats Left:</td>
                    <td>
                        <asp:Label ID="LblSeat" runat="server" Text='<%# Eval("seat") %>'></asp:Label>
                    </td>
                </tr>
             <tr height="40px">
                    <td class="head_title">Flight duration:</td>
                    <td>
                        <asp:Label ID="LblDuration" runat="server" Text='<%# Eval("duration") %>'></asp:Label>
                    </td>
                </tr>
             <tr height="40px">
                    <td class="head_title">Flight Number:</td>
                    <td>
                    <asp:Label ID="LblNum" runat="server" Text='<%# Eval("flightNum") %>'></asp:Label></td>
                </tr>
              <tr height="40px">
                    <td class="head_title">Flight Source:</td>
                    <td>
                        <asp:Label ID="LblSource" runat="server" Text='<%# Eval("source") %>'></asp:Label>
                    </td>
                </tr>
              <tr height="40px">
                    <td class="head_title">Flight Destination:</td>
                    <td>
                        <asp:Label ID="LblDestination" runat="server" Text='<%# Eval("destination") %>'></asp:Label>
                    </td>
                </tr>
            <tr height="40px">
                    <td class="head_title">Flight Aircraft:</td>
                    <td>
                        <asp:Label ID="LblMFR" runat="server" Text='<%# Eval("MFR") %>'></asp:Label>
                        -
                <asp:Label ID="LblModel" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label>
                    </td>
                </tr>
              <tr height="40px">
                    <td class="head_title">Passenger Type:</td>
                    <td>
                        <asp:DropDownList ID="DropPassenger" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="DropPassenger_SelectedIndexChanged" Font-Size="12pt" CssClass="drop">
                        </asp:DropDownList>
                    </td>
               <tr height="40px"> 
                    <td class="head_title">Seat Type:</td>
                    <td>
                        <asp:DropDownList ID="DropSeat" runat="server" AutoPostBack="True"
                            OnSelectedIndexChanged="DropSeat_SelectedIndexChanged" Font-Size="12pt" CssClass="drop">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr height="40px">
                    <td class="head_title">Quantity:</td>
                    <td>
                        <asp:TextBox ID="TxtQuantity" runat="server" TextMode="Number" AutoPostBack="True"
                            OnTextChanged="TxtQuantity_TextChanged" Font-Size="12pt" CssClass="auto-style2" Width="83px">1</asp:TextBox>
                    </td>
                </tr>
                <tr height="40px">
                    <td class="head_title">Total Amount: </td>
                    <td>
                        <asp:Label ID="LblAmount" runat="server" Text=" "></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lbl" runat="server" Text=" "></asp:Label></td>
                </tr>
            </table>

        </div>
        <div class="auto-style1">
            <%--<h3>Ticket number:
                <asp:Label ID="LblTicketID" runat="server" Text='<%# Eval("ticketID") %>'></asp:Label></h3>--%>
            <asp:Button ID="Button1" class="btn" runat="server" Text="BUY" OnClick="Button1_Click" OnClientClick="return confirm('Are you sure?');" />
            &nbsp;&nbsp; 
            <asp:Button ID="Button2" class="btn" runat="server" Text="SAVE" OnClick="Button2_Click" />
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
    <script type="text/javascript">
        VanillaTilt.init(document.querySelector(".auto-style1"), {
            max: 20,
            speed: 200
        });

        //It also supports NodeList
        VanillaTilt.init(document.querySelectorAll(".auto-style1"));
    </script>
    <style type="text/css">
        .btn {
            width: 100px;
            float: right;
            height: 35px;
            border-radius: 5px;
            border: 2px solid #d4062f;
            background: #d4062f;
            color: #f0f0f0;
            border: none;
        }

            .btn:hover {
                color: #d4062f;
                background: #f0f0f0;
                border: 2px solid #d4062f;
            }

        .auto-style1 {
            position: absolute;
            bottom: 20px;
            left: 50px;
            height: 70px;
            width: 600px;
            box-shadow: 20 20 50 rgba(0, 0, 0, 0.5);
            border-radius: 5px;
            background: rgba(238, 238, 238, 0.502);
            overflow: hidden;
            display: Flex;
            justify-content: space-around;
            align-items: center;
            border-top: 1px solid rgba(255, 255, 255, 0.5);
            border-left: 1px solid rgba(255, 255, 255, 0.5);
            backdrop-filter: blur(5px);
        }
        .auto-style2 {
            outline-width: medium;
            outline-style: none;
            outline-color: invert;
            border: 2px solid #e6e6e6;
            padding: 5px 0px;
            background: #e6e6e6;
        }
    </style>
</asp:Content>
