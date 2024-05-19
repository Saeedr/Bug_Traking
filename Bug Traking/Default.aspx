<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bug_Traking.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name='verify-v1' content='tU7FVI5X324AZ/lunMPXSzMfG/YOh8u+MojojfiJqXI=' />
<meta http-equiv='Content-Language' content='fa' /> 
    <title>ورود به سیستم</title>
    <link rel="stylesheet" type="text/css" href="style.css"/>
    <script src="jquery-1.9.1.min.js"></script>
    <script>
        $(document).ready(function (e) {
            //$("#txtUser").blur(function(e) {
            //   if($(this).val()=="")
            //       $("#Err1").css("visibility","visible");
            //   else
            //       $("#Err1").css("visibility","hidden");
            //});
            //$("#txtPass").blur(function(e) {
            //   if($(this).val()=="")
            //       $("#Err2").css("visibility","visible");
            //   else
            //       $("#Err2").css("visibility","hidden");
            //});
           <%-- function FillProJect2() {
                if (document.getElementById('<%=txtUser.Text%>').value == "") {
                    document.getElementById('msg').innerHTML = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>لطفا نام کاربری را وارد کنید</div>";
                }
                else if (document.getElementById('<%=txtPass.Text%>').value == "") {
                    document.getElementById('msg').innerHTML = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>لطفا گذرواژه را وارد کنید</div>";
                }
            }--%>
            $("#<%=txtUser.ClientID%>").blur(function () {
                if (document.getElementById('<%=txtUser.ClientID%>').value == "")
                    document.getElementById('msg').innerHTML = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>لطفا نام کاربری را وارد کنید</div>";
            });
            $("#<%=txtPass.ClientID%>").blur(function () {
                if (document.getElementById('<%=txtPass.ClientID%>').value == "")
                    document.getElementById('msg').innerHTML = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>لطفا گذرواژه را وارد کنید</div>";
            });
        });
    </script>

</head>
<body bgcolor="#efefef">
    <form id="form1" runat="server">
        <div id="BG">
                </div>
                <div id="Main">
	                <div id="LoginItem">
    	                <table width="248">
                          <tr>
                            <td>نام کاربری : </td>
                            <td><asp:TextBox ID="txtUser" class="txt" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator1" ValidationGroup="valid1" ControlToValidate="txtUser" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            
                          </tr>
                          <tr>
                            <td>گذرواژه : </td>
                            <td><asp:TextBox ID="txtPass" class="txt" runat="server" TextMode="Password"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator style="width:0px;height:0px;display:inline;float:right;" ID="RequiredFieldValidator2" ValidationGroup="valid1" ControlToValidate="txtPass" runat="server" SetFocusOnError="true"></asp:RequiredFieldValidator></td>
            
                          </tr>
                        </table>
                    </div>
                    <div id="OnlinMod">
                 <spam style="color:#060;">
                     <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="  مدیر" Value="1" Selected="True" class="rdo"></asp:ListItem>
                                    <asp:ListItem Text="  پشتیبان" Value="2" class="rdo"></asp:ListItem>
                                </asp:RadioButtonList>
                 </spam>
                    </div>
                    <asp:Button ID="Button1" runat="server" style="margin-top:190px;float:left;margin-right:7px;" class="btn" ValidationGroup="valid1" Text="ورود به سامانه" OnClick="btnSubmit_Click" />
<%--                    <input type="button" style="margin-top:190px;float:left;margin-right:7px;" class="btn" value="ورود به سامانه" onclick="FillProJect();" />--%>
                </div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        <div id="msg"></div>
        <div id="ConfirmDialog" class="AllHide">
    	    <div class="ConfirmDialog">
            <img src="pic/loader.gif" /><br />
                لطفا صبر کنید ...
            </div>
        </div>
            <script>
                $(document).ready(function () {
                    $("#ConfirmDialog").fadeOut(0);
                });
            </script>
        <script type="text/javascript">
            var pageUrl = '<%=ResolveUrl(Request.RawUrl)%>'

            function FillProJect() {
                var RdoVal = $('#<%=RadioButtonList1.ClientID%>').find(":checked").val();
                var user = document.getElementById('<%=txtUser.ClientID%>').value;
                var pass = document.getElementById('<%=txtPass.ClientID%>').value;
                if (user == "") {
                    document.getElementById('msg').innerHTML = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>نام کاربری نمیتواند خالی باشد</div>";
                }
                else if (pass == "") {
                    document.getElementById('msg').innerHTML = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>گذرواژه نمیتواند خالی باشد</div>";
                }
                else {
                    $("#ConfirmDialog").fadeIn(0);
                    $.ajax({
                        type: "POST",
                        url: pageUrl + '/Login',
                        data: "{user:'" + user + "',pass:'" + pass + "',role:'" + RdoVal + "'}",
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: FillProJectSus,
                        failure: function (response) {
                            alert(response.d);
                        }
                    });
                }
        }
            function FillProJectSus(response) {
                if (response.d == "user") {
                    window.location.href = "SupportDashboard.aspx";
                }
                else if (response.d == "admin") {
                    window.location.href = "AdminKartable.aspx";
                }
                else {
                    document.getElementById('msg').innerHTML = "<div class='OKPM' style='color:#a10f0f;background:#f39393;box-shadow:0px 0px 10px #f39393;'>" + response.d + "</div>";
                }
                $("#ConfirmDialog").fadeOut(0);
            }
        </script>

    </form>
</body>
</html>
