<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Post_Details.aspx.cs" Inherits="ticket_purchase_system.Post_Details" MasterPageFile="~/Static/MasterPage.Master" %>

<asp:Content ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div>
            <%--<asp:LinkButton ID="LinkButton1" runat="server">LinkButton</asp:LinkButton>--%>
            &nbsp;  
            <%--<asp:LinkButton ID="LinkButton2" runat="server">LinkButton</asp:LinkButton>--%>
        </div>
        <div>
            <center>
                <h1>Comments</h1>
                <table width="900px" class="forum_List">
                    <tr>
                        <td rowspan="5" width="200px"  >Posted by:<br />
                        &nbsp;<asp:Label ID="Label1" runat="server" Text='<%# Eval("Username") %>'></asp:Label>
                            <br />
                            <br />
                            <asp:Image ID="Image1" class="forum_Image" runat="server" Width="100px" height="100px" ImageUrl='<%# Eval("Profile_picture") %>'></asp:Image>
                            <br />
                            <br />
                           <%-- registration time: <asp:Label ID="Label2" runat="server" Text='<%# Eval("RegistrationDate") %>'></asp:Label>--%>

                        </td>
                        <td width="150px"><b>Subject</b></td>
                        <td  style="background:#fcfefe; padding-left:20px;">
                           <b> <asp:Label ID="Label3" runat="server" Text='<%# Eval("Post_subject") %>' ForeColor="#888888"></asp:Label>
                                &nbsp; | <asp:Label ID="Label4" runat="server" Text='<%# Eval("Post_time") %>' ForeColor="#888888"></asp:Label>
                            </b></td>
                    </tr>
                    <tr>
                        <td><b>Content</b></td>
                        <td  style="background:#fcfefe; padding-left:20px;">
                    <i>  <asp:Label ID="Label5" runat="server" Text='<%# Eval("Post_Content") %>' ForeColor="#888888"></asp:Label> </i>
                        </td>
                     
                    </tr>
                    <tr>
                        <td><b>Reply List</b></td>
                    
                       <td  style="background:#fcfefe; padding-left:20px;">
                            <br />
                            <asp:DataList ID="DataList1" runat="server" Width="500px">
                                <ItemTemplate>
                                    <div style="display:flex; margin:10px 0px;">
                                    <div style="color:#4a4a4a; font-weight:bold;"><asp:Label ID="Label6" runat="server" Text='<%# Eval("username") %>'></asp:Label>:</div><div class="message"> 
                                        <i><asp:Label ID="Label7" runat="server" Text='<%# Eval("Reply_title") %>'></asp:Label> ~</i>

                                    <br />
                                    <asp:Label ID="Label9" runat="server" Text='<%# Eval("Reply_content") %>'></asp:Label>
                                        </div><div style="font-size:10px; font-weight:bolder;"><asp:Label ID="Label8" runat="server" Text='<%# Eval("Reply_time") %>'></asp:Label></div>
                                        </div>
                                   
                                </ItemTemplate>
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <td><b>Reply to message</b></td>
                         <td  style="background:#fcfefe; float:right;padding-left:20px;">
                            <table width="600px">
                                <tr>
                                    <td class="auto-style5">Title:</td>
                                    <td class="auto-style5"> <asp:TextBox ID="TextBox1" runat="server" CssClass="auto-style3" Width="380px"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td>Message:</td>
                                    <td><asp:TextBox ID="TextBox2" CssClass="auto-style4" runat="server" Height="62px" TextMode="MultiLine" Width="380px"></asp:TextBox> </td>
                                </tr>
                            </table>
                             
                            
                            
                        </td>
                      
                    </tr>
                    <tr>
                        <td></td>
                        <td  style="background:#fcfefe; padding-left:20px;">
                           <%-- <asp:CheckBox ID="CheckBox1"  runat="server" Text="I confirm...." AutoPostBack="True" OnCheckedChanged="CheckBox1_CheckedChanged" /> --%>
                            <asp:Button ID="Button1" CssClass="btn" runat="server" Text="Reply" OnClick="Button1_Click" OnClientClick="return confirm('are you sure?');"></asp:Button>
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

        .forum_Image {
            margin: 0px 30px;
            object-fit: contain;
            border-radius: 10px;
            box-shadow: 20px 20px 60px #d9d9d9, -20px -20px 60px #ffffff;
        }

        .message {
            text-align:left;
            margin: 5px 10px 5px 10px;
            padding: 5px;
            background:#faf6ed;
            border-radius: 5px;
            border: solid 1px #e0e0e0;
            width:400px;
          box-shadow: 0px 0px 11px 5px rgba(235,235,235,1);
 
        }

        .auto-style3 {
            outline-width: medium;
            outline-style: none;
            outline-color: invert;
            border: 2px solid #e6e6e6;
            padding: 5px 0px;
            background: #e6e6e6;
            margin: 10px 0px;
        }

        .auto-style4 {
            outline-width: medium;
            outline-style: none;
            outline-color: invert;
            border: 2px solid #e6e6e6;
            padding: 5px 0px;
            background: #e6e6e6;
            margin: 10px 0px;
        }

        .auto-style5 {
            height: 52px;
        }
    </style>
</asp:Content>
