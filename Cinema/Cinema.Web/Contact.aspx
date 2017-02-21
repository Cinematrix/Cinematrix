<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Cinema.Web.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
        <h2><%: Title %>.</h2>
        <h3>Working place</h3>
        <address>
            Telerik Academy<br />
            Sofia, Bulgaria<br />
            <abbr title="Phone">tel:</abbr>
            0888 111 222 (fake)
        </address>

        <address>
            <strong>Support:</strong>   <a href="mailto:iliangogov@gmail.com">iliangogov@gmail.com</a>
        </address>
    </div>
</asp:Content>
