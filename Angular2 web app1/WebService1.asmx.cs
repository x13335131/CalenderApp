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
        public void GetAppointmentsJSON()
        {
            
             List<appointment> apts = new List<appointment>();
            try
            {
                SqlConnection connexion = new SqlConnection();
                SqlCommand cmd = new SqlCommand(" select * from Appointments", connexion);
                connexion.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionWebService"].ToString();
                connexion.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                
                while (dr.HasRows==true)
                {
                    appointment a = new appointment();
                    dr.Read();
                        //  result = dr[0].ToString()+dr[1].ToString();
                        a.id = Convert.ToInt32(dr[0]);
                        a.date = dr[1].ToString();
                        a.description = dr[2].ToString();
                        a.organizer = dr[3].ToString();
                        a.time = "5.00";
                        a.attendees = "mary, rachel";

                    apts.Add(a);
                    
                }
                dr.Close();
                connexion.Close();
            }
            catch(Exception ex)
            {
                Console.WriteLine(" " + ex);
            }
         //   return "Appointment: " + result;
                
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
               
           JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(apts));

          //  return "appointment:"+result;
        }

    }
}
