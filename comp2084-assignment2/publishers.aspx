<%@ Page Title="Publishers" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="publishers.aspx.cs" Inherits="comp2084_assignment2.publishers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h1>List of Publishers</h1>

    <asp:GridView runat="server" ID="grdPublishers" CssClass="table table-striped table-hover" AutoGenerateColumns="false">
    <Columns>
        <asp:BoundField DataField="Publishers" HeaderText="Publishers" />
    </Columns>
    </asp:GridView>

</asp:Content>
