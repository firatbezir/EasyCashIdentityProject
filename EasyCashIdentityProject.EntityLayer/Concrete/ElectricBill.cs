using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    public class ElectricBill
    {
        public int ElectricBillId { get; set; }
        public string ContractNumber { get; set; }
        public string CustomerName { get; set; }
        public string BillingPeriod { get; set; }
        public  DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }
    }
}
