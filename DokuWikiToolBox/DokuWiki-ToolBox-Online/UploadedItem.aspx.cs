using System;

public partial class UploadedItem : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentType = "text/txt";
        Response.AppendHeader("Content-Disposition", "attachment; filename=file.txt");
        Response.TransmitFile(Server.MapPath("~/Output/file.txt"));
        Response.End();
    }
}