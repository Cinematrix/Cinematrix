<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Cinema.Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron" style="background-color: rgba(255, 255, 255, 0); text-align: center; min-height: 500px;">
        <video id="bgvid" autoplay loop muted style=" position: fixed; top: 50%; left: 50%;max-height:85%; z-index:8888; transform: translate(-50%, -50%);min-width:100%; box-shadow: -1px 1px 5px #888;">
            <source src="./UploadedFiles/Imax.mp4" type="video/mp4">
        </video>
        <div style="position: fixed; top: 50%; left: 50%; z-index:9999; transform: translate(-50%, -50%);">
            <h1 style="color: white; text-shadow: 0 0 15px #fff">Cinematrix App</h1>
            <i style="color: lightgrey; text-shadow: 0 0 15px #fff">fastest way to guarantee your movie night</i>
        </div>
    </div>
</asp:Content>
