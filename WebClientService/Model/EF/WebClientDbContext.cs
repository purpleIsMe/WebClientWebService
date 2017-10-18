using Model.EF;
using System.Data.Entity;

namespace WebClientService.Model.EF
{
    public class WebClientDbContext : DbContext
    {
        public WebClientDbContext() : base("WebClientConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Administration> Administrations { set; get; }
        public DbSet<Answer> Answers { set; get; }
        public DbSet<ContactDetail> ContactDetails { set; get; }
        public DbSet<AnswerSheet> AnswerSheets { set; get; }
        public DbSet<DECHUAN> DECHUANs { set; get; }
        public DbSet<DECHUAN_QUESTION> DECHUAN_QUESTIONs { set; get; }
        public DbSet<DETRON> DETRONs { set; get; }
        public DbSet<DETRON_QUESTION> DETRON_QUESTIONs     { set; get; }
        public DbSet<FOOTER> FOOTERs { set; get; }
        public DbSet<HoanVi> HoanVies { set; get; }
        public DbSet<LOG_IN> LOG_INs { set; get; }
        public DbSet<MENU> MENUs { set; get; }
        public DbSet<MENUGROUP> MENUGROUPs { set; get; }
        public DbSet<PAGE> PAGEs { set; get; }
        public DbSet<PHANQUYEN> PHANQUYENs { set; get; }
        public DbSet<POST> POSTs { set; get; }
        public DbSet<POSTTAG> POSTTAGs { set; get; }
        public DbSet<QClass> QClasses { set; get; }
        public DbSet<Question> Questions { set; get; }
        public DbSet<SLIDE> SLIDEs { set; get; }
        public DbSet<Subject> Subjects { set; get; }
        public DbSet<SUPPORT_ONLINE> SUPPORT_ONLINEs { set; get; }
        public DbSet<SYSTEMCONFIG> SYSTEMCONFIGs { set; get; }
        public DbSet<TAG> TAGs { set; get; }
        public DbSet<Users> Users { set; get; }
        public DbSet<VISITOR_STATISTIC> VISITOR_STATISTICs { set; get; }
        public DbSet<Error> Errors { set; get; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}
