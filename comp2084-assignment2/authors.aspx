<%@ Page Title="Authors" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="authors.aspx.cs" Inherits="comp2084_assignment2.authors" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>List of Authors</h1>

    <asp:GridView runat="server" ID="grdAuthors" CssClass="table table-striped table-hover" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Authors" HeaderText="Authors" />
    </Columns>
    </asp:GridView>

</asp:Content>
