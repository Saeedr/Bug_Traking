<%@ Page Title="" Language="C#" MasterPageFile="~/Support.Master" AutoEventWireup="true" CodeBehind="SupportProfile.aspx.cs" Inherits="Bug_Traking.SupportProfile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span>مدیریت پروفایل</span><br />
            <table style="width:470px;">
        	<tr>
            	<td>نام</td>
                <td><asp:TextBox ID="txtName" class="txt" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="txtName" ErrorMessage="لطفا فیلد را تکمیل کنید" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

           <tr>
            	<td>نام خانوادگی</td>
                <td><asp:TextBox ID="txtFamily" class="txt" runat="server"></asp:TextBox></td>
               <td style="text-align:right;" class="auto-style1">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="لطفا فیلد را تکمیل کنید" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="txtFamily" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
               </td>
            </tr>

            <tr>
            	<td>نام کاربری</td>
                <td><asp:TextBox ID="txtUser" class="txt" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="لطفا فیلد را تکمیل نمایید" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="txtUser" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
               </td>
            </tr>

            <tr>
            	<td>گذرواژه قبلی</td>
                <td><asp:TextBox ID="TextBox1" class="txt" TextMode="Password" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="TextBox1" style="font-size:12px;background:none;" ForeColor="#FF3300">لطفا فیلد را تکمیل نمایید</asp:RequiredFieldValidator>
                </td>
            </tr>
            
        	<tr>
            	<td>گذرواژه</td>
                <td><asp:TextBox ID="txtPass" class="txt" TextMode="Password" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="txtPass" style="font-size:12px;background:none;" ForeColor="#FF3300">لطفا فیلد را تکمیل نمایید</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
            	<td>تکرار گذرواژه</td>
                <td><asp:TextBox ID="txtPass2" TextMode="Password" class="txt" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="txtPass2" style="font-size:12px;background:none;" ForeColor="#FF3300">لطفا فیلد را تکمیل نمایید</asp:RequiredFieldValidator>
                </td>
            </tr>

            <tr>
            	<td>تصویر</td>
                <td colspan="2"><asp:Literal ID="Literal1" runat="server"></asp:Literal><asp:FileUpload ID="UplPic" runat="server" /></td>
            </tr>
            
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnSubmit"  class="BtnSubmit" runat="server" Text="اعمال تغییرات" OnClick="btnSubmit_Click" ValidationGroup="Valid" />
                    
            	</td>
            </tr>
            <tr>
            	<td colspan="3" style="text-align:center;">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="گذرواژه ها با هم برابر نیستند" ControlToCompare="txtPass" ControlToValidate="txtPass2" SetFocusOnError="True" ValidationGroup="Valid"></asp:CompareValidator>
            	</td>
            </tr>
        </table><br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
