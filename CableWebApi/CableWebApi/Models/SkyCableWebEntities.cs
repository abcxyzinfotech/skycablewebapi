using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CableWebApi.Models
{
    public class SkyCableWebEntities : DbContext
    {
        public SkyCableWebEntities() : base("name=SkyCableWebEntities")
        {

        }

        public DbSet<LoginViewModel> loginviewmodel { get; set; }
        public DbSet<CompanyMasterModel> companymastermodel { get; set; }
        public DbSet<DatabaseNameModel> databasenamemodel { get; set; }
        public DbSet<RegModel> regmodel { get; set; }
        public DbSet<SetupDetailModel> setupdetailsmodel { get; set; }
        public DbSet<FormNameModel> formnamemodel { get; set; }
        public DbSet<AdminPinModel> adminpinmodel { get; set; }
        public DbSet<AgentModel> agentmodel { get; set; }
        public DbSet<AreaModel> areamodel { get; set; }
        public DbSet<packageModel> packagemodel { get; set; }
        public DbSet<ReconnectModel> reconnectmodel { get; set; }
        public DbSet<BillDetailsModel> billdetailsmodel { get; set; }
        public DbSet<CDateModel> cdatemodel { get; set; }
    }
}