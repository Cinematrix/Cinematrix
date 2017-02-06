<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FilmScreeningDetailsView.aspx.cs" Inherits="Cinema.Web.FilmScreeningDetailsView" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="jumbotron">
        <div style="margin-left:90px">
            <asp:Image ID="MovieImg" runat="server" ImageUrl="http://www.samsung.com/africa_en/curvedmonitor/images/design_monitor_top_1920.png" Width="400px" />
        </div>
        <div style="margin-left:50px; display:inline-block">
            <asp:Table ID="Field" runat="server" Height="400px" Width="500px">
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton00" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton01" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton02" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton03" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                   <asp:TableCell>
                        <asp:ImageButton ID="ImageButton04" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton05" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton06" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton07" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton08" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                     <asp:TableCell>
                        <asp:ImageButton ID="ImageButton09" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton10" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton11" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton12" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-1 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton13" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                   <asp:TableCell>
                        <asp:ImageButton ID="ImageButton14" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton15" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton16" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-1" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton17" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:ImageButton ID="ImageButton18" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-3 Seat-3" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                     <asp:TableCell>
                        <asp:ImageButton ID="ImageButton19" runat="server" ImageUrl="https://i1.wp.com/freepngimages.com/wp-content/uploads/2015/10/orange-leather-retro-chair.png?w=326" AlternateText="Row-2 Seat-2" CssClass="btn btn-default" OnClick="Button0_Click" Height="90" Width="90" />
                    </asp:TableCell>
                </asp:TableRow>

            </asp:Table>
        </div>
        <div style="display:inline-block; text-align:center; vertical-align:top; margin-left:50px">
            <asp:Button ID="SubmitButton" runat="server" Text="Submit" OnClick="SubmitButton_Click1" CssClass="btn btn-success" />
            <a href="FilmScreeningsView.aspx" class="btn btn-info">Back</a>
        </div>
    </div>
</asp:Content>
