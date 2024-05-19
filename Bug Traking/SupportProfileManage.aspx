<%@ Page Title="" Language="C#" MasterPageFile="~/Support.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="SupportProfileManage.aspx.cs" Inherits="Bug_Traking.SupportProfileManage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <span>افزودن پروفایل کاربر</span><br />
            <table style="width:470px;">
        	
            <tr>
            	<td>نام</td>
                <td><asp:TextBox ID="txtName" MaxLength="15" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator2" ValidationGroup="valid2" ControlToValidate="txtName" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
            	<td>نام خانوادگی</td>
                <td><asp:TextBox ID="txtFamily" MaxLength="15" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator1" ValidationGroup="valid2" ControlToValidate="txtFamily" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>
            
           <tr>
            	<td>تلفن ثابت</td>
                <td><asp:TextBox ID="txtTell1" MaxLength="15" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator3" ValidationGroup="valid2" ControlToValidate="txtTell1" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>
            

            <tr>
            	<td>تلفن همراه</td>
                <td><asp:TextBox ID="txtTell2" MaxLength="11" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator4" ValidationGroup="valid2" ControlToValidate="txtTell2" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>

            <tr>
            	<td>سمت</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList7" class="txt" runat="server" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>رایانامه</td>
                <td><asp:TextBox ID="txtEmail" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator5" ValidationGroup="valid2" ControlToValidate="txtName" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            </tr>

           <tr>
            	<td>جنسیت</td>
                <td><asp:DropDownList style="width:261px;" ID="drpSex" class="txt" runat="server" ><asp:ListItem Text="آقا"></asp:ListItem><asp:ListItem Text="خانم"></asp:ListItem></asp:DropDownList></td>
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
            	<td>استان</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList1" class="txt" runat="server" onchange="FillTghsimat2();" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>شهرستان</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList2" class="txt" runat="server" onchange="FillTghsimat3();" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>بخش</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList3" class="txt" runat="server" onchange="FillTghsimat4();" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>شهر</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList4" class="txt" runat="server" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>دهستان</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList5" class="txt" runat="server" onchange="FillTghsimat6();" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td>روستا یا آبادی</td>
                <td><asp:DropDownList style="width:261px;" ID="DropDownList6" class="txt" runat="server" ></asp:DropDownList></td>
            </tr>

            <tr>
            	<td colspan="2" style="text-align:center"><asp:Button id="btnTicketSend" ValidationGroup="valid2" class="BtnSubmit" runat="server" Text="ثبت پرفایل" OnClick="btnTicketSend_Click" />
                    
            	</td>
            </tr>
        </table><br />
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

         function FillTghsimat2() {
             var id1 = $('#<%=DropDownList1.ClientID%>').val();
             var id = id1.split('§');
             id = id[0];
             $("#ConfirmDialog").fadeIn(0);
             $.ajax({
                 type: "POST",
                 url: pageUrl + '/FillTghsimat',
                 data: "{AreaTypeCode:'2',ParentAreaCode:'" + id + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: FillTghsimat2Sus,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
         }
         function FillTghsimat2Sus(response) {
             $("#<%=DropDownList2.ClientID %>").html("");
             $("#<%=DropDownList3.ClientID %>").html("");
             $("#<%=DropDownList4.ClientID %>").html("");
             $("#<%=DropDownList5.ClientID %>").html("");
             $("#<%=DropDownList6.ClientID %>").html("");
             if (response.d.length > 0) {
                 $.each(response.d, function () {
                     $("#<%=DropDownList2.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                 });
             }
             $("#ConfirmDialog").fadeOut(0);
         }

         function FillTghsimat3() {
             var id1 = $('#<%=DropDownList2.ClientID%>').val();
             var id = id1.split('§');
             id = id[0];
             $("#ConfirmDialog").fadeIn(0);
             $.ajax({
                 type: "POST",
                 url: pageUrl + '/FillTghsimat',
                 data: "{AreaTypeCode:'3',ParentAreaCode:'" + id + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: FillTghsimat3Sus,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
         }
         function FillTghsimat3Sus(response) {
             $("#<%=DropDownList3.ClientID %>").html("");
             $("#<%=DropDownList4.ClientID %>").html("");
             $("#<%=DropDownList5.ClientID %>").html("");
             $("#<%=DropDownList6.ClientID %>").html("");
             if (response.d.length > 0) {
                 $.each(response.d, function () {
                     $("#<%=DropDownList3.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                 });
             }
             $("#ConfirmDialog").fadeOut(0);
         }

         function FillTghsimat4() {
             var id1 = $('#<%=DropDownList3.ClientID%>').val();
             var id = id1.split('§');
             id = id[0];
             $("#ConfirmDialog").fadeIn(0);
             $.ajax({
                 type: "POST",
                 url: pageUrl + '/FillTghsimat',
                 data: "{AreaTypeCode:'4',ParentAreaCode:'" + id + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: FillTghsimat4Sus,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
         }
         function FillTghsimat4Sus(response) {
             $("#<%=DropDownList4.ClientID %>").html("");
             $("#<%=DropDownList5.ClientID %>").html("");
             $("#<%=DropDownList6.ClientID %>").html("");
             if (response.d.length > 0) {
                 $.each(response.d, function () {
                     $("#<%=DropDownList4.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                 });
                 FillTghsimat5();
             }
             $("#ConfirmDialog").fadeOut(0);
         }

         function FillTghsimat5() {
             var id1 = $('#<%=DropDownList3.ClientID%>').val();
             var id = id1.split('§');
             id = id[0];
             $("#ConfirmDialog").fadeIn(0);
             $.ajax({
                 type: "POST",
                 url: pageUrl + '/FillTghsimat',
                 data: "{AreaTypeCode:'5',ParentAreaCode:'" + id + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: FillTghsimat5Sus,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
         }
         function FillTghsimat5Sus(response) {
             $("#<%=DropDownList5.ClientID %>").html("");
             $("#<%=DropDownList6.ClientID %>").html("");
             if (response.d.length > 0) {
                 $.each(response.d, function () {
                     $("#<%=DropDownList5.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                 });
             }
             $("#ConfirmDialog").fadeOut(0);
         }

         function FillTghsimat6() {
             var id1 = $('#<%=DropDownList5.ClientID%>').val();
             var id = id1.split('§');
             id = id[0];
             $("#ConfirmDialog").fadeIn(0);
             $.ajax({
                 type: "POST",
                 url: pageUrl + '/FillTghsimat',
                 data: "{AreaTypeCode:'6',ParentAreaCode:'" + id + "'}",
                 contentType: "application/json; charset=utf-8",
                 dataType: "json",
                 success: FillTghsimat6Sus,
                 failure: function (response) {
                     alert(response.d);
                 }
             });
         }
         function FillTghsimat6Sus(response) {
             $("#<%=DropDownList6.ClientID %>").html("");
             if (response.d.length > 0) {
                 $.each(response.d, function () {
                     $("#<%=DropDownList6.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                 });
             }
             $("#ConfirmDialog").fadeOut(0);
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div id="ConfirmDialog" class="AllHide">
    	<div class="ConfirmDialog">
            <img src="pic/loader.gif" /><br />
            لطفا تامل فرمایید ...
        </div>
     </div>
    <script>
        $(document).ready(function () {
            $("#ConfirmDialog").fadeOut(0);
            var pageUrl2 = '<%=ResolveUrl(Request.RawUrl)%>'
                var RdoVal = $('#<%=RadioButtonList1.ClientID%>').find(":checked").val();
                $("#ConfirmDialog").fadeIn(50);
                $.ajax({
                    type: "POST",
                    url: pageUrl2 + '/FillOstan',
                    data: "{}",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: FillProJectSus,
                    failure: function (response) {
                        alert(response.d);
                    }
                });

            function FillProJectSus(response) {
                $("#<%=DropDownList1.ClientID %>").html("");
                $("#<%=DropDownList2.ClientID %>").html("");
                $("#<%=DropDownList3.ClientID %>").html("");
                $("#<%=DropDownList4.ClientID %>").html("");
                $("#<%=DropDownList5.ClientID %>").html("");
                $("#<%=DropDownList6.ClientID %>").html("");
                if (response.d.length > 0) {
                    $.each(response.d, function () {
                        $("#<%=DropDownList1.ClientID %>").append($("<option></option>").val(this['Value']).html(this['Text']));
                    });
                }
                FillTghsimat2();
                FillTghsimat3();
                FillTghsimat4();
                FillTghsimat5();
                FillTghsimat6();
                $("#ConfirmDialog").fadeOut(50);
            }
        });
    </script>
    <asp:Literal ID="litMess" runat="server"></asp:Literal>
</asp:Content>
