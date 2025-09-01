using DonationDemo.Domain;
using DonationDemo.Domain.Entities;
using DonationDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationDemo.Application.Services
{
    public class DonationService(IDonationRepository donationRepository)
    {
        public Task<IEnumerable<Donation>> GetDonationsAsync() =>
            donationRepository.GetAllAsync();

        public Task<Donation?> GetDonationByIdAsync(int id) =>
            donationRepository.GetByIdAsync(id);

        public Task AddDonationAsync(Donation donation) =>
            donationRepository.AddAsync(donation);

        public Task UpdateDonationAsync(Donation donation) =>
            donationRepository.UpdateAsync(donation);

        public Task DeleteDonationAsync(int id) =>
            donationRepository.DeleteAsync(id);

        public Task<IEnumerable<PaymentMethod>> GetAllPaymentMethodAsync() =>
            donationRepository.GetAllPaymentMethodAsync();
    }

}
