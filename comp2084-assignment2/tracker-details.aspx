<%@ Page Title="" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="tracker-details.aspx.cs" Inherits="comp2084_assignment2.tracker_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Add a Comic</h1>

    <div class="form-group">
        <label for="txtTitle" class="col-sm-2">Title: *</label>
        <asp:TextBox ID="txtTitle" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtAuthor" class="col-sm-2">Author: *</label>
        <asp:TextBox ID="txtAuthor" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtPublisher" class="col-sm-2">Publisher: *</label>
        <asp:TextBox ID="txtPublisher" runat="server" MaxLength="50" required />
    </div>
    <div class="form-group">
        <label for="txtIssue" class="col-sm-2">Issue: *</label>
        <asp:TextBox ID="txtIssue" runat="server" required type="number" />
        <asp:RangeValidator runat="server" ControlToValidate="txtIssue" CssClass="label label-danger"
            MinimumValue="0" MaximumValue="9999999" Type="Integer" ErrorMessage="Must be greater than 0" />
    </div>
    <div class="col-sm-offset-2">
        <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="btnSave_Click" />
    </div>
</asp:Content>
