<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TicketDetails.aspx.cs" Inherits="ticket_purchase_system.TicketDetails" MasterPageFile="~/Static/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ticket-detail">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/Static/img/log1.jpg" />
        <div class="container">
            <table>
                <tr>
                    <td>
                        <h3><span>Passenger name: </span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblName" runat="server" Text='<%# Eval("FullName") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>

                <tr>
                    <td>
                        <h3><span>Flight date:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblDate" runat="server" Text='<%# Eval("flightDate") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Flight duration:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblDuration" runat="server" Text='<%# Eval("duration") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Flight Number:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblNum" runat="server" Text='<%# Eval("flightNum") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Flight Source:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblSource" runat="server" Text='<%# Eval("source") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Flight Destination:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblDestination" runat="server" Text='<%# Eval("destination") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Flight Aircraft:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblMFR" runat="server" Text='<%# Eval("MFR") %>'></asp:Label>
                            -
            <h3>
                <asp:Label ID="LblModel" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label>
            </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Passenger Type:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblPassType" runat="server" Text='<%# Eval("passengerType") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Seat Type:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblSeat" runat="server" Text='<%# Eval("seatType") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Quantity:</span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblQuantity" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Total Amount: </span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblAmount" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h3><span>Status: </span></h3>
                    </td>
                    <td>
                        <h3>
                            <asp:Label ID="LblConfirm" runat="server" Text='<%# Eval("confirm") %>'></asp:Label>
                        </h3>
                    </td>
                </tr>
            </table>

        </div>
        <div class="auto-style1">
            <h3>Ticket number:
                <asp:Label ID="LblTicketID" runat="server" Text='<%# Eval("ticketID") %>'></asp:Label></h3>
            <asp:Button ID="Button2" class="btn" runat="server" Text="CANCEL" OnClick="Button2_Click" OnClientClick="return confirm('Are you sure?');" BorderWidth="2px" Width="121px" />
            <asp:Button ID="Button1" class="btn" runat="server" Text="BUY" OnClick="Button1_Click" OnClientClick="return confirm('Are you sure?');" BorderWidth="2px" Width="121px" />

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
    </style>
</asp:Content>
