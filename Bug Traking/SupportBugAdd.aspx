<%@ Page Title="" Language="C#" MasterPageFile="~/Support.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SupportBugAdd.aspx.cs" Inherits="Bug_Traking.SupportBugAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="jspc-gray.css" />
    <script src="jquery.auto-complete.min.js"></script>
    <link href="jquery.auto-complete.css" rel="stylesheet" />
	<script type="text/javascript" src="js-persian-cal.min.js"></script>
    
        	<span>ارسال تیکت به مدیر پشتیبانی</span><br />
        <table>
        	<tr>
            	<td>عنوان</td>
                <td><asp:TextBox MaxLength="50" ID="txtTickatAddTitle" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="background:none;" ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" Width="3px" ControlToValidate="txtTickatAddTitle" ForeColor="#CC0000" ValidationGroup="valid" SetFocusOnError="True"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
            	<td>نام گزارش دهنده</td>
                <td><input id="txtUserName" name="txtUserName" class="txt" type="text" /></td>
                <td><input type="button" style="width:auto;height:auto;padding:5px;" value="بگرد" class="btnSearch" id="btnFillUser" onclick="PerFill();" /></td>
            </tr>
            
        	<tr>
            	<td>اولویت</td>
                <td><asp:DropDownList style="width:261px;" ID="drpTickatAddPriority" class="txt" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>شدت خطا</td>
                <td><asp:DropDownList style="width:261px;" ID="drpShedat" class="txt" runat="server"></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>پروژه</td>
                <td><asp:DropDownList style="width:261px;" ID="drpTickatAddProject" class="txt" runat="server" onchange="FillZirSystem();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>زیرسیستم</td>
                <td><asp:DropDownList style="width:261px;" ID="drpTickatAddSsystem" class="txt" runat="server" onchange="FillService();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>سرویس</td>
                <td><asp:DropDownList style="width:261px;" ID="drpTickatAddService" class="txt" runat="server" onchange="FillPart();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>قسمت</td>
                <td><asp:DropDownList style="width:261px;" ID="drpTickatAddPart" class="txt" runat="server" onchange="FillCategory();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>موضوع باگ</td>
                <td><asp:DropDownList style="width:261px;" ID="drpTickatAddCategory" class="txt" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>سورس داده ها</td>
                <td><asp:RadioButtonList style="width:150px;float:right;" ID="RadioButtonList1" runat="server" ><asp:ListItem Selected="True" Text="پایگاه داده لوکال" Value="1"></asp:ListItem><asp:ListItem Text="استفاده از وبسرویس" Value="2"></asp:ListItem></asp:RadioButtonList><input class="btnSearch" type="button" value="نمایش" onclick="FillProJect();" /></td>
            </tr>

            <tr>
            	<td>نام دانشگاه</td>
                <td><asp:DropDownList style="width:261px;" ID="drpUniName" onchange="FillShabakeShahrestan();" class="txt" runat="server" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>نام شبکه شهرستان</td>
                <td><asp:DropDownList style="width:261px;" ID="drpShabakeShahrestan" class="txt" runat="server" onchange="FillMarkazBehdaaht();" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>مرکز بهداشت درمان</td>
                <td><asp:DropDownList style="width:261px;" ID="drpMarkazBehdaaht" class="txt" runat="server" onchange="FillKhaneBehdasht();" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>خانه | پایگاه بهداشت</td>
                <td><asp:DropDownList style="width:261px;" ID="drpKhaneBehdasht" class="txt" runat="server" onchange="Filltxt8Code();" ></asp:DropDownList></td>
            </tr>
                
            <tr>
            	<td>کد 8 رقمی</td>
                <td><asp:TextBox ID="txt8Code" ReadOnly="true" MaxLength="8" class="txt" runat="server"></asp:TextBox></td>
            </tr>
            
        	<tr>
            	<td>کلمات کلیدی</td>
                <td>
	<div id="wrapper" runat="server">
       <span style="float:right;width:5px;background:none;"></span> <input id='inputTagator' style="width:261px;padding:2px;" name='inputTagator' />
	</div></td>
            </tr>
            <tr>
            	<td>ارتباط با تیکت های قبلی</td>
                <td>
                    <asp:HiddenField id="HRabt" runat="server" />
                    <div style="color:#086c1f;margin-right:10px;padding-top:10px;float:right;margin-left:10px;max-width:100%;margin-bottom:10px;" id="HRabt1" ></div>
                    <input type="button" style="margin-top:10px;margin-bottom:10px;padding-right:5px;padding-left:5px;height:20px;" class="btnSearch" value="..." id="btnGhabli" />
                    <input type="button" style="margin-top:10px;margin-bottom:10px;padding-right:5px;padding-left:5px;height:30px;" onclick="DellGhabli();" class="DelBtn" value="حذف" id="btnGhabliDel" />
                </td>
            </tr>
        	<tr>
            	<td>فایل ضمیمه</td>
                <td><asp:FileUpload ID="TicketUpload" runat="server" AllowMultiple="true" /></td>
            </tr>
            
        	<tr>
            	<td>توضیحات</td>
                <td><asp:TextBox TextMode="MultiLine" ID="txtTickatAddDet" runat="server" class="txt" style="height:100px;max-height:100px;max-width:250px;"></asp:TextBox></td>
            </tr>
            
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnTicketSend"  class="BtnSubmit" runat="server" Text="ارسال تیکت" OnClick="btnTicketSend_Click" ValidationGroup="valid" />
                    <br />
                    <asp:Label ID="lblTickatAddStatus" style="background:none;" runat="server" Text=""></asp:Label>
            	</td>
            </tr>
        </table>    <script type="text/javascript">
        var objCal1 = new AMIB.persianCalendar('txtDate');
    </script>





    	

    <asp:Literal ID="Literal2" runat="server"></asp:Literal>




        <script type="text/javascript">
    	    var pageUrl = '<%=ResolveUrl(Request.RawUrl)%>'

	                 function FillProJect() {
	                     var RdoVal = $('#<%=RadioButtonList1.ClientID%>').find(":checked").val();
            $("#ConfirmDialog").fadeIn(50);
            $.ajax({
                type: "POST",
                url: pageUrl + '/FillProJect',
                data: "{RdoVal:'" + RdoVal + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: FillProJectSus,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function FillProJectSus(response) {
            $("#<%=drpUniName.ClientID %>").html("");
            $("#<%=drpShabakeShahrestan.ClientID %>").html("");
            $("#<%=drpMarkazBehdaaht.ClientID %>").html("");
            $("#<%=drpKhaneBehdasht.ClientID %>").html("");
            document.getElementById('<%=txt8Code.ClientID%>').value = "";
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpUniName.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            $("#ConfirmDialog").fadeOut(50);
        }

        function FillShabakeShahrestan() {
            var RdoVal = $('#<%=RadioButtonList1.ClientID%>').find(":checked").val();
            var id1 = $('#<%=drpUniName.ClientID%>').val();
            var id = id1.split('§');
            id = id[0];
            $("#ConfirmDialog").fadeIn(50);
            $.ajax({
                type: "POST",
                url: pageUrl + '/ShabakeShahrestan',
                data: "{RdoVal:'" + RdoVal + "',id:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: FillShabakeShahrestanSus,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function FillShabakeShahrestanSus(response) {
            $("#<%=drpShabakeShahrestan.ClientID %>").html("");
            $("#<%=drpMarkazBehdaaht.ClientID %>").html("");
            $("#<%=drpKhaneBehdasht.ClientID %>").html("");
            document.getElementById('<%=txt8Code.ClientID%>').value = "";
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpShabakeShahrestan.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            $("#ConfirmDialog").fadeOut(50);
        }

        function FillMarkazBehdaaht() {
            var RdoVal = $('#<%=RadioButtonList1.ClientID%>').find(":checked").val();
            var id1 = $('#<%=drpShabakeShahrestan.ClientID%>').val();
            var id = id1.split('§');
            id = id[0];
            $("#ConfirmDialog").fadeIn(50);
            $.ajax({
                type: "POST",
                url: pageUrl + '/MarkazBehdaaht',
                data: "{RdoVal:'" + RdoVal + "',id:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: FillMarkazBehdaahtSus,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function FillMarkazBehdaahtSus(response) {
            $("#<%=drpMarkazBehdaaht.ClientID %>").html("");
            $("#<%=drpKhaneBehdasht.ClientID %>").html("");
            document.getElementById('<%=txt8Code.ClientID%>').value = "";
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpMarkazBehdaaht.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            $("#ConfirmDialog").fadeOut(50);
        }

        function FillKhaneBehdasht() {
            var RdoVal = $('#<%=RadioButtonList1.ClientID%>').find(":checked").val();
            var id1 = $('#<%=drpMarkazBehdaaht.ClientID%>').val();
            var id = id1.split('§');
            id = id[0];
            $("#ConfirmDialog").fadeIn(50);
            $.ajax({
                type: "POST",
                url: pageUrl + '/KhaneBehdasht',
                data: "{RdoVal:'" + RdoVal + "',id:'" + id + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: FillKhaneBehdashtSus,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function FillKhaneBehdashtSus(response) {
            $("#<%=drpKhaneBehdasht.ClientID %>").html("");
            document.getElementById('<%=txt8Code.ClientID%>').value = "";
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpKhaneBehdasht.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            $("#ConfirmDialog").fadeOut(50);
        }

        function Filltxt8Code() {
            var id1 = $('#<%=drpKhaneBehdasht.ClientID%>').val();
            var id = id1.split('§');
            id = id[0];
            document.getElementById('<%=txt8Code.ClientID%>').value = id;
        }

            function FillZirSystem() {
                if ($('#<%=drpTickatAddProject.ClientID%>').html() != "") {
                    var id1 = $('#<%=drpTickatAddProject.ClientID%>').val();
                    var id = id1.split('§');
                    id = id[0];
                    $("#ConfirmDialog").fadeIn(0);
                    $.ajax({
                        type: "POST",
                        url: pageUrl + '/ZirSystem',
                        data: "{id:'" + id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: FillZirSystemSus,
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            }
        function FillZirSystemSus(response) {
            $("#<%=drpTickatAddSsystem.ClientID %>").html("");
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpTickatAddSsystem.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            FillService()
            $("#ConfirmDialog").fadeOut(0);
        }

            function FillService() {
                if ($('#<%=drpTickatAddSsystem.ClientID%>').html() != "") {
                    var id1 = $('#<%=drpTickatAddSsystem.ClientID%>').val();
                    var id = id1.split('§');
                    id = id[0];
                    $("#ConfirmDialog").fadeIn(0);
                    $.ajax({
                        type: "POST",
                        url: pageUrl + '/Service',
                        data: "{id:'" + id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: FillServiceSus,
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            }
        function FillServiceSus(response) {
            $("#<%=drpTickatAddService.ClientID %>").html("");
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpTickatAddService.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            FillPart();
            $("#ConfirmDialog").fadeOut(0);
        }

            function FillPart() {
                if ($('#<%=drpTickatAddService.ClientID%>').html() != "") {
                    var id1 = $('#<%=drpTickatAddService.ClientID%>').val();
                    var id = id1.split('§');
                    id = id[0];
                    $("#ConfirmDialog").fadeIn(0);
                    $.ajax({
                        type: "POST",
                        url: pageUrl + '/Part',
                        data: "{id:'" + id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: FillPartSus,
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            }
        function FillPartSus(response) {
            $("#<%=drpTickatAddPart.ClientID %>").html("");
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpTickatAddPart.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            FillCategory();
            $("#ConfirmDialog").fadeOut(0);
        }

            function FillCategory() {
                if ($('#<%=drpTickatAddPart.ClientID%>').html() != "") {
                    var id1 = $('#<%=drpTickatAddPart.ClientID%>').val();
                    var id = id1.split('§');
                    id = id[0];
                    $("#ConfirmDialog").fadeIn(0);
                    $.ajax({
                        type: "POST",
                        url: pageUrl + '/Category',
                        data: "{id:'" + id + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: FillCategorySus,
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
            }
        function FillCategorySus(response) {
            $("#<%=drpTickatAddCategory.ClientID %>").html("");
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#<%=drpTickatAddCategory.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            $("#ConfirmDialog").fadeOut(0);
        }

    </script>
    <script>
        $(document).ready(function () {
            $("#ConfirmDialog2").fadeOut(0)
            $("#btnGhabli").click(function () {
                $("#ConfirmDialog2").fadeIn(500);
            });
            $("#BackGhabli").click(function () {
                $("#ConfirmDialog2").fadeOut(500);
            });

            $("#ListBox1").html("");
        });
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div id="ConfirmDialog2" class="AllHide">
    	<div class="ConfirmDialog" style="margin-top:40vh;">
             <table style="border:solid 1px #ff6a00;margin:auto;">
                                <tr>
                                    <td>جستجو با عنوان : </td>
                                    <td><input type="text" id="txtCode" style="width:130px;float:right;" class="txtSearch" /></td>
                                </tr>
                                <tr>
                                    <td>جستجو با تاریخ ثبت : </td>
                                    <td><input type="text" id="txtDate" name='txtDate' class="txtSearch" /></td>
                                </tr><tr>
                                    <td colspan="2" style="text-align:center;">
                                        <input type="button" id="btnSearch1" onclick="FillGhabli();" style="padding-right:15px;padding-left:15px;" value="بگرد" class="btnSearch" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <select size="4" name="ListGhabli" onchange="GhabliSel();" style="width:100%;height:120px;" id="ListGhabli">
                                        </select>   
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align:center;"><input type="button" id="BackGhabli" style="text-align:center;" value="بازگشت" class="DelBtn" /></td>
                                </tr>
                            </table>
        </div>
     </div>
         <div id="ConfirmDialog" class="AllHide">
    	<div class="ConfirmDialog">
            <img src="pic/loader.gif" /><br />
            لطفا صبر کنید ...
        </div>
     </div>
        <script type="text/javascript">
            var objCal1 = new AMIB.persianCalendar('txtDate');
    </script>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <script type="text/javascript">
        function FillGhabli() {
            var date = document.getElementById("txtDate").value
            var code = document.getElementById("txtCode").value
            $("#ConfirmDialog").fadeIn(0);
            $.ajax({
                type: "POST",
                url: pageUrl + '/FillGhabli',
                data: "{date:'" + date + "',code:'" + code + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: FillGhabliSus,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function FillGhabliSus(response) {
            $("#ListGhabli").html("");
            if (response.d.length > 0) {
                $.each(response.d, function () {
                    $("#ListGhabli").append($("<option></option>").val(this['Value']).html(this['Text']));
                });
            }
            $("#ConfirmDialog").fadeOut(0);
        }

        function GhabliSel() {
            $('#<%=HRabt.ClientID%>').val(document.getElementById("ListGhabli").value);
            $("#HRabt1").html($("#ListGhabli").find(":checked").text());
            $("#ConfirmDialog2").fadeOut(500);
            $("#btnGhabliDel").fadeIn(200)
        }
        function DellGhabli() {
            $('#<%=HRabt.ClientID%>').val("");
            $("#HRabt1").html("");
            $("#btnGhabliDel").fadeOut(200);
        }

        function PerFill () {
            var date = document.getElementById("txtUserName").value;
            $("#ConfirmDialog").fadeIn(0);
            $.ajax({
                type: "POST",
                url: pageUrl + '/WhatPersion',
                data: "{name:'" + date + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: PerSus,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        
        function PerSus(response) {
            $("#<%=drpUniName.ClientID %>").html("");
            $("#<%=drpShabakeShahrestan.ClientID %>").html("");
            $("#<%=drpMarkazBehdaaht.ClientID %>").html("");
            $("#<%=drpKhaneBehdasht.ClientID %>").html("");
            if (response.d != "null") {
                
                var s = response.d.split("!");
                var s2 = s[0].split('§');
                $("#<%=drpUniName.ClientID %>").append($("<option></option>").val(s2[0] + "§" + s2[1]).html(s2[1]));
                var s2 = s[1].split('§');
                $("#<%=drpShabakeShahrestan.ClientID %>").append($("<option></option>").val(s2[0] + "§" + s2[1]).html(s2[1]));
                var s2 = s[2].split('§');
                $("#<%=drpMarkazBehdaaht.ClientID %>").append($("<option></option>").val(s2[0] + "§" + s2[1]).html(s2[1]));
                var s2 = s[3].split('§');
                $("#<%=drpKhaneBehdasht.ClientID %>").append($("<option></option>").val(s2[0] + "§" + s2[1]).html(s2[1]));
                document.getElementById("<%=txt8Code.ClientID %>").value = s[4];
            } $("#ConfirmDialog").fadeOut(0);
        }
    </script>
        <asp:Literal ID="lit1" runat="server"></asp:Literal>
</asp:Content>
