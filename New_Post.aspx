<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="New_Post.aspx.cs" Inherits="ticket_purchase_system.New_Post" MasterPageFile="~/Static/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         
        <div>
            <center>  <h1> NEW POST</h1>
              <table  class="forum_List">
                    <tr>
                        <td rowspan="3" class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            <br />
                            <asp:Image ID="Image1" runat="server" Width="100px"></asp:Image>
                            <br />
                            <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                        </td>
                        <td>Subject:</td>
                        <td>
                            <asp:TextBox ID="TextBox1" runat="server" Width="500px"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>Content:</td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Height="63px" TextMode="MultiLine" Width="500px"></asp:TextBox>
                        </td>
                         
                    </tr>

                    <tr>
                        <td colspan="2">
                            <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" />
                                    &nbsp;I agree to be polite, creative and not send any offensive comments 
                            <%--<asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="return confrim('Do you want to post this part')" Text="Post" class="btn" />--%>

                             <asp:Button class="btn" runat="server" Text="SEND" ID="Button1" OnClick="Button1_Click" Width="80px" Height="33px"  OnClientClick="return confrim('Do you want to post this part')"></asp:Button>
                        </td>
                       
                    </tr>
                </table>


            </center>

        </div>
        </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .btn {
            width: 100px;
            float: right;
            text-align: center;
            text-decoration: none;
            font-size: 14px;
            margin: 5px;
            border-radius: 10px;
            border: 2px solid #d4062f;
            background: #d4062f;
            color: #f0f0f0;
            padding: 5px 10px;
        }

            .btn:hover {
                text-decoration: none;
                color: #d4062f;
                background: #f0f0f0;
                border: 2px solid #d4062f;
            }

        .forum_List {
            padding: 5px;
            background: #f7f7f7;
        }

    </style>
</asp:Content>

