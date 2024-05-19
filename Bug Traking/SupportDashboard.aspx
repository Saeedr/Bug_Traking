<%@ Page Title="" Language="C#" MasterPageFile="~/Support.Master" AutoEventWireup="true" CodeBehind="SupportDashboard.aspx.cs" Inherits="Bug_Traking.SupportDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span>داشبورد</span>
    <script src="js/highcharts.js" charset="UTF-8"></script>
    <script src="js/modules/exporting.js" charset="UTF-8"></script>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <style>.containers *{direction:ltr;}</style>
    <div id="container" class="containers" style="min-width:310px;height:400px;max-width:95%;margin:20px auto;margin-top:60px;"></div>


    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
    <div id="container1" class="containers" style="min-width: 300px; height: 600px; margin: 0 auto;max-width:95%;margin-bottom:20px;"></div>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
