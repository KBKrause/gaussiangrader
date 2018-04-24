<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_BODY" runat="server">
        <p>
            <asp:Login ID="Login1" runat="server"
                onauthenticate="Login_Authenticate">
            </asp:Login>
        </p>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="Login1" />
        <div>
        </div>
    </asp:Content>