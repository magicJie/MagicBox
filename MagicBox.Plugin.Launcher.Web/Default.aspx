<%@ Page Title="主页" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="MagicBox.Plugin.Launcher.Web._Default" %>

<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        window.onload = function () {
            alert("这是Default的脚本");
        }
    </script>
    <asp:Panel ID="MainPanel" runat="server" />
    <asp:Label ID="defaultLabel" runat="server" />
</asp:Content>
