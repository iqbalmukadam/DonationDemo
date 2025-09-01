using DonationDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationDemo.Domain.Interfaces
{
    public interface IDonationRepository
    {
        Task<IEnumerable<Donation>> GetAllAsync();
        Task<Donation?> GetByIdAsync(int id);
        Task AddAsync(Donation donation);
        Task UpdateAsync(Donation donation);
        Task DeleteAsync(int id);

        Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodAsync();
    }
}
