<%@ Page Language="C#" AutoEventWireup="true" CodeFile="loginpage.aspx.cs" Inherits="Pages_Default3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>login</title>
    <link href="/CSS/bootstrap.min.css" rel="stylesheet" />
    <link href="/CSS/font-awesome.min.css" rel="stylesheet" />
    <link href="/CSS/nanoscroller.css" rel="stylesheet" />
    <link href="/CSS/theme_styles.css" rel="stylesheet" />
    <link href="/plugins/bootstrap-sweetalert-master/dist/sweetalert.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server" AsyncPostBackTimeout="600" EnablePageMethods="true"></asp:ScriptManager>
            <asp:UpdateProgress DisplayAfter="0" ID="mainup" runat="server">
                <ProgressTemplate>

                    <div style="background-color: Gray; filter: alpha(opacity=60); opacity: 0.60; width: 100%; top: 0px; left: 0px; position: fixed; height: 100%; z-index: 1000;">
                    </div>
                    <div style="margin: auto; font-family: Trebuchet MS; filter: alpha(opacity=100); opacity: 1; font-size: small; vertical-align: middle; top: 45%; position: fixed; right: 45%; color: #275721; text-align: center; height: 100px; z-index: 2000; border-radius: 10px;">
                        <table style="font-family: Sans-Serif; text-align: center; color: #275721; width: inherit; height: inherit; padding: 15px; z-index: 2001">
                            <tr>
                                <td style="text-align: inherit;">
                                    <img src="/img/ajax-loading.gif" alt="Loading" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </ProgressTemplate>
            </asp:UpdateProgress>

            <div id="login-full-wrapper">
                <div class="container-fluid">
                    <%--     <div class="col-md-1 col-md-offset-1">
                    <img style="width: 220px; background-color: #000; box-shadow: 0 0 22px 4px whitesmoke; padding: 5px;" src="/img/logo.png" alt="" />
                    <asp:Label ID="Label1" runat="server" Text="Version : 1.1 " style=" font-size: 15px; font-weight: bold; "></asp:Label>
                </div>--%>
                </div>
                <div class="container">
                    <div class="row">
                        <div class="col-xs-12">
                            <div id="login-box">
                                <div id="login-box-holder">
                                    <div class="row">
                                        <div class="col-xs-12">
                                            <asp:UpdatePanel UpdateMode="Conditional" ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>
                                                    <div id="login-box-inner">
                                                        <div class="text-center">
                                                            <br />
                                                        </div>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-user"></i></span>
                                                            <asp:TextBox ID="txtUserName" placeholder="User Name" class="form-control" runat="server"></asp:TextBox>

                                                        </div>
                                                        <div class="input-group">
                                                            <span class="input-group-addon"><i class="fa fa-key"></i></span>
                                                            <asp:TextBox ID="txtPassword" TextMode="Password" placeholder="Password" class="form-control" runat="server"></asp:TextBox>

                                                        </div>
                                                        <%--  <div id="remember-me-wrapper">
                                                <div class="row">
                                                    <div class="col-xs-6">
                                                        <div class="checkbox-nice">
                                                            <input runat="server"  type="checkbox" id="rememberme" checked="checked" />
                                                            <label for="remember-me">
                                                                Remember me
														
                                                            </label>
                                                        </div>
                                                    </div>

                                                </div>
                                            </div>--%>
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <asp:Button ID="cmdOK" OnClick="cmdOK_Click" class="btn btn-success col-xs-12" runat="server" Text="Login" />
                                                            </div>
                                                        </div>
                                                       
                                                    </div>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>


                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="config-tool" class="closed">
                <a id="config-tool-cog">
                    <i class="fa fa-cog"></i>
                </a>

                <div id="config-tool-options">
                    <h4>Layout Options</h4>
                    <ul>
                        <li>
                            <div class="checkbox-nice">
                                <input type="checkbox" id="config-fixed-header" />
                                <label for="config-fixed-header">
                                    Fixed Header
					
                                </label>
                            </div>
                        </li>
                        <li>
                            <div class="checkbox-nice">
                                <input type="checkbox" id="config-fixed-sidebar" />
                                <label for="config-fixed-sidebar">
                                    Fixed Left Menu
					
                                </label>
                            </div>
                        </li>
                        <li>
                            <div class="checkbox-nice">
                                <input type="checkbox" id="config-fixed-footer" />
                                <label for="config-fixed-footer">
                                    Fixed Footer
					
                                </label>
                            </div>
                        </li>
                        <li>
                            <div class="checkbox-nice">
                                <input type="checkbox" id="config-boxed-layout" />
                                <label for="config-boxed-layout">
                                    Boxed Layout
					
                                </label>
                            </div>
                        </li>
                        <li>
                            <div class="checkbox-nice">
                                <input type="checkbox" id="config-rtl-layout" />
                                <label for="config-rtl-layout">
                                    Right-to-Left
					
                                </label>
                            </div>
                        </li>
                    </ul>
                    <br />
                    <h4>Skin Color</h4>
                    <ul id="skin-colors" class="clearfix">
                        <li>
                            <a class="skin-changer" data-skin="" data-toggle="tooltip" title="Default" style="background-color: #34495e;"></a>
                        </li>
                        <li>
                            <a class="skin-changer" data-skin="theme-white" data-toggle="tooltip" title="White/Green" style="background-color: #2ecc71;"></a>
                        </li>
                        <li>
                            <a class="skin-changer blue-gradient" data-skin="theme-blue-gradient" data-toggle="tooltip" title="Gradient"></a>
                        </li>
                        <li>
                            <a class="skin-changer" data-skin="theme-turquoise" data-toggle="tooltip" title="Green Sea" style="background-color: #1abc9c;"></a>
                        </li>
                        <li>
                            <a class="skin-changer" data-skin="theme-amethyst" data-toggle="tooltip" title="Amethyst" style="background-color: #9b59b6;"></a>
                        </li>
                        <li>
                            <a class="skin-changer" data-skin="theme-blue" data-toggle="tooltip" title="Blue" style="background-color: #2980b9;"></a>
                        </li>
                        <li>
                            <a class="skin-changer" data-skin="theme-red" data-toggle="tooltip" title="Red" style="background-color: #e74c3c;"></a>
                        </li>
                        <li>
                            <a class="skin-changer" data-skin="theme-whbl" data-toggle="tooltip" title="White/Blue" style="background-color: #3498db;"></a>
                        </li>
                    </ul>
                </div>
            </div>





            <!-- global scripts -->
            <script src="/JS/demo-skin-changer.js"></script>
            <script src="/JS/jquery.js"></script>
            <script src="/JS/bootstrap.js"></script>
            <script src="/JS/jquery.nanoscroller.min.js"></script>
            <script src="/JS/demo.js"></script>
            <script src="/JS/scripts.js"></script>
            <script src="/plugins/bootstrap-sweetalert-master/dist/sweetalert.js"></script>
            <script src="/js/AlertSweet.js"></script>
        </div>
    </form>
</body>
</html>
