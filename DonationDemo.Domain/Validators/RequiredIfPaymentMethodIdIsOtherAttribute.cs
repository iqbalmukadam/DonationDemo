using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationDemo.Domain.Validators
{
    public class RequiredIfPaymentMethodIdIsOtherAttribute : ValidationAttribute
    {
        public int PaymentMethodId { get; set; }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var instance = validationContext.ObjectInstance;
            var type = instance.GetType();

            var paymentMethodIdProperty = type.GetProperty("PaymentMethodId");

            if (paymentMethodIdProperty == null)
            {
                return new ValidationResult("PaymentMethodId property not found.");
            }

            var paymentMethodIdValue = paymentMethodIdProperty.GetValue(instance);

            if (paymentMethodIdValue is int paymentMethodId && paymentMethodId == PaymentMethodId)
            {
                // Now check if PaymentMethodNotes is not null or empty
                if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
                {
                    return new ValidationResult(ErrorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}
