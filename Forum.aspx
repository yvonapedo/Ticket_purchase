<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forum.aspx.cs" Inherits="ticket_purchase_system.Forum" MasterPageFile="~/Static/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="headSearch">         <div>
            &nbsp;<asp:DropDownList ID="DropDownList1" CssClass="auto-style3" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Width="193px">
                <asp:ListItem>View All</asp:ListItem>
                <asp:ListItem>Your own</asp:ListItem>
            </asp:DropDownList>
        </div> 
   
            ADD NEW TOPIC <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Static/img/message.png" PostBackUrl="New_Post.aspx" Height="39px" Width="38px" />
            &nbsp;<%--<asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click" ForeColor="#D4062F" >Add new post</asp:LinkButton>--%>
        
    </div>

    <div>
        <asp:DataList ID="DataList1" runat="server">
            <HeaderTemplate>

                <h1>Posts</h1>

            </HeaderTemplate>
            <ItemTemplate>
                <center>
                <table width="900px" class="forum_List">
                    <tr height="50px">
                        <td class="auto-style2">Posted by:
                                <asp:Label ID='Label2' runat="server" Text='<%# Eval("username") %>' Font-Bold="True" ForeColor="#0d0d0d"></asp:Label></td>
                        <td class="auto-style2">Subejct:
                                <asp:Label ID="Label3" runat="server" Text='<%# Eval("Post_subject") %>' Font-Bold="True" Font-Italic="True" ForeColor="#D4062F"></asp:Label></td>
                        <td class="auto-style2"><a href='Post_Details.aspx?ID=<%# Eval("Post_ID") %>' class="btn" >MORE</a></td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <asp:Image ID="Image1" class="forum_Image" runat="server" Width="100px" height="100px"  ImageUrl='<%# Eval("Profile_picture") %>' />
                            <br />
                            <asp:Label ID="Label4" runat="server" Text='<%# Eval("Post_time") %>'></asp:Label>
                        </td>
                       <td class="auto-style2" colspan="2">
                            <asp:Label ID="Label5" runat="server" Text='<%# Eval("Post_content") %>'></asp:Label>
                        </td>
                    </tr>
                </table>
                    </center>
                <hr />
            </ItemTemplate>
        </asp:DataList>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head">
    <style type="text/css">
        .btn {
            width: 100px;
            float: right; 
            text-align: center;
            text-decoration: none;
            font-size:14px;
            margin:5px;
            border-radius: 10px;
            border: 2px solid #d4062f;
            background: #d4062f;
            color: #f0f0f0;
             padding:5px 10px;
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

        .forum_Image {
            margin: 0px 30px;
            object-fit:contain;
            border-radius: 10px;
            box-shadow: 20px 20px 60px #d9d9d9, -20px -20px 60px #ffffff;
        }
        .auto-style2{
            padding: 0px 30px;
           
        }
        .auto-style3 {
            outline-width: medium;
            outline-style: none;
            outline-color: invert;
            border: 2px solid #e6e6e6;
            padding: 5px 0px;
            background: #e6e6e6;
        }
    </style>
</asp:Content>
