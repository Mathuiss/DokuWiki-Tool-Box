using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Btn_register_Click(object sender, EventArgs e)
    {
        if (Tb_password.Text == Tb_password2.Text && Tb_password != null)
        {
            var dataCon = new DataConnector(db_connector.ConnectionString);
            dataCon.Register(Tb_name.Text, Tb_email.Text, Tb_password.Text);
            Response.Redirect("RegistrationSuccess.aspx");
        }
    }
}