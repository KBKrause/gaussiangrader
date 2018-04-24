<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="hub.aspx.cs" Inherits="MemberPages_hub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_HEADER" Runat="Server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MASTER_BODY" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Welcome "></asp:Label>
        <asp:LoginName ID="LoginName" runat="server" />
        (<asp:LoginStatus ID="LoginStatus" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/index.aspx" />)
</asp:Content>