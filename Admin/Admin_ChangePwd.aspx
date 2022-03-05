<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_ChangePwd.aspx.cs" Inherits="ticket_purchase_system.Admin.Admin_ChangePwd" MasterPageFile="~/Static/AdminMaster.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div>
            
            <div>
                <table width="900px">
                    <tr>
                        <td>old password</td>
                         <td>
                             <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>new password</td>
                         <td>
                             <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>
                         </td>
                    </tr>
                     <tr>
                        <td>confirm password</td>
                         <td>
                             <asp:TextBox ID="TextBox3" runat="server" Width="300px"></asp:TextBox>
                         </td>
                    </tr>
                </table>
                <asp:Button ID="Button1" runat="server" class="btn" Text="confirm" OnClick="Button1_Click" OnClientClick="return confim('Are you sure')" />
            </div>
        </div>
        </div>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 246px;
        }
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

