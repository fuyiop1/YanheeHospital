using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace YanheeHospital.Models
{
    public static class YanheeHospitalDbContextInitializer
    {
        public static void InitDatabaseSetup(){
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<YanheeHospitalDbContext>());
        }
    }
}