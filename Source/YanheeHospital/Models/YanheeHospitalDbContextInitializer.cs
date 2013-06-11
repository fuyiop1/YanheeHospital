using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace YanheeHospital.Models
{
    public static class YanheeHospitalDbContextInitializer
    {
        public static void InitDatabaseSetup(){
            var isAutoUpdateDatabase = ConfigurationManager.AppSettings["IsAutoUpdateDatabase"];
            if (isAutoUpdateDatabase == "true")
            {
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<YanheeHospitalDbContext>());
            }
            else
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<YanheeHospitalDbContext>());
            }
        }
    }
}