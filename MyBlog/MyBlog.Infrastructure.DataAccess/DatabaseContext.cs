using System.Data.Entity;
using MyBlog.Core.Model;

namespace MyBlog.Infrastructure.DataAccess
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("MyBlog")
        {
            // Configuration.AutoDetectChangesEnabled = false;
            //Database.SetInitializer<DatabaseContext>(null);
            //Database.SetInitializer<DatabaseContext>(new MigrateDatabaseToLatestVersion<DatabaseContext, Migrations.Configuration>());
            // Database.SetInitializer<DatabaseContext>(new CreateDatabaseIfNotExists<DatabaseContext>());
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }






        public virtual void Commit()
        {

            base.SaveChanges();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
            .HasMany(c => c.Tags).WithMany(i => i.Posts)
            .Map(t => t.MapLeftKey("PostId")
                .MapRightKey("TagId")
                .ToTable("PostTag"));

            //modelBuilder.Entity<Size>()
            //.HasMany(c => c.LeatherCarpets).WithMany(i => i.Sizes)
            //.Map(t => t.MapLeftKey("SizeId")
            //    .MapRightKey("LeatherCarpetId")
            //    .ToTable("SizeLeatherCarpet"));
            //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // modelBuilder.Entity<Carpet>().HasOptional(d=>d.Grade);
        }



    }
}
