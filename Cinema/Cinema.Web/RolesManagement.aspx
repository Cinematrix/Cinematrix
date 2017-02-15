﻿<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RolesManagement.aspx.cs" Inherits="Cinema.Web.RolesManagement" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
        <asp:DropDownList 
            ID="UsersDropdown" runat="server" 
            DataTextField="UserName" DataValueField="Username" AutoPostBack="true">

        </asp:DropDownList>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Demote to user" CssClass="btn btn-danger" OnClick="SubmitButton_Click" />
            <asp:Button ID="RemoveAdminButton" runat="server" Text="Make cashier" CssClass="btn btn-success" OnClick="RemoveAdminButton_Click" />
        </p>
    </div>
</asp:Content>