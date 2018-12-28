using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Kursova_Aleksandar
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        [WebMethod]
        public string SelectUser(string user, string pass)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionTest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM users WHERE Username = @Username AND Password =  @Password"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@Username", user);
                        cmd.Parameters.AddWithValue("@Password", pass);
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Users";
                            sda.Fill(dt);
                            return JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                        }
                    }
                }
            }
        }

        [WebMethod]
        public string RegisterNewUsers(string user, string pass, int right)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionTest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, Password, Rights) VALUES (@Username, @Password, @Rights)"))
                {
                    cmd.Parameters.AddWithValue("@Username", user);
                    cmd.Parameters.AddWithValue("@Password", pass);
                    cmd.Parameters.AddWithValue("@Rights", right);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return JsonConvert.SerializeObject("Регистрирахте се успешно!", Newtonsoft.Json.Formatting.Indented);
                }

            }

        }

        [WebMethod]
        public string RegisterNewVignette(string number, string date, int cat)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionTest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Vignette (carNumber, expirationDate, category) VALUES (@carNumber, @expirationDate, @category)"))
                {
                    cmd.Parameters.AddWithValue("@carNumber", number);
                    cmd.Parameters.AddWithValue("@expirationDate", date);
                    cmd.Parameters.AddWithValue("@category", cat);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                    return JsonConvert.SerializeObject("Успешно добавихте нова винетка!", Newtonsoft.Json.Formatting.Indented);
                }

            }

        }

        [WebMethod]
        public string ShowAllData()
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionTest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Vignette"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Vignette";
                            sda.Fill(dt);
                            return JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                        }
                    }
                }
            }
        }

        [WebMethod]
        public string SelectVignetteByCarNumber(string number)
        {
            string constr = ConfigurationManager.ConnectionStrings["ConnectionTest"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Vignette WHERE carNumber = @carNumber"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Parameters.AddWithValue("@carNumber", number);
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            dt.TableName = "Vignette";
                            sda.Fill(dt);
                            return JsonConvert.SerializeObject(dt, Newtonsoft.Json.Formatting.Indented);
                        }
                    }
                }
            }
        }
    }
}
