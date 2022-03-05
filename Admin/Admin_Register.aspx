<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin_Register.aspx.cs" Inherits="ticket_purchase_system.Admin.Admin_Register"  MasterPageFile="~/Static/MasterLogin.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <h1 style="font-size: 20px"> Admin SIGN UP</h1>
 
        <div>
            <h4>
                <asp:TextBox ID="TxtUsername" runat="server" placeholder="Username"></asp:TextBox>
                <asp:Label ID="Label1" runat="server" Text="*" ForeColor="Red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtUsername" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
            </h4>
        </div>
        <div>
            <h4>
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" placeholder="Password" AutoPostBack="False"></asp:TextBox>
                 <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPassword" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
            </h4>
        </div>
        <div>
            <h4>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" AutoPostBack="False" placeholder="Confirm Password"></asp:TextBox>
                 <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtPassword" ControlToValidate="TextBox4" ErrorMessage="Should be the same" Font-Size="10px" ForeColor="Red"></asp:CompareValidator>
            </h4>
        </div>
        

            <div>
                <a href="Admin_login.aspx" target="_blank" rel=" " style="color: #d4062f; text-decoration: none;">SIGN IN </a>instead
            <asp:Button ID="BtnSave" CssClass="btn" runat="server" Text="Save" OnClick="Button1_Click1" Width="61px" />

            </div>
        </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
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

        div {
            width: 100%;
        }
    </style>
</asp:Content>
















<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div class="big">  
        <div  class="auto-style1">
            <h1>Register</h1>

            <div>
                <h4>Username&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TxtUsername" runat="server"></asp:TextBox></h4>
            </div>
            <div>
                <h4>Password&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
                </h4>
            </div>
            <div>
                <h4>Confirm Password&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox4" runat="server" TextMode="Password"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtPassword" ControlToValidate="TextBox4" ErrorMessage="Should be the same"></asp:CompareValidator>
                </h4>
            </div>
           
            <div>
                <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="Button1_Click1" />
                &nbsp;
                <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Log in instead</asp:LinkButton>
            </div>
        </div>
        </div>
    </form>
</body>
</html>--%>
