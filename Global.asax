﻿<%@ Application Language="C#" %>

<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex.Message.Contains("NoCatch") || ex.Message.Contains("maxUrlLength") || ex.Message.Contains("does not exist"))
            return;

        new ExceptionHandler(ex);
        Server.ClearError();
        Response.Redirect("~/Error/500.html");

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends.
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer
        // or SQLServer, the event is not raised.

    }
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        var p = Request.Path.ToLower().Trim();
        if (p.EndsWith("/crystalimagehandler.aspx") && p != "/crystalimagehandler.aspx")
        {
            var fullPath = Request.Url.AbsoluteUri.ToLower();
            var NewURL = fullPath.Replace(".aspx", "");
            Response.Redirect(NewURL);
        }
    }
</script>