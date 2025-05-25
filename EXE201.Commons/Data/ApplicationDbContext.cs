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
        //public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; }
        public virtual DbSet<Appointment> Appointments { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        //public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Podcast> Podcasts { get; set; }
        public virtual DbSet<PodcastRating> PodcastRatings { get; set; }
        public virtual DbSet<Psychologist> Psychologists { get; set; }
        public virtual DbSet<User> ApplicationUsers { get; set; }
        public virtual DbSet<UserTestResult> UserTestResults { get; set; }
        public virtual DbSet<PsychTest> PsychTests { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
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

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Client)
                .WithMany(u => u.ClientAppointments)
                .HasForeignKey(a => a.Client_ID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Psychologist)
                .WithMany(u => u.PsychologistAppointments)
                .HasForeignKey(a => a.Psychologist_ID)
                .OnDelete(DeleteBehavior.Restrict);
            /*
            modelBuilder.Entity<Psychologist>().HasData(
                new Psychologist
                {
                    UserName = "Lê Văn Thắng",
                    Email = "Thang123@gamil.com",
                    Name = "Lê Văn Thắng",
                    Phone = "123456789",
                    Address = "HCM, Việt Nam",
                    Degree = "~image/Degree/cunhantamly.jpg",
                    Description = "Nhà tâm lý học có nhiều năm kinh nghiệm trong ngành.",
                    Experience = "10 years",
                    Price = 1000000,
                    ProfilePictureUrl = "~image/Doctor/Van_Thang.png"
                },
                new Psychologist
                {
                    UserName = "Dung Lê",
                    Email = "Dungle123@gamil.com",
                    Name = "Dung Lê",
                    Phone = "0987654321",
                    Address = "Hà Nội, Việt Nam",
                    Degree = "~image/Degree/cunhantamly.jpg",
                    Description = "Chuyên gia tư vấn tâm lý hôn nhân và gia đình.",
                    Experience = "7 years",
                    Price = 850000,
                    ProfilePictureUrl = "~image/Doctor/Dung_Le.png"
                },

                new Psychologist
                {
                    UserName = "Hà Lê",
                    Email = "HaLe123@gamil.com",
                    Name = "Hà Lê",
                    Phone = "0912345678",
                    Address = "Đà Nẵng, Việt Nam",
                    Degree = "~image/Degree/cunhantamly.jpg",
                    Description = "Tiến sĩ tâm lý học, chuyên về điều trị trầm cảm và rối loạn lo âu.",
                    Experience = "12 years",
                    Price = 1200000,
                    ProfilePictureUrl = "~image/Doctor/Ha_Le.png"
                },

                new Psychologist
                {
                    UserName = "Kim Nguyễn",
                    Email = "KimNguyen123@gamil.com",
                    Name = "Kim Nguyễn",
                    Phone = "0933555777",
                    Address = "Cần Thơ, Việt Nam",
                    Degree = "~image/Degree/cunhantamly.jpg",
                    Description = "Tư vấn tâm lý cho trẻ em và thanh thiếu niên.",
                    Experience = "6 years",
                    Price = 750000,
                    ProfilePictureUrl = "~image/Doctor/Kim_Nguan.png"
                }
                
            );  */
        }

    }
}
