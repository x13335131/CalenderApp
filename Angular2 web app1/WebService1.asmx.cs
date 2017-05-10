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

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json, UseHttpGet = true)]
        public void GetAppointmentsJSON(string mo)
        {
            string mon = mo;
            Console.WriteLine("ayy");
            if (mon == "jan")
            {
                appointment[] apts = new appointment[] {

                new appointment()
                {
                    id = 1,
                    date = "12/1/16",
                    time = "1pm",
                    description = "meet mary for lunch",
                    organizer = "mary maguire",
                    attendees = "mary maguire, rachel simons"
                },
                    new appointment()
                    {
                        id = 2,
                        date = "13/1/16",
                        time = "4pm",
                        description = "do project",
                        organizer = "rachel simmons",
                        attendees = " rachel simons"
                    },
                       new appointment()
                       {
                           id = 3,
                           date = "13/1/16",
                           time = "9pm",
                           description = "watch football final",
                           organizer = "gary brien",
                           attendees = "gary brien', 'gary brien, sarah breen, ashley foley"
                       }
                };

                JavaScriptSerializer js = new JavaScriptSerializer();
                Context.Response.Clear();
                Context.Response.ContentType = "application/json";
                Context.Response.Write(js.Serialize(apts));
            }else { Console.WriteLine("");}
        }
    }
        
        
        //public class Employee
        //{
        //    public int Id { get; set; }
        //    public string Name { get; set; }
        //    public int Salary { get; set; }
        //}
        //public class WebService1 : System.Web.Services.WebService
        //{
        //    [WebMethod]
        //    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        //    public string GetEmployessJSON()
        //    {
        //        Employee[] emps = new Employee[] {
        //        new Employee()
        //        {
        //            Id=101,
        //            Name="Nitin",
        //            Salary=10000
        //        },
        //        new Employee()
        //        {
        //            Id=102,
        //            Name="Dinesh",
        //            Salary=100000
        //        }
        //    };
        //        return new JavaScriptSerializer().Serialize(emps);
        //    }
        //}
    
}
