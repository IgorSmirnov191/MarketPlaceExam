using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Marketplace.MVC.ViewModels.Payments
{
    public class MyPaymentsViewModel
    {
        public int Id { get; set; }

        public DateTime IssuedOn { get; set; }

        public int Quantity { get; set; }

        public decimal PaymentTotal { get; set; }
    }
}
