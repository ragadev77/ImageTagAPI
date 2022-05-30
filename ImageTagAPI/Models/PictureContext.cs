using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Npgsql.EntityFrameworkCore;

namespace ImageTagApi.Models
{
    public class PictureContext : DbContext
    {
        public PictureContext(DbContextOptions<PictureContext> options) : base(options)
        {
            // Database.EnsureCreated();
        }        

        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PictureTag> PictureTags { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Picture>()
                .HasKey(d=>d.PictureId);

            modelBuilder.Entity<Tag>()
                .HasKey(d=>d.TagId);

            modelBuilder.Entity<PictureTag>()
                .HasKey(pt => new { pt.PictureId, pt.TagId });  

            // modelBuilder.Entity<PictureTag>()
            //     .HasOne(pt => pt.Picture)
            //     .WithMany(p => p.PictureTags)
            //     .HasForeignKey(pt => pt.PictureId);  
            // modelBuilder.Entity<PictureTag>()
            //     .HasOne(pt => pt.Tag)
            //     .WithMany(t => t.PictureTags)
            //     .HasForeignKey(pt => pt.TagId);

            // modelBuilder.Entity<Picture>()
            //     .HasMany(t => t.Tags)
            //     .WithOne(e => e.Picture);


            if(this.Database.IsSqlServer())
            {
                modelBuilder.Entity<Picture>().Property(p=>p.TimeStampUtc)
                    .HasDefaultValueSql("getutcdate()")
                    .ValueGeneratedOnAdd()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
            }
            else if(this.Database.IsNpgsql())
            {
                modelBuilder.Entity<Picture>().Property(p=>p.TimeStampUtc)
                    .HasDefaultValueSql("now()")
                    .ValueGeneratedOnAdd()
                    .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Throw);
            }
        }
    }
}