<%@ Page Title="" Language="C#" MasterPageFile="~/Support.Master" AutoEventWireup="true" CodeBehind="SupportProfileDel.aspx.cs" Inherits="Bug_Traking.SupportProfileDel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <span>افزودن پروفایل کاربر</span><br />
            <table style="width:470px;">
        	
            <tr>
            	<td>انتخاب پروفایل</td>
                <td><asp:DropDownList ID="drpSelect" class="txt" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpSelect_SelectedIndexChanged" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>نام</td>
                <td><asp:TextBox MaxLength="15" ID="txtName" class="txt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            	<td>نام خانوادگی</td>
                <td><asp:TextBox MaxLength="15" ID="txtFamily" class="txt" runat="server"></asp:TextBox></td>
            </tr>
            
           <tr>
            	<td>تلفن ثابط</td>
                <td><asp:TextBox MaxLength="15" ID="txtTell1" class="txt" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
            	<td>تلفن همراه</td>
                <td><asp:TextBox MaxLength="11" ID="txtTell2" class="txt" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
            	<td>سمت</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList7" class="txt" runat="server" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>رایانامه</td>
                <td><asp:TextBox ID="txtEmail" class="txt" runat="server"></asp:TextBox></td>
            </tr>

           <tr>
            	<td>جنسیت</td>
                <td><asp:DropDownList style="width:261px;" ID="drpSex" class="txt" runat="server" ><asp:ListItem Text="آقا"></asp:ListItem><asp:ListItem Text="خانم"></asp:ListItem></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>سورس داده ها</td>
                <td><asp:RadioButtonList style="width:150px;float:right;" ID="RadioButtonList1" runat="server" ><asp:ListItem Selected="True" Text="پایگاه داده لوکال" Value="1"></asp:ListItem><asp:ListItem Text="استفاده از وبسرویس" Value="2"></asp:ListItem></asp:RadioButtonList><asp:Button ID="Button1" class="btnSearch" runat="server" Text="نمایش" OnClick="Button1_Click" /></td>
            </tr>

            <tr>
            	<td>نام دانشگاه</td>
                <td><asp:DropDownList style="width:261px;" ID="drpUniName" OnSelectedIndexChanged="drpUniName_SelectedIndexChanged" class="txt" runat="server" AutoPostBack="True" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal11" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>نام شبکه شهرستان</td>
                <td><asp:DropDownList style="width:261px;" ID="drpShabakeShahrestan" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpShabakeShahrestan_SelectedIndexChanged" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal10" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>مرکز بهداشت درمان</td>
                <td><asp:DropDownList style="width:261px;" ID="drpMarkazBehdaaht" class="txt" runat="server"  AutoPostBack="True" OnSelectedIndexChanged="drpMarkazBehdaaht_SelectedIndexChanged" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal9" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>خانه | پایگاه بهداشت</td>
                <td><asp:DropDownList style="width:261px;" ID="drpKhaneBehdasht" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="drpKhaneBehdasht_SelectedIndexChanged" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal8" runat="server"></asp:Literal></td>
            </tr>
                
            <tr>
            	<td>کد 8 رقمی</td>
                <td><asp:TextBox ID="txt8Code" TextMode="Number" MaxLength="8" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:Literal ID="Literal7" runat="server"></asp:Literal></td>
            </tr>
            
            <tr>
            	<td>استان</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList1" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal6" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>شهرستان</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList2" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal5" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>بخش</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList3" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal4" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>شهر</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList4" class="txt" runat="server" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal3" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>دهستان</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList5" class="txt" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal2" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td>روستا یا آبادی</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList6" class="txt" runat="server" ></asp:DropDownList></td>
                <td><asp:Literal ID="Literal1" runat="server"></asp:Literal></td>
            </tr>

            <tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnTicketSend"  class="BtnSubmit" runat="server" Text="ویرایش پروفایل" OnClick="btnTicketSend_Click" />
                    <asp:Button id="Button2"  class="btnDel" runat="server" Text="حــذف" OnClick="Button2_Click" />
            	</td>
            </tr>
        </table><br />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
