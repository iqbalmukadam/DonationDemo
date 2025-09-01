using DonationDemo.Domain.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationDemo.Domain.Entities
{
    public class Donation
    {
        public Donation()
        {
            Date = DateTime.Today;
            Amount = 0.0M;
            PaymentMethodId = 0;
            PaymentMethodNotes = string.Empty;
            Notes = string.Empty;
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(Donation), nameof(ValidateDateNotFuture))]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0.")]
        [DataType(DataType.Currency)]
        public decimal Amount { get; set; }

        [Range(1, double.MaxValue, ErrorMessage = "Payment Method is required")]
        public int PaymentMethodId { get; set; }

        // Assume "Other" has PaymentMethodId = 5 (maybe a -1 Id would be better)
        // Needs to be stored as static data somewhere else
        [RequiredIfPaymentMethodIdIsOther(PaymentMethodId = 5, ErrorMessage = "Payment Method notes are required when 'Other' Payment Method is selected.")]
        public string? PaymentMethodNotes { get; set; } = string.Empty;

        public string? Notes { get; set; } = string.Empty;

        public static ValidationResult ValidateDateNotFuture(DateTime date)
        {
            if (date <= DateTime.Today)
            {
                return ValidationResult.Success!;
            }
            else
            {
                return new ValidationResult("Date cannot be in the future.");
            }
        }
    }



}
