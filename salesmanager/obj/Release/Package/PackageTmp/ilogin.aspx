<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ilogin.aspx.cs" Inherits="salesmanager.ilogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>:: Login ::</title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/startmin.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-4 col-md-offset-4">
                    <img class="navbar-brand" src="../img/logo.png" style="margin-top: 10%; margin-left: 30%;" />
                    <div class="login-panel panel panel-default">
                        <div class="panel-heading">
                            <h3 class="panel-title">Please Sign In</h3>
                        </div>
                        <div class="panel-body">
                            <div role="form">
                                <fieldset>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtusername" runat="server" CssClass="form-control" placeholder="Mobile No."></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="* Username" Display="Dynamic"
                                            ControlToValidate="txtusername" CssClass="star"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group">
                                        <asp:TextBox ID="txtpassword" runat="server" CssClass="form-control" placeholder="PIN No." TextMode="Password"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvpassword" runat="server" ErrorMessage="* Password" Display="Dynamic"
                                            ControlToValidate="txtpassword" CssClass="star"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="checkbox">
                                        <label>
                                            <asp:CheckBox ID="chkremember" runat="server" Text="Remember Me" />
                                        </label>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnlogin" runat="server" Text="Login" CssClass="btn btn-success btn-block" OnClick="btnlogin_Click" />
                                        <asp:Label ID="lblmsg" runat="server" Visible="false" CssClass="star"></asp:Label>
                                    </div>
                                    <div class="form-group">
                                        <a href="https://tinyurl.com/y9u7gk4l" target="_blank">
                                            <img class="navbar-brand" src="img/googleplay.png" style="float: right;" /></a>
                                    </div>
                                </fieldset>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- jQuery -->
        <script src="../js/jquery.min.js"></script>
        <!-- Bootstrap Core JavaScript -->
        <script src="../js/bootstrap.min.js"></script>
        <!-- Metis Menu Plugin JavaScript -->
        <script src="../js/metisMenu.min.js"></script>
        <!-- Custom Theme JavaScript -->
        <script src="../js/startmin.js"></script>
    </form>
</body>
</html>
