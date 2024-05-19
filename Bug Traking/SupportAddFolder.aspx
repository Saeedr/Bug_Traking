<%@ Page Title="" Language="C#" MasterPageFile="~/Support.Master" AutoEventWireup="true" CodeBehind="SupportAddFolder.aspx.cs" Inherits="Bug_Traking.SupportAddFolder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span>ویرایش پروفایل</span><br />
            <table style="width:470px;">
        	<tr>
            	<td>نام پوشه</td>
                <td><asp:TextBox ID="txtName" class="txt" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="txtName" ErrorMessage="لطفا فیلد را تکمیل کنید" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnSubmit"  class="BtnSubmit" runat="server" Text="اعمال تغییرات" OnClick="btnSubmit_Click" ValidationGroup="Valid" />
            	</td>
            </tr>
        </table><br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
