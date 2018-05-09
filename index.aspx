<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_HEADER" Runat="Server">
    <!-- TODO For all inputs and queries:
            Make sure the records exist
            Make the points go no higher than the max possible points for assignments
            No duplicates - throw errors when needed
     -->
    <title>Gaussigrader - Home</title>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MASTER_BODY" runat="server">
        <div>
            Hello world! This is the main page of the application.<br />
            Please use the navbar / signup to access our tools.</div>
    </asp:Content>