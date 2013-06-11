using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace YanheeHospital
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ModelBinders.Binders.Add(typeof(YanheeHospital.Models.UserAnswer), new YanheeHospital.Helpers.UserAnswerModelBinder());

            YanheeHospital.Helpers.DateTimeHelper.SetTimeZoneOffSet();
            
            YanheeHospital.Helpers.LogHelper.LogFilePath = Server.MapPath("~/log.txt");
            YanheeHospital.Models.YanheeHospitalDbContextInitializer.InitDatabaseSetup();

        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            var path = Request.Url.AbsolutePath;
            if (path == "/")
            {
                Response.Redirect("User/AdminLogin");
            }
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception exception = Server.GetLastError();

            YanheeHospital.Helpers.LogHelper.WriteLog(exception.ToString());

            Response.Clear();

            var routeData = new RouteData();
            routeData.Values.Add("controller", "Error");
            routeData.Values.Add("action", "Error");
            Server.ClearError();

            IController errorController = new YanheeHospital.Controllers.ErrorController();
            errorController.Execute(new RequestContext(new HttpContextWrapper(this.Context), routeData));
        }

    }
}