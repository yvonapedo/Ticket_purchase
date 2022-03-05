<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="ticket_purchase_system.Profile" MasterPageFile="~/Static/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="ticket-detail">
    <div style="margin:20px auto;">
    
    <table>
          <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td>Image </td>
        <td class="auto-style2">
            &nbsp;
            <asp:Image ID="Image1" runat="server" Width="100px" Height="100px" />
            &nbsp;&nbsp;&nbsp;
            <asp:FileUpload ID="FileUpload1" runat="server" Width="160px" />
        </td>
    </tr>
    <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td width="100px">&nbsp;</td>
        <td>&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="upload" Height="38px" Width="91px" />
            <asp:Label ID="lblFile" runat="server" Text=" " Font-Size="10px"></asp:Label>
        </td>
    </tr>
    <tr class="head_title" style="height:50px; padding-right:70px; text-transform:capitalize;">
        <td> FullName </td>
        <td>
            <asp:TextBox ID="TxtFullName" runat="server" placeholder="Fullname" CssClass="drop" ></asp:TextBox>
        </td>
    </tr>
    <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td> Username </td>
        <td>
            <asp:TextBox ID="TxtUsername" runat="server" placeholder="Username" CssClass="drop" ></asp:TextBox>
        </td>
    </tr>

   
   <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td> Gender</td>
        <td>  <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Height="16px"
            Width="214px" Font-Overline="False"  Font-Size="Small" Font-Bold="false">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList></td>
    </tr>

  
   <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td>Address </td>
        <td>
            <asp:TextBox ID="TxtAddress" runat="server" placeholder="Address" CssClass="drop" ></asp:TextBox>
        </td>
    </tr>
   <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td>  Phone</td>
        <td>
            <asp:TextBox ID="TxtPhone" runat="server" placeholder="Phone number" Width="160px" CssClass="drop" ></asp:TextBox>

        </td>
    </tr>
 <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td > Email </td>
        <td>
            <asp:TextBox ID="TxtEmail" runat="server" placeholder="Email" Width="165px" CssClass="drop" ></asp:TextBox>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail"
                ErrorMessage="not a valid email" Font-Italic="False" Font-Size="10px" ForeColor="Red"
                ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$">
            </asp:RegularExpressionValidator>
        </td>
    </tr>

   <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td>Country </td>
        <td>
            <asp:DropDownList ID="DropDownList1" runat="server"   CssClass="drop">
            </asp:DropDownList>
        </td>
    </tr>

 
   <tr class="head_title" style="height:50px; text-transform:capitalize;">
        <td> </td>
        <td>
            <asp:Button ID="BtnSave" CssClass="btn" runat="server" Text="Save" OnClick="Button1_Click1" Width="61px" />
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
