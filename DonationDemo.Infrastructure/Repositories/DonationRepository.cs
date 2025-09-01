using DonationDemo.Domain.Entities;
using DonationDemo.Domain.Interfaces;
using DonationDemo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationDemo.Infrastructure.Repositories
{
    public class DonationRepository : IDonationRepository
    {
        private readonly DonationDbContext _context;

        public DonationRepository(DonationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Donation>> GetAllAsync() =>
            await _context.Donations.ToListAsync();

        public async Task<Donation?> GetByIdAsync(int id) =>
            await _context.Donations.FindAsync(id);

        public async Task AddAsync(Donation donation)
        {
            await _context.Donations.AddAsync(donation);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Donation donation)
        {
            _context.Donations.Update(donation);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var donation = await _context.Donations.FindAsync(id);
            if (donation != null)
            {
                _context.Donations.Remove(donation);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodAsync() =>
            await _context.PaymentMethods.ToListAsync();

   }

}
