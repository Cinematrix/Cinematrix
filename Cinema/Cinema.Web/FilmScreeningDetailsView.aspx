<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilmScreeningDetailsView.aspx.cs" Inherits="Cinema.Web.FilmScreeningDetailsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <%--<div style="display: inline-block">
            <asp:Image ID="MovieImg" runat="server" ImageAlign="Left" Width="300px" />
        </div>--%>
        <div style="display: inline-block; margin-left: 100px">
            <asp:Table ID="Field" runat="server" Height="400px" Width="400px">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton0" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell><asp:TableCell>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell><asp:TableCell>
                        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton6" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton7" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell><asp:TableCell>
                        <asp:ImageButton ID="ImageButton8" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="150" Width="150" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
        <div>
            <a href="FilmScreeningsView.aspx" class="btn btn-info">Back</a>
        </div>
    </div>
</asp:Content>
