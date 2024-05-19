<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminPriority.aspx.cs" Inherits="Bug_Traking.AdminProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span>مدیریت اولویت ها</span>
    <table>
        	<tr>
            	<td>عنوان</td>
                <td><asp:TextBox ID="txtTickatAddTitle" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator1" ValidationGroup="valid1" ControlToValidate="txtTickatAddTitle" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>
        	<tr>
            	<td>حداکثر زمان حل مشکل به ساعت :</td>
                <td><asp:TextBox ID="TextBox1" class="txt" runat="server"></asp:TextBox></td>
            </tr>
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button ValidationGroup="valid1" id="btnTicketSend"  class="BtnSubmit" runat="server" Text="افزودن" OnClick="btnTicketSend_Click" />
                   
            	</td>
            </tr>
        </table><br />
     <table>
        	<tr>
            	<td>انتخاب اولویت</td>
                <td><asp:DropDownList style="width:261px;" ID="drpSelect" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpSelect_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
            <tr>
            	<td>عنوان</td>
                <td><asp:TextBox ID="txtEdit" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator2" ValidationGroup="valid2" ControlToValidate="txtEdit" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>
        	<tr>
            	<td>حداکثر زمان حل مشکل به ساعت :</td>
                <td><asp:TextBox ID="TextBox2" class="txt" runat="server"></asp:TextBox></td>
            </tr>
        	<tr>
            	<td colspan="2" style="text-align:center">
                    <asp:Button id="btnEdir" ValidationGroup="valid2"  class="BtnSubmit" runat="server" Text="ویرایش" OnClick="btnEdir_Click" />
                    <asp:Button id="Button1"  class="btnDel" runat="server" Text="حــذف" OnClick="Button1_Click" />
                </td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
