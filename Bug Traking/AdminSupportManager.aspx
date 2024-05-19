<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="AdminSupportManager.aspx.cs" Inherits="Bug_Traking.AdminSupportManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <span>افزودن پشتیبان</span><br />
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
            	<td>شماره تماس</td>
                <td><asp:TextBox ID="txtAddTell" class="txt" runat="server"></asp:TextBox></td>
               <td style="text-align:right;" class="auto-style1">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="لطفا فیلد را تکمیل کنید" SetFocusOnError="True" ValidationGroup="Valid" ControlToValidate="txtAddTell" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
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
            	<td colspan="2" style="text-align:center"><asp:Button id="btnSubmit"  class="BtnSubmit" runat="server" Text="ثبت کاربر" ValidationGroup="Valid" OnClick="btnSubmit_Click" />
            	</td>
            </tr>
            <tr>
            	<td colspan="3" style="text-align:center">
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="گذرواژه ها با هم برابر نیستند" ControlToCompare="txtPass" ControlToValidate="txtPass2" SetFocusOnError="True" ValidationGroup="Valid"></asp:CompareValidator>
            	</td>
            </tr>
        </table><br />

        <span>مدیریت پشتیبنان</span>
                <table style="width:470px;">
           <tr>
            	<td>انتخاب پشتیبان</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList1" runat="server" class="txt" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList></td>
            </tr>
        	<tr>
            	<td>نام</td>
                <td><asp:TextBox ID="TextBox1" class="txt" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" SetFocusOnError="True" ValidationGroup="Valid1" ControlToValidate="TextBox1" ErrorMessage="لطفا فیلد را تکمیل کنید" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>

           <tr>
            	<td>نام خانوادگی</td>
                <td><asp:TextBox ID="TextBox2" class="txt" runat="server"></asp:TextBox></td>
               <td style="text-align:right;" class="auto-style1">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="لطفا فیلد را تکمیل کنید" SetFocusOnError="True" ValidationGroup="Valid1" ControlToValidate="TextBox2" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
               </td>
            </tr>

           <tr>
            	<td>شماره تماس</td>
                <td><asp:TextBox ID="TextBox5" class="txt" runat="server"></asp:TextBox></td>
               <td style="text-align:right;" class="auto-style1">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="لطفا فیلد را تکمیل کنید" SetFocusOnError="True" ValidationGroup="Valid1" ControlToValidate="TextBox5" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
               </td>
            </tr>

            <tr>
            	<td>نام کاربری</td>
                <td><asp:TextBox ID="TextBox3" class="txt" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="لطفا فیلد را تکمیل نمایید" SetFocusOnError="True" ValidationGroup="Valid1" ControlToValidate="TextBox3" style="font-size:12px;background:none;" ForeColor="#FF3300"></asp:RequiredFieldValidator>
               </td>
            </tr>
            
        	<tr>
            	<td>گذرواژه</td>
                <td><asp:TextBox ID="TextBox4" class="txt" runat="server"></asp:TextBox></td>
                <td style="text-align:right;" class="auto-style1">
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" SetFocusOnError="True" ValidationGroup="Valid1" ControlToValidate="TextBox4" style="font-size:12px;background:none;" ForeColor="#FF3300">لطفا فیلد را تکمیل نمایید</asp:RequiredFieldValidator>
                </td>
            </tr>
            
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="Button1"  class="BtnSubmit" runat="server" Text="اعمال تغییرات" ValidationGroup="Valid1" OnClick="Button1_Click" />
                    <asp:Button id="Button2"  class="BtnSubmit" style="background:linear-gradient(#ff0000,#f54d4d);" runat="server" Text="حـــذف" OnClick="Button2_Click" />
            	</td>
            </tr>
            <tr>
            	<td colspan="3" style="text-align:center">
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="گذرواژه ها با هم برابر نیستند" ControlToCompare="txtPass" ControlToValidate="txtPass2" SetFocusOnError="True" ValidationGroup="Valid1"></asp:CompareValidator>
            	</td>
            </tr>
        </table><br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
