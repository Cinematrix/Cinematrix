<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolesManagement.aspx.cs" Inherits="Cinema.Web.RolesManagement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
        <asp:DropDownList ID="UsersDropdown" runat="server"></asp:DropDownList>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Make admin" CssClass="btn btn-success" OnClick="SubmitButton_Click" />
            <asp:Button ID="RemoveAdminButton" runat="server" Text="Make user" CssClass="btn btn-warning" OnClick="RemoveAdminButton_Click" />
        </p>
    </div>
</asp:Content>
