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
        public DbSet<Admin> Admins { get; set; }
        public DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRating> BookRatings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderBookDetail> OrderBookDetails { get; set; }
        public DbSet<OrderPodcastDetail> OrderPodcastDetails { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Podcast> Podcasts { get; set; }
        public DbSet<PodcastRating> PodcastRatings { get; set; }
        public DbSet<Psychologist> Psychologists { get; set; }
        public DbSet<User> ApplicationUsers { get; set; }

    }
}
