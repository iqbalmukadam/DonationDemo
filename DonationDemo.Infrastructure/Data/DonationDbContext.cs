using DonationDemo.Domain;
using DonationDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationDemo.Infrastructure.Data
{
    public class DonationDbContext(DbContextOptions<DonationDbContext> options) : DbContext(options)
    {
        public DbSet<Donation> Donations { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PaymentMethod>()
                .HasData(new PaymentMethod { Id = 1, Method = "Card" },
                              new PaymentMethod { Id = 2, Method = "Cash" },
                              new PaymentMethod { Id = 3, Method = "Cheque" },
                              new PaymentMethod { Id = 4, Method = "Online" },
                              new PaymentMethod { Id = 5, Method = "Other" }
                );

            modelBuilder.Entity<Donation>()
                .HasData(new Donation { Id = 1, Date = new DateTime(2021, 1, 1), Amount = 111.00M, PaymentMethodId = 1, PaymentMethodNotes = "", Notes = "Nice to give" },
                              new Donation { Id = 2, Date = new DateTime(2022, 2, 2), Amount = 222.00M, PaymentMethodId = 5, PaymentMethodNotes = "Bitcoin", Notes = "I like to give" },
                              new Donation { Id = 3, Date = new DateTime(2023, 3, 3), Amount = 333.00M, PaymentMethodId = 3, PaymentMethodNotes = "", Notes = "Thinking of Others" },
                              new Donation { Id = 4, Date = new DateTime(2024, 4, 4), Amount = 444.00M, PaymentMethodId = 4, PaymentMethodNotes = "", Notes = "" },
                              new Donation { Id = 5, Date = new DateTime(2025, 5, 5), Amount = 555.00M, PaymentMethodId = 5, PaymentMethodNotes = "Crypto", Notes = "" }
                );
        }
    }
}
