<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_FlightDetails.aspx.cs" Inherits="ticket_purchase_system.Admin.Admin_FlightDetails"   MasterPageFile="~/Static/AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <asp:Label ID="Label1" runat="server" Text='<%# Eval("flightID") %>'></asp:Label>
            <div>
            <h3>Flight date:
                <asp:Label ID="LblDate" runat="server" Text='<%# Eval("flightDate") %>'></asp:Label></h3>
            <h3>Flight duration:
                <asp:Label ID="LblDuration" runat="server" Text='<%# Eval("duration") %>'></asp:Label></h3>
            <h3>Flight price:
                <asp:Label ID="LblPrice" runat="server" Text='<%# Eval("price") %>'></asp:Label></h3>
            <h3>Flight Baggage:
                <asp:Label ID="LblBaggage" runat="server" Text='<%# Eval("baggage") %>'></asp:Label></h3>
            <h3>Seats Left:
                <asp:Label ID="LblSeat" runat="server" Text='<%# Eval("seat") %>'></asp:Label></h3>
            <h3>Flight Number:
                <asp:Label ID="LblNum" runat="server" Text='<%# Eval("flightNum") %>'></asp:Label></h3>
            <h3>Flight Source:
                <asp:Label ID="LblSource" runat="server" Text='<%# Eval("source") %>'></asp:Label></h3>
            <h3>Flight Destination:
                <asp:Label ID="LblDestination" runat="server" Text='<%# Eval("destination") %>'></asp:Label></h3>
            <h3>Flight Aircraft:
                <asp:Label ID="LblMFR" runat="server" Text='<%# Eval("MFR") %>'></asp:Label>
                -
                <asp:Label ID="LblModel" runat="server" Text='<%# Eval("MODEL") %>'></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" Text="Cancel" OnClick="Button1_Click" class="btn" OnClientClick="return confirm('Are you sure?');"/>
            &nbsp;&nbsp;&nbsp;
              
            </h3>
                
        </div>

        <div>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <AlternatingRowStyle BackColor="White" />
               <Columns>
                 <asp:CommandField ShowSelectButton="True" />             
                                
                    
                </Columns>
                <FooterStyle BackColor="#d4062f" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#d4062f" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                <SortedAscendingCellStyle BackColor="#FDF5AC" />
                <SortedAscendingHeaderStyle BackColor="#4D0000" />
                <SortedDescendingCellStyle BackColor="#FCF6C0" />
                <SortedDescendingHeaderStyle BackColor="#820000" />
            </asp:GridView>
        </div>
        <div>
            <center>
            <table width="500px">
                <tr>
                    <td class="auto-style1">Ticket id</td>
                     <td class="auto-style1">
                         <asp:Label ID="LblTicketID" runat="server" Text=" "></asp:Label> 
                    </td>
                     
                </tr>
                 <tr>
                    <td>User</td>
                     <td>
                         <asp:TextBox ID="TxtUser" runat="server" Width="140px"></asp:TextBox>
                     </td>
                      
                </tr>
                <tr>
                    <td>TxtDob</td>
                     <td>
                         <asp:TextBox ID="TxtDob" runat="server" Width="140px" TextMode="Date"></asp:TextBox>
                     </td>
                      
                </tr>
                <tr>
                    <td>Gender</td>
                     <td>
                         <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                             <asp:ListItem Value="1">Male</asp:ListItem>
                             <asp:ListItem Value="0">Female</asp:ListItem>
                         </asp:RadioButtonList>
                     </td>
                      
                </tr>
                <tr>
                    <td>TxtPhone</td>
                     <td>
                         <asp:TextBox ID="TxtPhone" runat="server" Width="140px"></asp:TextBox>
                     </td>
                      
                </tr>
                <tr>
                    <td>quantity</td>
                     <td>
                         <asp:TextBox ID="TxtQuantity" runat="server" Width="140px"></asp:TextBox>
                    </td>
                      

                </tr>
                <tr>
                    <td>Passenger type</td>
                     <td>
                         <asp:DropDownList ID="DropPassenger" runat="server" Width="140px">
                         </asp:DropDownList>
                    </td>
                      
                </tr>
                <tr>
                    <td>SeatType</td>
                     <td>
                         <asp:DropDownList ID="DropSeat" runat="server" Width="140px">
                         </asp:DropDownList>
                    </td>
                      
                </tr>
                <tr>
                    <td>Confirm</td>
                     <td>
                         <asp:DropDownList ID="DropConfirm" runat="server" Width="140px">
                             <asp:ListItem>confirmed</asp:ListItem>
                             <asp:ListItem>cancel</asp:ListItem>
                             <asp:ListItem>saved</asp:ListItem>
                         </asp:DropDownList>
                    </td>
                      
                </tr>
            </table>
                <asp:Button ID="Button3" runat="server" Text="insert" OnClick="Button3_Click"  class="btn" /><asp:Button class="btn" ID="Button4" runat="server" Text="update" OnClick="Button4_Click" />
                </center>
        </div>
    </asp:Content>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="head">
     
    <style type="text/css">
          .btn {
            width: 100px;
            float: right;
            height: 35px;
            border-radius: 10px;
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
