using EXE201.Commons.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXE201.Commons.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookRating> BookRatings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderBookDetail> OrderBookDetails { get; set; }
        public virtual DbSet<OrderPodcastDetail> OrderPodcastDetails { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<Podcast> Podcasts { get; set; }
        public virtual DbSet<PodcastRating> PodcastRatings { get; set; }
        public virtual DbSet<Psychologist> Psychologists { get; set; }
        public virtual DbSet<User> ApplicationUsers { get; set; }
        public virtual DbSet<UserTestResult> UserTestResults { get; set; }
        public virtual DbSet<PsychTest> PsychTests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // PodcastRating -> User (cascade delete)
            modelBuilder.Entity<PodcastRating>()
                .HasOne(pr => pr.User)
                .WithMany(u => u.PodcastRatings)
                .HasForeignKey(pr => pr.UserID)
                .OnDelete(DeleteBehavior.Cascade);

            // PodcastRating -> Podcast (no cascade delete)
            modelBuilder.Entity<PodcastRating>()
                .HasOne(pr => pr.Podcast)
                .WithMany(p => p.PodcastRatings)
                .HasForeignKey(pr => pr.PodcastID)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
