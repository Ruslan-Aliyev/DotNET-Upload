<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ImageUpload._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <script src="http://slideshow.triptracker.net/slide.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Welcome to ASP.NET!
    </h2>
    <p>
        To learn more about ASP.NET visit <a href="http://www.asp.net" title="ASP.NET Website">www.asp.net</a>.
    </p>
    <p>
        You can also find <a href="http://go.microsoft.com/fwlink/?LinkID=152368&amp;clcid=0x409"
            title="MSDN ASP.NET Docs">documentation on ASP.NET at MSDN</a>.
    </p>
    <asp:FileUpload ID="fuUpload" runat="server" />
    <asp:Button ID="btnUpload" runat="server" Text="Upload" onclick="btnUpload_Click" />
    <br>
    <asp:Label ID="lblStatus" runat="server" style="color:Red;"></asp:Label>
    <br>
    <asp:Repeater ID="rptrUserPhoto" runat="server">
        <ItemTemplate>
            <asp:Image ID="imgUserPhoto" src="<%# Container.DataItem %>" style="width:100px; height:100px;" runat="server" alt="" />
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
