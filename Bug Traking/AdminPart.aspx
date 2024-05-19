<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPart.aspx.cs" Inherits="Bug_Traking.AdminPart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
            <span>مدیریت بخش ها</span>
    <table>
        	<tr>
            	<td>نام</td>
                <td><asp:TextBox ID="txtTickatAddTitle" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator1" ValidationGroup="valid1" ControlToValidate="txtTickatAddTitle" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
            	<td>پروژه</td>
                <td><asp:DropDownList style="width:261px;" ID="drpProject" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProject_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            	<td>زیر سیستم</td>
                <td><asp:DropDownList style="width:261px;" ID="drpSsystem" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSsystem_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            	<td>سرویس</td>
                <td><asp:DropDownList style="width:261px;" ID="drpService" class="txt" runat="server"></asp:DropDownList></td>
            </tr>
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnTicketSend" ValidationGroup="valid1" class="BtnSubmit" runat="server" Text="افزودن" OnClick="btnTicketSend_Click" />
                    <br />
            	</td>
            </tr>
        </table><br />
     <table>
        	<tr>
            	<td>انتخاب سرویس</td>
                <td><asp:DropDownList style="width:261px;" ID="drpSelect" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSelect_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            	<td>نام</td>
                <td><asp:TextBox ID="txtEdit" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator2" ValidationGroup="valid2" ControlToValidate="txtEdit" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
                
            </tr>
            <tr style="text-align:center;">
            	<td colspan="2"><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
            </tr>
            <tr>
            	<td>پروژه</td>
                <td><asp:DropDownList style="width:261px;" ID="drpProjectEdit" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpProjectEdit_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            	<td>زیر سیستم</td>
                <td><asp:DropDownList style="width:261px;" ID="drpSsystemEdit" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSsystemEdit_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            	<td>سرویس</td>
                <td><asp:DropDownList style="width:261px;" ID="drpServiceEdit" class="txt" runat="server"></asp:DropDownList></td>
            </tr>
        	<tr>
            	<td colspan="2" style="text-align:center">
                    <asp:Button id="btnEdir"  class="BtnSubmit" ValidationGroup="valid2" runat="server" Text="ویرایش" OnClick="btnEdir_Click" />
                    <asp:Button id="Button1"  class="btnDel" runat="server" Text="حــذف" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
