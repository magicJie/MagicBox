<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default1.aspx.cs" Inherits="MagicBox.Plugin.Launcher.Web.Default1" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        window.onload = function () {
            alert("这是Default1的脚本");
        }
    </script>
<%--    <asp:Label ID="label1" runat="server" Text="default1" />--%>
<%--    <asp:Panel ID="panel1" runat="server" />--%>
</asp:Content>
