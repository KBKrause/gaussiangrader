<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gaussigrader - Login / Signup</title>
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file ="navbar.aspx"-->
        <p>
            Username:
                    <asp:TextBox ID="textUserName" runat="server"></asp:TextBox>
        </p>
        <p>
            Password:&nbsp;
                    <asp:TextBox ID="textPassword" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" Text="Login" />
        &nbsp;&nbsp;

    <!-- Button trigger modal -->
        <button type="button" class="btn btn-primary" data-toggle="modal" data-target="#exampleModal">
            Launch demo modal
        </button>

        <!-- Modal -->
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        ...
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                        <button type="button" class="btn btn-primary">Save changes</button>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
