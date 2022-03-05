<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="ticket_purchase_system.Register" MasterPageFile="~/Static/MasterLogin.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div>
        <h1 style="font-size: 20px">SIGN UP</h1>

        <div>
            <h4>
                <asp:TextBox ID="TxtFullName" runat="server" placeholder="Fullname"></asp:TextBox>
                <asp:Label ID="Label2" runat="server" Text="*" ForeColor="Red"></asp:Label><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TxtFullName" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
            </h4>
        </div>
        <div>
            <h4>
                <asp:TextBox ID="TxtUsername" runat="server" placeholder="Username"></asp:TextBox>
                <asp:Label ID="Label3" runat="server" Text="*" ForeColor="Red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtUsername" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
            </h4>
        </div>
        <div>
            <h4>
                <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password" placeholder="Password" AutoPostBack="False"></asp:TextBox>
                <asp:Label ID="Label4" runat="server" Text="*" ForeColor="Red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TxtPassword" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
            </h4>
        </div>
        <div>
            <h4>
                <asp:TextBox ID="TextBox4" runat="server" TextMode="Password" AutoPostBack="False" placeholder="Confirm Password"></asp:TextBox>
                <asp:Label ID="Label5" runat="server" Text="*" ForeColor="Red"></asp:Label>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TxtPassword" ControlToValidate="TextBox4" ErrorMessage="Should be the same" Font-Size="10px" ForeColor="Red"></asp:CompareValidator>
            </h4>
        </div>
        <div>
            <h4>
                <asp:TextBox ID="TxtDob" runat="server" TextMode="Date" placeholder="date of birth"></asp:TextBox>
                <asp:Label ID="Label6" runat="server" Text="*" ForeColor="Red"></asp:Label>
                &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TxtDob" ErrorMessage="Cannot be empty" Font-Size="10px" ForeColor="Red"></asp:RequiredFieldValidator>
            </h4>
          
        </div>
        <div >
           
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="16px" Width="305px" Font-Overline="False" Font-Size="12px">
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:RadioButtonList>
        </div>

        <div>

                       <div>
                <h4>
                    <asp:TextBox ID="TxtAddress" runat="server" placeholder="Address"></asp:TextBox></h4>
            </div>
            <div>
                <h4>
                    <asp:TextBox ID="TxtPhone" runat="server" placeholder="Phone number" Width="160px"></asp:TextBox>
                    <asp:TextBox ID="TxtEmail" runat="server" placeholder="Email" Width="165px"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" ErrorMessage="not a valid email" Font-Italic="False" Font-Size="10px" ForeColor="Red" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"></asp:RegularExpressionValidator>
                </h4>
            </div>

            <div>
                <h4>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="30px">
                    </asp:DropDownList>
                </h4>
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <ContentTemplate>
                    <fieldset style="border: none; height:30px;">
                        <div>
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged"  Width="93px" Height="45px" Text="" CssClass="auto-style1" Font-Size="10px" />
                       <span style="font-size:14px;"> I accept the terms of service and privacy policy</span>    <%-- &nbsp;<asp:Label ID="Label1" runat="server" Text="Label" Font-Size="10px">--%><br /><div>
                                <br />
                                <a href="Login.aspx" target="_blank" rel=" " style="color: #d4062f; text-decoration: none;">SIGN IN </a>instead
            <asp:Button ID="BtnSave" CssClass="btn" runat="server" Text="Save" OnClick="Button1_Click1" Width="61px" />

                            </div>
                    </fieldset>
                </ContentTemplate>
            </asp:UpdatePanel>
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

            div{
                border:none;
            }
        #TxtPassword, #TxtUsername {
            border-radius: 0px;
            border: none;
        }

        div {
            width: 100%;
        }
        .auto-style1 {
            margin-right: 0;
        }
    </style>
</asp:Content>
