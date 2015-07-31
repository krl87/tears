<%@ Page Title="Your comic tracker" Language="C#" MasterPageFile="~/site.Master" AutoEventWireup="true" CodeBehind="tracker.aspx.cs" Inherits="comp2084_assignment2.tracker" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h1>Your Comics</h1>

    <a href="tracker-details.aspx">Add Comics</a>

    <asp:GridView runat="server" ID="grdComics" CssClass="table table-striped table-hover"
        AutoGenerateColumns="false" AllowPaging="true" PageSize="5" OnPageIndexChanging="grdComics_PageIndexChanging"
        OnRowDeleting="grdComics_RowDeleting" DataKeyNames="ComicID">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="Publisher" HeaderText="Publisher" />
            <asp:BoundField DataField="Issue" HeaderText="Issue" />
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" DataNavigateUrlFields="ComicID"
                DataNavigateUrlFormatString="track-details.aspx?ComicID={0}" />
            <asp:CommandField ShowDeleteButton="true" DeleteText="Delete" HeaderText="Delete" />
        </Columns>
    </asp:GridView>
</asp:Content>
