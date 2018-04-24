<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_HEADER" Runat="Server">
    <title>Gaussigrader - Home</title>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MASTER_BODY" runat="server">
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
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/MemberPages/hub.aspx">HyperLink</asp:HyperLink>
    </asp:Content>