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
        private ObservableCollection<User> UsersList;
        protected void Page_Load(object sender, EventArgs e)
        {
            this.UsersList = new ObservableCollection<User>();
        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            PIServiceReference.WebService1SoapClient serviceRef = new PIServiceReference.WebService1SoapClient();
            string rawData = serviceRef.SelectUser(Username.Text,Password.Text);
            JArray a = JArray.Parse(rawData);
            foreach (JObject o in a.Children<JObject>())
            {
                User newuser = new User();
                newuser.Id = (int)o["Id"];
                newuser.Username = (string)o["Username"];
                newuser.Password = (string)o["Password"];
                newuser.Rights = (int)o["Rights"];
                UsersList.Add(newuser);
            }
            if (UsersList.Count == 1)
            {
                Session["user"] = UsersList.ElementAt(0).Username;
                Session["rights"] = UsersList.ElementAt(0).Rights;
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                LbError.Text = "Герешно потребителско име или парола!";
                LbError.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            PIServiceReference.WebService1SoapClient serviceRef = new PIServiceReference.WebService1SoapClient();
            LbResult.Text = serviceRef.RegisterNewUsers(RegUsername.Text, RegPassword.Text, 0);
        }
    }
}