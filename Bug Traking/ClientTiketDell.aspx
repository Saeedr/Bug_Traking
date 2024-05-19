<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" AutoEventWireup="true" CodeBehind="ClientTiketDell.aspx.cs" Inherits="Bug_Traking.ClientTiketDell" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <span>حـــذف گزارش</span>
    	<table cellspacing="5" id="tblShowTicket" style="width:90%;margin:auto;;margin-top:5px;margin-bottom:5px;text-align:center;">
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />عنوان گزارش<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litTitle" runat="server"></asp:Literal></td>
            </tr>
        	<tr bordercolor="#FF0000">
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;width:120px;"><br />تاریخ ارسال<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litSendDate" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />تاریخ مشاهده<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litShowDate" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />اولویت<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litOlaviat" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />نام پروژه<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litProject" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />زیر سیستم<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litSystem" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />سرویس<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litService" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />بخش<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litPart" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />دسته بندی<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litCategori" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />توضیحات<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litDiscription" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />وضعیت<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litStatus" runat="server"></asp:Literal></td>
            </tr>
            <tr style="background:none;">
            	<td colspan="2"><asp:Button ID="btnDel" runat="server" class="btnDel" Text="حذف مورد" OnClick="btnDel_Click" /></td>
            </tr>
        </table>
</asp:Content>
