<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddFilmScreeningView.aspx.cs" Inherits="Cinema.Web.AddFilmScreeningView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8);width:70%">
        <h3>Add Film Screening:</h3>
        <p>
            <asp:Label ID="DateLabel" runat="server" Width="100px" Text="Start: "></asp:Label>
            <asp:TextBox ID="DateInput" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorDateInput"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Date and time is required!"
                ControlToValidate="DateInput" />
        </p>
        <p>
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:Label ID="SelectMovieLabel" runat="server" Width="100px" Text="Movie: "></asp:Label>
                    <asp:DropDownList ID="SelectMovieDropDownList" runat="server" DataTextField="Name" DataValueField="Id" AutoPostBack="true"></asp:DropDownList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </p>
        <p>
            <asp:Label ID="PriceLabel" runat="server" Width="100px" Text="Price: "></asp:Label>
            <asp:TextBox ID="PriceInput" runat="server" Width="315px" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorPriceInput"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Price is required!"
                ControlToValidate="PriceInput" />
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-success" />
        </p>
    </div>
</asp:Content>
