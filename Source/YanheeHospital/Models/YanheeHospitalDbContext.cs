using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Configuration;

namespace YanheeHospital.Models
{
    public class YanheeHospitalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserAnswer> UserAnswers { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}