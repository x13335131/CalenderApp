using Angular2_web_app1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Script.Serialization;
using System.Data.SqlClient;
using System.Configuration;

namespace Angular2_web_app1
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]

    public class appointment
    {
        public int id { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string description { get; set; }
        public string organizer { get; set; }
        public object attendees { get; set; }
    }
    public class WebService1 : System.Web.Services.WebService
    {
        
        string result;
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public string GetAppointmentsJSON()
        {
            SqlConnection connexion = new SqlConnection();
            List<appointment> apts = new List<appointment>();
            using (connexion) {

          
                    SqlCommand cmd = new SqlCommand(" select Description from Appointments", connexion);
                    connexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionWebService"].ToString();
                    connexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                    var apt = new appointment();
                    apt.id = Convert.ToInt32(dr[0]);
                    apt.date = dr[1].ToString();
                    apt.description = dr[2].ToString();
                    apt.time = "00.00";
                    apt.organizer = "Joan";
                    apt.attendees = "sarah";

                    apts.Add(apt);
                    }
                
                    dr.Close();
                    connexion.Close();
                return apts;
            }
                
            /*appointment[] apts = new appointment[] {
                    new appointment()
                    {
                        id=1,
                        date= "12/1/16",
                        time= "1pm",
                        description="meet mary for lunch",
                        organizer="mary maguire",
                        attendees="mary maguire, rachel simons"
                    },
                    new appointment()
                    {
                        id=2,
                        date= "13/1/16",
                        time= "1pm",
                        description="meet mary for lunch",
                        organizer="mary maguire",
                        attendees="mary maguire, rachel simons"
                    },
                       new appointment()
                    {
                        id=3,
                        date= "13/1/16",
                        time= "1pm",
                        description="meet mary for lunch",
                        organizer="mary maguire",
                        attendees="mary maguire, rachel simons"
                    }
                };*/

          /*  JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(apts));*/
        }

    }
}
