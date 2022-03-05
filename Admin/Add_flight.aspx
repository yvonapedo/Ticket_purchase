<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_flight.aspx.cs" Inherits="ticket_purchase_system.Admin.Add_flight" MasterPageFile="~/Static/AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="ticket-detail">
        <%--<asp:Image ID="Image1" runat="server" ImageUrl="~/Static/img/log1.jpg" />--%>
        <div class="container">
            <h1>Add New flight</h1>

            <table>
                <tr>
                    <td>
                        <h4>Date&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:TextBox ID="TxtDate" runat="server" TextMode="Date" CssClass="drop"></asp:TextBox>
                            <asp:TextBox ID="TxtTime" runat="server" CssClass="drop" TextMode="Time"></asp:TextBox>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Duration&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:TextBox ID="TxtDuration" runat="server" CssClass="drop"></asp:TextBox>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Price&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:TextBox ID="TxtPrice" runat="server" CssClass="drop"></asp:TextBox>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Seat&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:TextBox ID="TxtSeat" runat="server" CssClass="drop"></asp:TextBox>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Baggage&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:TextBox ID="TxtBaggage" runat="server" CssClass="drop"></asp:TextBox>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>FlightNum&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:TextBox ID="TxtNum" runat="server" CssClass="drop"></asp:TextBox>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Aircraft&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="drop"></asp:DropDownList>
                        </h4>
                    </td>
                </tr>
                <tr>
                    <td>
                        <h4>Route&nbsp;&nbsp;&nbsp;</h4>
                    </td>
                    <td>
                        <h4>
                            <asp:DropDownList ID="DropDownList2" CssClass="drop" runat="server"></asp:DropDownList>
                        </h4>
                    </td>
                </tr>

                <tr>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="btn" Text="save" OnClick="Button1_Click" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" CssClass="btn" runat="server" Text="Reset" OnClick="Button2_Click" />
                    </td>
                </tr>
            </table>

        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
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
    </style>
</asp:Content>
