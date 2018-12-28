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
    public partial class WebForm1 : System.Web.UI.Page
    {
        private ObservableCollection<Vignette> VignettesList;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null)
            {
                LbHello.Text = "Здравейте, " + Session["user"] + "!";
                if (int.Parse(Session["Rights"].ToString()) == 0)
                    BtnShow.Visible = false;
            }
            else
            {
                Response.Redirect("WebForm2.aspx");
            }
            this.VignettesList = new ObservableCollection<Vignette>();
        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
            if (int.Parse(Session["Rights"].ToString()) == 0)
                MsgBox("Нямате права за тази операция!", this.Page, this);
            else
            {
                PIServiceReference.WebService1SoapClient serviceRef = new PIServiceReference.WebService1SoapClient();
                LbResult.Text = serviceRef.RegisterNewVignette(carNumber.Text, expirationDate.Text, int.Parse(Category.Text));
                BtnShow_Click(sender, e);
            }
        }
        protected void BtnSelect_Click(object sender, EventArgs e)
        {
            PIServiceReference.WebService1SoapClient serviceRef = new PIServiceReference.WebService1SoapClient();
            string rawData = serviceRef.SelectVignetteByCarNumber(Number.Text);
            if (rawData.Equals("[]"))
            {
                LbResult2.Text = "Няма намерени записи по въведения от вас номер!";
                LbResult2.ForeColor = System.Drawing.Color.Red;
                dataGrid.Visible = false;
            }
            else
            {
                JArray a = JArray.Parse(rawData);
                foreach (JObject o in a.Children<JObject>())
                {
                    Vignette newVignette = new Vignette();
                    newVignette.Id = (int)o["Id"];
                    newVignette.carNumber = (string)o["carNumber"];
                    newVignette.expirationDate = (string)o["expirationDate"];
                    newVignette.Category = (int)o["category"];
                    VignettesList.Add(newVignette);
                }
                LbResult2.Text = "Търсенето беше успешно! Резултатите са показани в таблицата долу.";
                LbResult2.ForeColor = System.Drawing.Color.Blue;
                dataGrid.DataSource = VignettesList;
                dataGrid.DataBind();
                dataGrid.Visible = true;
            }
            
        }
        protected void BtnShow_Click(object sender, EventArgs e)
        {
            PIServiceReference.WebService1SoapClient serviceRef = new PIServiceReference.WebService1SoapClient();
            string rawData = serviceRef.ShowAllData();
            JArray a = JArray.Parse(rawData);
            foreach (JObject o in a.Children<JObject>())
            {
                Vignette newVignette = new Vignette();
                newVignette.Id = (int)o["Id"];
                newVignette.carNumber = (string)o["carNumber"];
                newVignette.expirationDate = (string)o["expirationDate"];
                newVignette.Category = (int)o["category"];
                VignettesList.Add(newVignette);
            }
            LbResult2.Text = "Търсенето беше успешно! Резултатите са показани в таблицата долу.";
            LbResult2.ForeColor = System.Drawing.Color.Blue;
            dataGrid.DataSource = VignettesList;
            dataGrid.DataBind();
            dataGrid.Visible = true;
        }
        public void MsgBox(String ex, Page pg, Object obj)
        {
            string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
            Type cstype = obj.GetType();
            ClientScriptManager cs = pg.ClientScript;
            cs.RegisterClientScriptBlock(cstype, s, s.ToString());
        }
    }
}