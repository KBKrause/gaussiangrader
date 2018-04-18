<%@ Page Language="C#" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gaussigrader - Home</title>
</head>
<body>
    <form id="form1" runat="server">
        <!--#include file ="navbar.aspx"-->
        <div>
            Hello world! This is the main page of the application.
            <div class="card" style="width: 18rem;">
                &nbsp;<div class="card-body">
                    <h5 class="card-title">Card title</h5>
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    <a href="#" class="btn btn-primary">Go somewhere</a>
                </div>
            </div>
        </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:GradebookConnectionString %>" SelectCommand="SELECT * FROM [Instructors]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />
                <asp:BoundField DataField="first" HeaderText="first" SortExpression="first" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
