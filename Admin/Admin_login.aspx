<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_login.aspx.cs" Inherits="ticket_purchase_system.Admin.Admin_login" MasterPageFile="~/Static/MasterLogin.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <h1>Admin SIGN IN</h1>
    <div class="line"></div>
    <h4>USERNAME</h4>
    <asp:TextBox ID="TxtUsername" runat="server" Width="330px"></asp:TextBox>
    <h4 style="margin-top: 20px;">PASSWORD</h4>
    <asp:TextBox ID="TxtPassword" runat="server" Width="330px" TextMode="Password"></asp:TextBox>
    <div style="margin: 10px 0 80px;" class="btnLogin">
        <h4 class="auto-style1">Not a member <a href="Admin_Register.aspx" target="_blank" rel=" ">REGISTER</a></h4>
        <asp:Button class="btn" runat="server" Text="SIGN IN" ID="Button1" OnClick="Button1_Click" Width="80px" Height="33px"></asp:Button>
    </div>

</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .auto-style1 {
            width: 246px;
        }

        #Button1 {
            width: 100px;
            float: right;
            height: 35px;
            border-radius: 10px;
            border: 2px solid #d4062f;
            background: #d4062f;
            color: #f0f0f0;
            border: none;
        }

            #Button1:hover {
                color: #d4062f;
                background: #f0f0f0;
                border: 2px solid #d4062f;
            }

        #TxtPassword, #TxtUsername {
            border-radius: 0px;
            border: none;
        }
    </style>
</asp:Content>

