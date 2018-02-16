using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Downloads_Download1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Response.ContentType = "executable/exe";
        Response.AppendHeader("Content-Disposition", "attachment; filename=DokuWikiToolBox.exe");
        Response.TransmitFile(Server.MapPath("~/Downloads/DokuWikiToolBox.exe"));
        Response.End();
    }
}