<%@ Page Title="" Language="C#" MasterPageFile="~/Support.Master" AutoEventWireup="true" CodeBehind="SupportSearch.aspx.cs" Inherits="Bug_Traking.SupportSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="jspc-gray.css" />
	<script type="text/javascript" src="js-persian-cal.min.js"></script>
        <span>جستجو در گزارشات</span>

        <table style="border:solid 1px #00ffff;margin-top:10px;margin-bottom:5px;padding:5px;">
            <tr>
                <td>عنوان باگ : </td>
                <td><asp:TextBox ID="txtTitle" CssClass="txtSearch" runat="server"></asp:TextBox></td>
                <td>تاریخ درج باگ : </td>
                <td><input type="text" id="txtDate" name='txtDate' class="txtSearch" /></td>
           </tr>
            <tr>
                <td>انتخاب سورس داده : </td>
                <td colspan="2"><asp:RadioButtonList ID="RadioButtonList1" runat="server" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="True"><asp:ListItem Selected="True" Text="پایگاه داده لوکال" Value="1"></asp:ListItem><asp:ListItem Text="استفاده از وبسرویس" Value="2"></asp:ListItem></asp:RadioButtonList> </td>
           </tr>
            <tr>
                <td>دانشگاه : </td>
                <td><asp:DropDownList AutoPostBack="true" ID="drpUni" class="txtSearch" runat="server" OnSelectedIndexChanged="drpUni_SelectedIndexChanged"></asp:DropDownList></td>
                <td>شبکه شهرستان : </td>
                <td><asp:DropDownList AutoPostBack="true" ID="drpShahrestan" class="txtSearch" runat="server" OnSelectedIndexChanged="drpShahrestan_SelectedIndexChanged"></asp:DropDownList></td>
           </tr>
            <tr>
                <td>مرکز بهداشت درمان : </td>
                <td><asp:DropDownList AutoPostBack="true" ID="drpMarkazBehdasht" class="txtSearch" runat="server" OnSelectedIndexChanged="drpMarkazBehdasht_SelectedIndexChanged"></asp:DropDownList></td>
                <td>پایگاه بهداشت : </td>
                <td><asp:DropDownList AutoPostBack="true" ID="drpPaigahBehdasht" class="txtSearch" runat="server"></asp:DropDownList></td>
           </tr>
            <tr>
                <td>نام شخص گزارش دهنده : </td>
                <td><asp:TextBox ID="txtReportName" CssClass="txtSearch" runat="server"></asp:TextBox></td>
           </tr>
            <tr>
                <td colspan="4" style="text-align:center;"><asp:Button ID="btnSearch2" class="btnSearch" runat="server" Text="بگرد" OnClick="btnSearch2_Click" /></td>
            </tr>
        </table>

    	<table id="tblCartabl" style="width:100%;margin-top:5px;margin-bottom:5px;">
        	<tr style="font-weight:bold;background:rgba(31, 58, 147,0.5);color:#FFF;">
                <td>انتخاب</td>
                <td>کد</td>
            	<td><br />عنوان گزارش<br /><br /></td>
                <td>تاریخ گزارش</td>
                <td>تاریخ مشاده</td>
                <td>نام پروژه</td>
                <td>توضیحات</td>
                <td>تاریخچه</td>
                <td>ضمیمه</td>
                <td>عملیات</td>
            </tr>
                <asp:Repeater ID="Repeater3" runat="server">
                        <ItemTemplate>
                            <tr mohsenID='<%# Eval("id") %>' class="ttr" style='background:rgba(89, 171, 227,0.1);<%# Eval("Part") %>'>
                                <td>
                                    <asp:CheckBox class="chk" style="background:none;" mohsenID='<%# Eval("id") %>' runat="server" />
                                </td>
                                <td>
                                    <%# Eval("id") %>
                                </td>
                                <td>
                                    <%# Eval("Title") %>
                                </td>
                                <td>
                                    <%# Eval("SendDataReport") %>
                                </td>
                                <td>
                                    <%# Eval("SeenDataReport") %>
                                </td>
                                <td>
                                    <%# Eval("ProjectName") %>
                                </td>
                                <td>
                                    <%# Eval("Description") %>
                                </td>
                                <td>
                                    <%# Eval("HasLastError") %>
                                </td>
                                <td>
                                    <%# Eval("FileName") %>
                                </td>
                                <td>
                                    <a href='SupportTiketShow.aspx?id=<%# Eval("id") %>'><input type='button' value='نمایش' class='ShowBtn' /></a>
                                </td>
                            </tr>
                        </ItemTemplate>
                </asp:Repeater>
        </table>
        <div class="DivSetting"">
            <input type="button" style="float:right;padding-top:7px;padding-bottom:7px;margin-top:7px;" id="btnDel1" class="DelBtn" value="حذف موارد" />
                <input type="button" style="float:right;padding-top:7px;padding-bottom:7px;margin-top:7px;"  id="btnShow1" value="ایجاد پوشه" class="ShowBtn"/>
            <div style="margin-right:15px;padding:5px;width:auto;float:right;font-size:12px;">
                <table>
                    <tr>
                        <td>انتقال به پوشه</td>
                        <td><asp:DropDownList ID="drpSendTo" class="drpSendTo2" runat="server"></asp:DropDownList></td>
                        <td><asp:Button ID="btnSendTo" class="ShowBtn" runat="server" Text="انتقال" OnClick="btnSendTo_Click" /></td>
                    </tr>
                </table>
            </div>
        </div>
        <script type="text/javascript">
            var objCal1 = new AMIB.persianCalendar('txtDate');
    </script>
    <script>
        $(document).ready(function () {
            $("#ConfirmDialog2").fadeOut(0);
            $("#ConfirmDialog").fadeOut(0);

            $("#btnDel1").click(function () {
                $("#ConfirmDialog").fadeIn(500);
            });
            $("#btnConfNo").click(function () {
                $("#ConfirmDialog").fadeOut(500);
            })

            $("#btnShow1").click(function () {
                $("#ConfirmDialog2").fadeIn(500);
            });
            $("#btnConfNo1").click(function () {
                $("#ConfirmDialog2").fadeOut(500);
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <div id="ConfirmDialog" class="AllHide">
    	<div class="ConfirmDialog">
        	درخواست های انتخاب شده حذف شوند ؟<br /><br />
            <input type="button" id="btnConfNo" style="padding:10px;padding-right:20px;padding-left:20px;" value="خیر" class="DelBtn"/>
            <asp:Button style="padding:10px;padding-right:20px;padding-left:20px;" ID="btnDel" class="ShowBtn" runat="server" Text="بله" OnClick="btnDel_Click" />
        </div>
     </div>
    <div id="ConfirmDialog2" class="AllHide">
        <div class="ConfirmDialog">
        	نام پوشه : <asp:TextBox ID="txtFoderAd" class="txt" runat="server"></asp:TextBox><br /><br />
            <input type="button" id="btnConfNo1" style="padding:10px;padding-right:20px;padding-left:20px;" value="لغو" class="DelBtn"/>
            <asp:Button style="padding:10px;padding-right:20px;padding-left:20px;" ID="Button1" class="ShowBtn" runat="server" Text="ایجاد" OnClick="Button1_Click" />
        </div>
     </div>
</asp:Content>

