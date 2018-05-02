<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="hub.aspx.cs" Inherits="MemberPages_hub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_HEADER" Runat="Server">
    <script src="hub.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MASTER_BODY" runat="server">
    You logged in!!!
    <p id="testID"></p>
 <div class="row">
  <div class="col-4">
    <div class="list-group" id="list-tab" role="tablist">
      <a class="list-group-item list-group-item-action active" id="list-class-list" data-toggle="list" href="#list-class" role="tab" aria-controls="class">Class Listing</a>
      <a class="list-group-item list-group-item-action" id="list-profile-list" data-toggle="list" href="#list-profile" role="tab" aria-controls="profile">Profile</a>
    </div>
  </div>
  <div class="col-8">
    <div class="tab-content" id="nav-tabContent">
      <div class="tab-pane fade show active" id="list-class" role="tabpanel" aria-labelledby="list-class-list"></div>
      <div class="tab-pane fade show" id="list-profile" role="tabpanel" aria-labelledby="list-profile-list"></div>
    </div>
  </div>
</div>
    <div id="addingClassesDiv">
        Add a class<br />
        Title:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_class_title" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="validator_classTitle" runat="server" ControlToValidate="txt_class_title" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Please provide a title</asp:RequiredFieldValidator>
        <br />
        Course Code:
        <asp:TextBox ID="txt_class_code" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="validator_courseCode" runat="server" ControlToValidate="txt_class_code" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Invalid course code</asp:RequiredFieldValidator>
        <br />
        <!-- TODO add validation only to these fields -->
        <asp:Button ID="btn_submitClass" runat="server" Text="Submit" OnClick="Click_addClass" CausesValidation="False" />
    </div>
    <hr />
    <div id="addingAssignmentsDiv">
        Add an assignment to a class
        <br />
        Assignment Name:
        <asp:TextBox ID="txt_hw_name" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="validator_hwName" runat="server" ControlToValidate="txt_hw_name" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Please provide a name</asp:RequiredFieldValidator>
        <br />
        Total Points:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txt_hw_points" runat="server" TextMode="Number"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="validator_points" runat="server" ControlToValidate="txt_hw_points" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Invalid point amount</asp:RequiredFieldValidator>
        <br />
        Course Code:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="txt_hw_coursecode" runat="server"></asp:TextBox>
        <br />
        <asp:RequiredFieldValidator ID="validator_fkcoursecode" runat="server" ControlToValidate="txt_hw_coursecode" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Invalid course code</asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btn_submitHW" runat="server" Text="Submit" OnClick="Click_addAssignment" CausesValidation="False" />
    </div>

    <div id="validatorsForThose">



    </div>
</asp:Content>