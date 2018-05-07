﻿<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="classview.aspx.cs" Inherits="classview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_HEADER" Runat="Server">
    <script src="classview.js"></script>
    <title>Gaussigrader - Class view</title>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MASTER_BODY" runat="server">
        <div>
            Class information for
            <asp:Label ID="classNameLabel" runat="server" Font-Bold="True" Text="currentClassName"></asp:Label>
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SQLAssignSource">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    <asp:BoundField DataField="totalPoints" HeaderText="totalPoints" SortExpression="totalPoints" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SQLAssignSource" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Gradebook.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT name, totalPoints FROM Assignments, Classes WHERE Assignments.FK_courseCode = Classes.courseCode"></asp:SqlDataSource>
            <br />
            <br /></div>
    <div>


        Add student to (a) class:<br />
        Course code:
        <asp:TextBox ID="txt_courseCode" runat="server"></asp:TextBox>
        <br />
        Student&#39;s ID: <asp:TextBox ID="txt_studentID" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="btn_addStudentToClass" runat="server" Text="Submit" />


    </div>
    </asp:Content>