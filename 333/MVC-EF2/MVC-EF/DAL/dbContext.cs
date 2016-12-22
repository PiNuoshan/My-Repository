using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Model;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class dbContext : DbContext, IDisposable
    {
        private static string conStr = @"Data Source=WONBERYSTAFF-PC\SQLEXPRESS;Initial Catalog=CityService;Integrated Security=True";
        public dbContext() : base(conStr) 
        { }

        public DbSet<ComplainRecord> Users { get; set; }
        public DbSet<CityServiceInfo> ServiceInfos { get; set; }
    } 
}
