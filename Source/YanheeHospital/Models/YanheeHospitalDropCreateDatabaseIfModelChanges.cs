using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace YanheeHospital.Models
{
    public class YanheeHospitalDropCreateDatabaseIfModelChanges : DropCreateDatabaseIfModelChanges<YanheeHospitalDbContext>
    {
        protected override void Seed(YanheeHospitalDbContext context)
        {
            base.Seed(context);
            context.Admins.Add(new Admin()
            {
                UserName = "admin",
                Password = "123qwe"
            });
            context.SaveChanges();
        }
    }
}