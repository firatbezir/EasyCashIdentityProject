using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EasyCashIdentityProject.DataAccessLayer.Concrete.Context
{
    // Identity context will acceppt the AppUser class as a user, AppRole as a role and int as key value. 
    public class Context : IdentityDbContext<AppUser, AppRole, int>
    {

        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<CustomerAccountProcess> CustomerAccountProcesses { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.SenderCustomer)
                .WithMany(y => y.ReceiverCustomers)
                .HasForeignKey(z => z.SenderID)
                .OnDelete(DeleteBehavior.ClientNoAction);

            builder.Entity<CustomerAccountProcess>()
                .HasOne(x => x.ReceiverCustomer)
                .WithMany(y => y.SenderCustomers)
                .HasForeignKey(z => z.ReceiverID)
                .OnDelete(DeleteBehavior.ClientNoAction);

            base.OnModelCreating(builder);
        }
    }
}
