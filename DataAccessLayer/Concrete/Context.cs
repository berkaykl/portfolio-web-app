using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context: IdentityDbContext<WriterUser, IdentityRole<int>, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=YOURDATABASESTRING;database=CorePortfolioDb;integrated security=true;");
        }

        public DbSet<About> Abouts { get; set; } = null!;
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Experience> Experiences { get; set; } = null!;
        public DbSet<Feature> Features { get; set; } = null!;
        public DbSet<Message> Messages { get; set; } = null!;
        public DbSet<Portfolio> Portfolios { get; set; } = null!;
        public DbSet<Service> Services { get; set; } = null!;
        public DbSet<Skill> Skills { get; set; } = null!;
        public DbSet<SocialMedia> SocialMedias { get; set; } = null!;
        public DbSet<Testimonial> Testimonials { get; set; } = null!;
        //public DbSet<User> Users { get; set; } = null!;
        public DbSet<UserMessage> UserMessages { get; set; } = null!;
        public DbSet<ToDoList> ToDoLists { get; set; } = null!;
        public DbSet<Testing> Testings { get; set; } = null!;
    }
}
