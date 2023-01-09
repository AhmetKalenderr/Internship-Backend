using Appointment.Entities;
using InternShipApi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace InternShipApi.Models
{
    public class InternDatabaseContext : DbContext
    {
        public InternDatabaseContext(DbContextOptions<InternDatabaseContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<MailVerify> MailVerifies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<School> Schools { get; set; }

        public DbSet<UserType> UserTypes { get; set; }

        //public DbSet<InternshipPosting> InternshipPostings {get;set;}

        public DbSet<InternshipPosition> InternshipPositions { get; set; }
        public DbSet<ApplicationIntern> ApplicationIntern { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<InternshipPosting>().HasOne(i => i.company).WithMany().HasForeignKey(c => c.companyId);
            //modelBuilder.Entity<InternshipPosting>().HasOne(i => i.position).WithMany().HasForeignKey(c => c.positionId);
            //modelBuilder.Entity<InternshipPosting>().HasOne(i => i.city).WithMany().HasForeignKey(c => c.CityId);
            modelBuilder.Entity<ApplicationIntern>().HasOne(i => i.user).WithMany().HasForeignKey(c => c.UserId);
             //modelBuilder.Entity<ApplicationIntern>().HasOne(i => i.post).WithMany().HasForeignKey(c => c.PostId);


            modelBuilder.Entity<User>().HasOne(i => i.city).WithMany().HasForeignKey(c => c.cityId);
            modelBuilder.Entity<MailVerify>().HasOne(i => i.user).WithMany().HasForeignKey(c => c.userId);
            modelBuilder.Entity<User>().HasOne(i => i.userType).WithMany().HasForeignKey(c => c.userTypeId);
            modelBuilder.Entity<Company>().HasOne(i => i.city).WithMany().HasForeignKey(c => c.CityId);


        }


     
    }
}
