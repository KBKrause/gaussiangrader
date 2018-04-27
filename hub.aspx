<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="hub.aspx.cs" Inherits="MemberPages_hub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MASTER_HEADER" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MASTER_BODY" runat="server">
    You logged in!!!

 <div class="row">
  <div class="col-4">
    <div class="list-group" id="list-tab" role="tablist">
      <a class="list-group-item list-group-item-action active" id="list-class-list" data-toggle="list" href="#list-class" role="tab" aria-controls="class">Class Listing</a>
    </div>
  </div>
  <div class="col-8">
    <div class="tab-content" id="nav-tabContent">
      <div class="tab-pane fade show active" id="list-class" role="tabpanel" aria-labelledby="list-class-list"></div>
    </div>
  </div>
</div>
</asp:Content>