<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminTiketShow.aspx.cs" Inherits="Bug_Traking.AdminTiketShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <span>نمایش گزارش</span>
    	<table cellspacing="5" id="tblShowTicket" style="width:90%;margin:auto;;margin-top:5px;margin-bottom:5px;text-align:center;">
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />عنوان گزارش<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:TextBox class="txt" ID="litTitle" runat="server"></asp:TextBox></td>
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
                <td style="text-align:right;padding-right:10px;"><asp:DropDownList style="width:261px;" ID="liOlaviat" class="txt" runat="server"></asp:DropDownList><asp:Literal ID="litliOlaviat2" runat="server"></asp:Literal></td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />نام پروژه<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:DropDownList style="width:261px;" ID="litProject" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="litProject_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Literal ID="litProject2" runat="server"></asp:Literal>
                </td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />زیر سیستم<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:DropDownList style="width:261px;" ID="litSystem" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="litSystem_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Literal ID="litSystem2" runat="server"></asp:Literal>
                </td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />سرویس<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:DropDownList style="width:261px;" ID="litService" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="litService_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Literal ID="litService2" runat="server"></asp:Literal>
                </td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />بخش<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:DropDownList style="width:261px;" ID="litPart" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="litPart_SelectedIndexChanged"></asp:DropDownList>
                    <asp:Literal ID="litPart2" runat="server"></asp:Literal>
                </td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />دسته بندی<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:DropDownList style="width:261px;" ID="litCategori" class="txt" runat="server" AutoPostBack="True"></asp:DropDownList>
                    <asp:Literal ID="litCategori2" runat="server"></asp:Literal>
                </td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />توضیحات<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:TextBox TextMode="MultiLine" ID="litDiscription" runat="server" class="txt" style="height:100px;max-height:100px;max-width:250px;"></asp:TextBox></td>
            </tr>
            <tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />عنوان حل خطا :<br /><br /></td>
                <td style="text-align:right;padding-right:10px;">
                    <asp:Literal ID="Literal2" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />وضعیت در پشتیبانی :<br /><br /></td>
                <td style="text-align:right;padding-right:10px;">
                    <asp:Literal ID="Literal3" runat="server"></asp:Literal>
                </td>
            </tr>
        	<tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />وضعیت<br /><br /></td>
                <td style="text-align:right;padding-right:10px;"><asp:Literal ID="litStatus" runat="server"></asp:Literal></td>
            </tr>
            <tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />کامنت های مدیر :<br /><br /></td>
                <td style="text-align:right;padding-top:10px;">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
            <tr >
            	<td style="font-weight:bold;background:url(pic/LoginBG2.png);color:#FFF;"><br />کامنت برای این پست<br /><br /></td>
                <td style="text-align:right;padding-right:10px;">
                    <asp:TextBox TextMode="MultiLine" ID="txtTickatAddDet" runat="server" class="txt" style="height:100px;max-height:100px;max-width:250px;"></asp:TextBox>
                    <br />
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal"></asp:CheckBoxList>
                    <br />
                    <asp:Button ID="Button1" runat="server" style="padding-right:10px;padding-left:10px;" class="btnSearch" Text="افزودن کامنت" OnClick="Button1_Click" /><br />
                </td>
            </tr>
            <tr style="background:none;">
            	<td colspan="2"><a href="AdminKartable.aspx"><input type="button" value="بازگشت" style="padding-right:10px;padding-left:10px;" class="btnSearch" /></a>
                    <asp:Button ID="Button2" runat="server" style="padding-right:10px;padding-left:10px;" class="btnSearch" Text="ویرایش تیکت" OnClick="Button2_Click" />
            	</td>
            </tr>
        </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
