namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebClientDbContext : DbContext
    {
        public WebClientDbContext()
            : base("name=WebClientDbContext")
        {
        }

        public virtual DbSet<Administration> Administrations { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerSheet> AnswerSheets { get; set; }
        public virtual DbSet<CaThi> CaThis { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<DeChuan> DeChuans { get; set; }
        public virtual DbSet<DeChuanQuestion> DeChuanQuestions { get; set; }
        public virtual DbSet<DeTron> DeTrons { get; set; }
        public virtual DbSet<DeTronQuestion> DeTronQuestions { get; set; }
        public virtual DbSet<Error> Errors { get; set; }
        public virtual DbSet<FeedBack> FeedBacks { get; set; }
        public virtual DbSet<Footer> Footers { get; set; }
        public virtual DbSet<KHOATHI> KHOATHIs { get; set; }
        public virtual DbSet<LogIn> LogIns { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<MenuGroup> MenuGroups { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }
        public virtual DbSet<PHONG> PHONGs { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTag> PostTags { get; set; }
        public virtual DbSet<QClass> QClasses { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionTemp> QuestionTemps { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SupportOnline> SupportOnlines { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<SystemConfig> SystemConfigs { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VisitorStaticti> VisitorStatictis { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administration>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Administration>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<Administration>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Administration>()
                .Property(e => e.Zalo)
                .IsUnicode(false);

            modelBuilder.Entity<DeChuan>()
                .HasMany(e => e.CaThis)
                .WithOptional(e => e.DeChuan)
                .HasForeignKey(e => e.IDDeChuan);

            modelBuilder.Entity<DeChuan>()
                .HasMany(e => e.DeChuanQuestions)
                .WithRequired(e => e.DeChuan)
                .HasForeignKey(e => e.MaDe)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeChuan>()
                .HasMany(e => e.DeTrons)
                .WithRequired(e => e.DeChuan)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DeTron>()
                .Property(e => e.MaDeTron)
                .IsUnicode(false);

            modelBuilder.Entity<DeTron>()
                .HasMany(e => e.DeTronQuestions)
                .WithRequired(e => e.DeTron)
                .HasForeignKey(e => e.IDDeTron)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FeedBack>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KHOATHI>()
                .Property(e => e.MaKhoaThi)
                .IsUnicode(false);

            modelBuilder.Entity<MenuGroup>()
                .HasMany(e => e.Menus)
                .WithRequired(e => e.MenuGroup)
                .HasForeignKey(e => e.IDGroup)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Page>()
                .Property(e => e.Alias)
                .IsUnicode(false);

            modelBuilder.Entity<PhanQuyen>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.PhanQuyen)
                .HasForeignKey(e => e.IDPhanQuyen)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PHONG>()
                .Property(e => e.MaPhong)
                .IsUnicode(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.DeChuanQuestions)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.QuesID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.DeTronQuestions)
                .WithRequired(e => e.Question)
                .HasForeignKey(e => e.QuestionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Question>()
                .HasMany(e => e.DeTronQuestions1)
                .WithRequired(e => e.Question1)
                .HasForeignKey(e => e.QuestionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Zalo)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Student>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<SystemConfig>()
                .Property(e => e.Code)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Mobile)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Zalo)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
