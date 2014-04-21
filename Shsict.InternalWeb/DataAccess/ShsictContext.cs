using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

using Shsict.InternalWeb.Models;

namespace Shsict.InternalWeb.DataAccess
{
    public class ShsictConext : DbContext
    {
        public ShsictConext() {
            //Configuration.ProxyCreationEnabled = false;

            #if(Debug)
            //Database.SetInitializer(new FrameworkDataInitializer());
            #endif
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    // 去除生成数据库的表名不为复数
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}        
        
        public DbSet<User> Users { get; set; }
        //public DbSet<Organization> Organizations { get; set; }

    }
}