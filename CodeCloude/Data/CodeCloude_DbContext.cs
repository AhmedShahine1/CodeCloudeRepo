using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using CodeCloude.Models;
using CodeCloude.Data.Entities;
using CodeCloude.Extend;

namespace CodeCloude.Data
{
    public class CodeCloude_DbContext:IdentityDbContext<ApplicationUser>
    {
        public CodeCloude_DbContext(DbContextOptions<CodeCloude_DbContext> opts) : base(opts) { }


        public DbSet<Categories> Categories { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<privacypolicy> privacypolicy { get; set; }
        public DbSet<Terms_Conditions> Terms_Conditions { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<User_Faviourites> User_Faviourites { get; set; }
        public DbSet<Addition_Terms> Addition_Terms { get; set; }
        public DbSet<ContcatUs> ContcatUs { get; set; }
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<UserSubscription> UserSubscription { get; set; }
        public DbSet<SubscripeRequests> SubscripeRequests { get; set; }

        public DbSet<BankDetails> BankDetails { get; set; }


    }
}
