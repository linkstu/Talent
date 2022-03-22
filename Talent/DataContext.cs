using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Talent.Models;
using WalkingTec.Mvvm.Core;

namespace Talent
{
    public class DataContext : FrameworkContext
    {
        #region 基础
        public DbSet<Article> Articles { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<IndustryCategory> IndustryCategorys { get; set; }
        public DbSet<ServiceCategory> ServiceCategorys { get; set; }
        #endregion

        #region 网站内容
        public DbSet<ArticleCategory> ArticleCategorys { get; set; }
        #endregion

        #region 服务场所
        public DbSet<Service> Services { get; set; }
        #endregion

        #region 服务单位
        public DbSet<ServiceUnit> ServiceUnits { get; set; }
        #endregion
        public DbSet<FrameworkUser> FrameworkUsers { get; set; }

        public DataContext(CS cs)
             : base(cs)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype)
            : base(cs, dbtype)
        {
        }

        public DataContext(string cs, DBTypeEnum dbtype, string version = null)
            : base(cs, dbtype, version)
        {
        }

        
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public override async Task<bool> DataInit(object allModules, bool IsSpa)
        {
            var state = await base.DataInit(allModules, IsSpa);
            bool emptydb = false;
            try
            {
                emptydb = !Set<FrameworkUser>().Any() && !Set<FrameworkUserRole>().Any();
            }
            catch { }
            if (state == true || emptydb == true)
            {
                //when state is true, means it's the first time EF create database, do data init here
                //当state是true的时候，表示这是第一次创建数据库，可以在这里进行数据初始化
                var user = new FrameworkUser
                {
                    ITCode = "admin",
                    Password = Utils.GetMD5String("000000"),
                    IsValid = true,
                    Name = "Admin"
                };

                var userrole = new FrameworkUserRole
                {
                    UserCode = user.ITCode,
                    RoleCode = "001"
                };
                
                Set<FrameworkUser>().Add(user);
                Set<FrameworkUserRole>().Add(userrole);
                await SaveChangesAsync();
            }
            return state;
        }

    }

    /// <summary>
    /// DesignTimeFactory for EF Migration, use your full connection string,
    /// EF will find this class and use the connection defined here to run Add-Migration and Update-Database
    /// </summary>
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            //return new DataContext("Host=localhost;Database=Talent;Username=postgres;Password=link;Port=5433;Pooling=true;", DBTypeEnum.PgSql);
            return new DataContext("Host=173.254.201.205;Database=Talent;Username=system;Password=Aishi@1985;Port=5432;Pooling=true;", DBTypeEnum.PgSql);
        }
    }

}
