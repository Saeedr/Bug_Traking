<%@ Page Title="" Language="C#" MasterPageFile="~/User.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ClientAddTicket.aspx.cs" Inherits="Bug_Traking.ClientPortal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<link rel="stylesheet" href="jspc-gray.css" />
	<script type="text/javascript" src="js-persian-cal.min.js"></script>
    
        	<span>ارسال تیکت به مدیر پشتیبانی</span><br />
        <table>
        	<tr>
            	<td>عنوان</td>
                <td><asp:TextBox ID="txtTickatAddTitle" class="txt" runat="server"></asp:TextBox></td>
            </tr>

            <tr>
            	<td>نام گزارش دهنده</td>
                <td><asp:TextBox ID="txtUserName" class="txt" runat="server"></asp:TextBox></td>
            </tr>
            
        	<tr>
            	<td>اولویت</td>
                <td><asp:DropDownList ID="drpTickatAddPriority" class="txt" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>پروژه</td>
                <td><asp:DropDownList ID="drpTickatAddProject" class="txt" runat="server" onchange="FillZirSystem();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>زیرسیستم</td>
                <td><asp:DropDownList ID="drpTickatAddSsystem" class="txt" runat="server" onchange="FillService();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>سرویس</td>
                <td><asp:DropDownList ID="drpTickatAddService" class="txt" runat="server" onchange="FillPart();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>کدام قسمت</td>
                <td><asp:DropDownList ID="drpTickatAddPart" class="txt" runat="server" onchange="FillCategory();" ></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>موضوع باگ</td>
                <td><asp:DropDownList ID="drpTickatAddCategory" class="txt" runat="server" AutoPostBack="True"></asp:DropDownList></td>
            </tr>
            
        	<tr>
            	<td>کلمات کلیدی</td>
                <td>
	<div id="wrapper" runat="server">
        <input id='inputTagator' name='inputTagator' />
	</div></td>
            </tr>
            <tr>
            	<td>ارتباط با تیکت های قبلی</td>
                <td>
                    <asp:HiddenField id="HRabt" runat="server" />
                    <div style="color:#b6ff00;margin-right:10px;padding-top:10px;float:right;margin-left:10px;max-width:100%;margin-bottom:10px;" id="HRabt1" ></div>
                    <input type="button" style="margin-top:10px;margin-bottom:10px;padding-right:5px;padding-left:5px;height:20px;" class="btnSearch" value="..." id="btnGhabli" />
                    <input type="button" style="margin-top:10px;margin-bottom:10px;padding-right:5px;padding-left:5px;height:30px;" onclick="DellGhabli();" class="DelBtn" value="حذف" id="btnGhabliDel" />
                </td>
            </tr>
        	<tr>
            	<td>فایل ضمیمه</td>
                <td><asp:FileUpload ID="TicketUpload" AllowMultiple="true" runat="server" /></td>
            </tr>
            
        	<tr>
            	<td>توضیحات</td>
                <td><asp:TextBox TextMode="MultiLine" ID="txtTickatAddDet" runat="server" class="txt" style="height:100px;max-height:100px;max-width:250px;"></asp:TextBox></td>
            </tr>
            
        	<tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnTicketSend"  class="BtnSubmit" runat="server" Text="ارسال تیکت" OnClick="btnTicketSend_Click" />
                    <br />
                    <asp:Label ID="lblTickatAddStatus" style="background:none;" runat="server" Text=""></asp:Label>
            	</td>
            </tr>
        </table>
    	<script>
    	    if ($('#inputTagator').data('tagator') === undefined) {
    	        $('#inputTagator').tagator({
    	            autocomplete: ['تست', 'second', 'third', 'fourth', 'fifth', 'sixth', 'seventh', 'eighth', 'ninth', 'tenth']
    	        });
    	    } else {
    	        $('#inputTagator').tagator('destroy');
    	    }
	</script>
    <script type="text/javascript">
        var pageUrl = '<%=ResolveUrl(Request.RawUrl)%>'

        function FillZirSystem() {
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
                $("#btnGhabliDel").fadeOut(0);
                $("#ConfirmDialog2").fadeOut(0)
                $("#ConfirmDialog").fadeOut(0)
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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">     <div id="ConfirmDialog2" class="AllHide">
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
            لطفا تامل فرمایید ...
        </div>
     </div>
        <script type="text/javascript">
            var objCal1 = new AMIB.persianCalendar('txtDate');
    </script>
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
    </script>
</asp:Content>
