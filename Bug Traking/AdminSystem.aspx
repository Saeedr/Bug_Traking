<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminSystem.aspx.cs" Inherits="Bug_Traking.AdminSystem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span>مدیریت زیر سیستم ها</span>
    <table>
        	<tr>
            	<td>نام</td>
                <td><asp:TextBox ID="txtTickatAddTitle" class="txt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            	<td>پروژه</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList1" class="txt" runat="server"></asp:DropDownList></td>
            </tr>
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnTicketSend"  class="BtnSubmit" runat="server" Text="افزودن" OnClick="btnTicketSend_Click" />
            	</td>
            </tr>
        </table><br />
     <table>
        	<tr>
            	<td>انتخاب پروژه</td>
                <td><asp:DropDownList style="width:261px;" ID="drpSelect" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSelect_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            	<td>نام</td>
                <td><asp:TextBox ID="txtEdit" class="txt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            	<td>پروژه</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList2" class="txt" runat="server"></asp:DropDownList></td>
            </tr>
        	<tr>
            	<td colspan="2" style="text-align:center">
                    <asp:Button id="btnEdir"  class="BtnSubmit" runat="server" Text="ویرایش" OnClick="btnEdir_Click" />
                    <asp:Button id="Button1"  class="btnDel" runat="server" Text="حــذف" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
