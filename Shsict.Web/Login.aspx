<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Shsict.Web.Login" Title="用户登录" Theme="Shsict" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=7" />
    <meta name="keywords" content="" />
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link href="scripts/jquery.mobile/jquery.mobile-1.3.2.min.css" rel="stylesheet" />
    <script src="scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.mobile-1.3.2.min.js" type="text/javascript"></script>
    <script src="scripts/shsict.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {
            var $tbuser = $(".ui-corner-all #tbun");
            var $tbpass = $(".ui-corner-all #tbpass");

            $tbuser.change(function () {
                var _value = $tbuser.val().trim().toUpperCase();
                $tbuser.val(_value);

            });

            $tbpass.change(function () {
                var _value = $tbpass.val().trim().toUpperCase();
                $tbpass.val(_value);
            });

          

        });
    </script>
</head>
<body class="loading">
    <div class="main">
        <div class="login">
            <form id="form1" runat="server">

                <div class=" ui-corner-all ui-shadow con">
                    <h3>用户登录</h3>
                    <label for="lblun" class="ui-hidden-accessible">Username:</label>
                    <asp:TextBox ID="tbun" runat="server"></asp:TextBox>

                    <label for="lblpw" class="ui-hidden-accessible">Password:</label>
                    <asp:TextBox ID="tbpass" runat="server" TextMode="Password"></asp:TextBox>


                    <asp:LinkButton ID="btnLogin" runat="server" OnClick="btnLogin_Click">登录</asp:LinkButton>

                    <asp:LinkButton ID="btnLogout" runat="server" OnClick="btnLogout_Click">登出</asp:LinkButton>
                  
                </div>
                <asp:Label ID="lblwrong" runat="server" Text="错误用户名或密码" Visible="false"></asp:Label>

            </form>
        </div>
    </div>
</body>
</html>
