using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class misc_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    
    protected void Btn_login_Click(object sender, EventArgs e)
    {
        bool canLogIn = false;
        var connector = new DataConnector(db_connector.ConnectionString);
        connector.Login(Tb_email.Text, Tb_password.Text, ref canLogIn);

        if (canLogIn)
        {
            Response.Redirect("Tools.aspx");
        }
        else
        {
            Lbl_display_login.Text = "E-mail address and password do not match";
        }
    }

    protected void Btn_register_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
}