using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MTI.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(255)]
        public string UsernameViwer { get; set; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Section> sections  { get; set; }
        public DbSet<specialization> specializations { get; set; }
        public DbSet<Students> students { get; set; }
        public DbSet<daily_attendance> daily_Attendances { get; set; }
        public DbSet<AbsantDetails> absantDetails { get; set; }
        public DbSet<Shooting> shootings { get; set; }
        public DbSet<punishment> punishments { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Situations> situations { get; set; }
        public DbSet<Batch> batch { get; set; }
        public DbSet<cities> Cities { get; set; }
        public DbSet<post> posts { get; set; }
        public DbSet<Relative> relatives { get; set; }
        public DbSet<bodydetails> bodydetails { get; set; }
        public DbSet<News> news { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Qualifications> qualifications { get; set; }
        public DbSet<Attachments> attachment { get; set; }
        public DbSet<Attendance> attendence { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}