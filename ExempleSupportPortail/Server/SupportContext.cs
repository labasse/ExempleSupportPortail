using ExempleSupportPortail.Shared;
using Microsoft.EntityFrameworkCore;

namespace ExempleSupportPortail.Server
{
    public class SupportContext : DbContext
    {
        public SupportContext(DbContextOptions<SupportContext> options) : base(options)
        {
        }

        public DbSet<Area> Areas { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<User> Users { get; set;  }
        public DbSet<Issue> Issues { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>().ToTable("Area").HasData(
                new Area() { IdArea = 1, Title = "IT" },
                new Area() { IdArea = 2, Title = "Facilities" },
                new Area() { IdArea = 3, Title = "HR" }
            );
            modelBuilder.Entity<Status>().ToTable("Status").HasData(
                new Status() { IdStatus = 1, Title = "In progress" },
                new Status() { IdStatus = 2, Title = "On hold" },
                new Status() { IdStatus = 3, Title = "Closed" }
            );
            modelBuilder.Entity<User>().ToTable("User").HasData(
                new User() { IdUser = 1, Name = "John Doe", Login = "jdoe" }
            );
            modelBuilder.Entity<Issue>().ToTable("Issue").HasData(
                new Issue()
                {
                    IdIssue = 1, UserId = 1, AreaId = 1, StatusId = 2,
                    Subject = "My computer is broken",
                    Description = "I can't turn it on",
                    Comment = "Did you check the power cable?"
                },
                new Issue()
                {
                    IdIssue = 2, UserId = 1, AreaId = 2, StatusId = 1,
                    Subject = "The door is broken",
                    Description = "I can't open it"
                },
                new Issue()
                {
                    IdIssue = 3, UserId = 1, AreaId = 3, StatusId = 3,
                    Subject = "Leave request",
                    Description = "I need to leave for 2 weeks",
                    Comment = "I approve this leave request"
                }
            );
            modelBuilder.Entity<Issue>().HasOne(issue => issue.Area  ).WithMany().HasForeignKey(issue => issue.AreaId);
            modelBuilder.Entity<Issue>().HasOne(issue => issue.Status).WithMany().HasForeignKey(issue => issue.StatusId);
            modelBuilder.Entity<Issue>()
                .HasOne(issue => issue.User  )
                .WithMany(user => user.Requests)
                .HasForeignKey(issue => issue.UserId);
        }
    }
}
