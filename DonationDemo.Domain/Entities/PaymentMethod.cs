using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DonationDemo.Domain.Entities
{
    public class PaymentMethod
    {
        public int Id { get; set; }
        public required string Method { get; set; }
    }
}
