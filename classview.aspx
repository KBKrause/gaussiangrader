<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="classview.aspx.cs" Inherits="classview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_HEADER" Runat="Server">
    <script src="classview.js"></script>
    <title>Gaussigrader - Class view</title>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MASTER_BODY" runat="server">
        <div>
            Assignments for
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
            Students for <asp:Label ID="studentsGridLabel" runat="server" Font-Bold="True" Text="Label"></asp:Label>
            <br />
            <asp:GridView ID="studentGrid" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SQLStudentRoster">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="first" HeaderText="first" SortExpression="first" />
                    <asp:BoundField DataField="last" HeaderText="last" SortExpression="last" />
                </Columns>
            </asp:GridView>
            <br />
            <asp:SqlDataSource ID="SQLStudentRoster" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Gradebook.mdf;Integrated Security=True;Connect Timeout=30" ProviderName="System.Data.SqlClient" SelectCommand="SELECT Students.Id, Students.first, Students.last FROM Classes, Students, StudentsAndClasses WHERE StudentsAndClasses.classcourseCode = Classes.courseCode"></asp:SqlDataSource>
            <br /></div>
    <div>


        Add student to (a) class:<br />
        Course code:
        <asp:TextBox ID="txt_courseCode" runat="server"></asp:TextBox>
        <br />
        Student&#39;s ID:
        <asp:TextBox ID="txt_studentID" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="btn_addStudentToClass" runat="server" OnClick="InsertStudentInClass" Text="Submit" />


    </div>

    <div>



        Add a grade for a student&#39;s assignment:<br />
        Student&#39;s ID:&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_stuas_stu" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        Assignment ID:<asp:TextBox ID="txt_stuas_assign" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        Points rec&#39;d:&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_stuas_pts" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:Button ID="submitStudentAssign" runat="server" OnClick="InsertStudentScore" Text="Button" />



    </div>
    </asp:Content>