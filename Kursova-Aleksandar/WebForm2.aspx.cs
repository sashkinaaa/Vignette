using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Kursova_Aleksandar
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            PIServiceReference.WebService1SoapClient serviceRef = new PIServiceReference.WebService1SoapClient();
            string rawData = serviceRef.SelectUser(Username.Text,Password.Text);
            if(rawData.Equals("[]"))
            {
                LbError.Text = "Герешно потребителско име или парола!";
                LbError.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                JArray a = JArray.Parse(rawData);
                User newuser = new User();
                foreach (JObject o in a.Children<JObject>())
                {
                    newuser.Id = (int)o["Id"];
                    newuser.Username = (string)o["Username"];
                    newuser.Password = (string)o["Password"];
                    newuser.Rights = (int)o["Rights"];
                }
                    Session["user"] = newuser.Username;
                    Session["rights"] = newuser.Rights;
                    Response.Redirect("WebForm1.aspx");
            }
            
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (RegPassword.Text.Length > 4)
            {
                PIServiceReference.WebService1SoapClient serviceRef = new PIServiceReference.WebService1SoapClient();
                LbResult.Text = serviceRef.RegisterNewUsers(RegUsername.Text, RegPassword.Text, 0);
            }
            else
                LbResult.Text = "Паролата трябва да е с дължина поне 5 символа!";
        }
    }
}