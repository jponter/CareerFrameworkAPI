using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CareerFrameworkAPI.Models
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Professions> Professions { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CareersFramework;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
//            }
//        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Professions>(entity =>
        //    {
        //        entity.HasKey(e => e.ProfessionId)
        //            .HasName("PK__Professi__3F309E1F2B53A07C");

        //        entity.Property(e => e.Name).IsUnicode(false);
        //    });

        //    modelBuilder.Entity<Skills>(entity =>
        //    {
        //        entity.HasKey(e => e.SkillId)
        //            .HasName("PK__Skills__3214EC0736C9F4A8");

        //        entity.Property(e => e.SkillLevel)
        //            .HasDefaultValueSql("((1))")
        //            .HasComment("Core = 1 , Senior = 2 , Prinicpal = 3");

        //        entity.Property(e => e.SkillText).IsUnicode(false);

        //        entity.HasOne(d => d.Profession)
        //            .WithMany(p => p.Skills)
        //            .HasForeignKey(d => d.ProfessionId)
        //            .OnDelete(DeleteBehavior.ClientSetNull)
        //            .HasConstraintName("ProfessionID");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
