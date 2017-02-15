<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMovieView.aspx.cs" Inherits="Cinema.Web.AddMovieView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0.8)">
        <h3>Add Movie:</h3>
        <p>
            <asp:Label ID="TitleLabel" runat="server" Text="Title: "></asp:Label>
            <asp:TextBox ID="TitleInput" runat="server"></asp:TextBox>

            <asp:RequiredFieldValidator
                ID="RequiredFieldValidatorTitleInput"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Movie title is required!"
                ControlToValidate="TitleInput" />
        </p>
        <p>
            <asp:Label ID="ImageUrlLabel" runat="server" Text="Image URL: "></asp:Label>
            <asp:TextBox ID="ImageUrlInput" runat="server" TextMode="Url"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="InfoLabel" runat="server" Text="Description: "></asp:Label>
            <asp:TextBox ID="InfoInput" runat="server"></asp:TextBox>

            <asp:RegularExpressionValidator
                ID="RegularExpressionValidatorEmail"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Description field contains harmfull text!"
                ControlToValidate="InfoInput" EnableClientScript="true"
                ValidationExpression='([^<>\"\^])*' />
        </p>
        <p>
            <asp:Label ID="GenreLabel" runat="server" Text="Genre: "></asp:Label>
            <asp:TextBox ID="GenreInput" runat="server"></asp:TextBox>
             <asp:RegularExpressionValidator
                ID="RegularExpressionValidator1"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Genre field contains harmfull text!"
                ControlToValidate="GenreInput" EnableClientScript="true"
                ValidationExpression='([^<>\"\^])*'/>
        </p>
       
        <p>
            <asp:Label ID="DirectorLabel" runat="server" Text="Director: "></asp:Label>
            <asp:TextBox ID="DirectorInput" runat="server"></asp:TextBox>
              <asp:RegularExpressionValidator
                ID="RegularExpressionValidator2"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Director field contains harmfull text!"
                ControlToValidate="DirectorInput" EnableClientScript="true"
                ValidationExpression='([^<>\"\^])*'/>
        </p>
      
        <p>
            <asp:Label ID="LengthLabel" runat="server" Text="Length (in minutes): "></asp:Label>
            <asp:TextBox ID="LengthInput" runat="server" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="RequiredFieldValidator1"
                runat="server" ForeColor="Red" Display="Dynamic"
                ErrorMessage="Length is required!"
                ControlToValidate="LengthInput" />
        </p>
        <p>
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click" CssClass="btn btn-success" />
            <asp:Button ID="ClearButton" runat="server" Text="Clear" OnClick="ClearButton_Click" CssClass="btn btn-warning" />
        </p>
    </div>
</asp:Content>
