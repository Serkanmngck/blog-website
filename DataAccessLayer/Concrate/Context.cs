using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrate
{
    public class Context: IdentityDbContext<AppUser>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-29APFHS\\SQLEXPRESS; database=CoreBlogDb; integrated security = true;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Gönderen ilişkisi (WriterSender)
            modelBuilder.Entity<Message2>()
                .HasOne(m => m.SenderUser)
                .WithMany(w => w.WriterSender)
                .HasForeignKey(m => m.Sender)
                .OnDelete(DeleteBehavior.ClientSetNull); 

            // Alıcı ilişkisi (WriterReciver)
            modelBuilder.Entity<Message2>()
                .HasOne(m => m.ReciverUser)
                .WithMany(w => w.WriterReciver)
                .HasForeignKey(m => m.Receiver)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLatter> NewsLatters { get; set; }
        public DbSet<BlogRayting> BlogRayting { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Message2> Message2s { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
