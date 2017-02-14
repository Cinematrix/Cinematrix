<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolesManagement.aspx.cs" Inherits="Cinema.Web.RolesManagement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
        <asp:DropDownList ID="UsersDropdown" runat="server"></asp:DropDownList>
        <p>
            <asp:Button ID="submitButton" runat="server" Text="Make admin" CssClass="btn btn-success" />
        </p>
    </div>
</asp:Content>
