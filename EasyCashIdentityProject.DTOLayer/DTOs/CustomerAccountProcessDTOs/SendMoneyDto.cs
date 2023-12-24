using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DTOLayer.DTOs.CustomerAccountProcessDTOs
{
    public class SendMoneyDto
    {        
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
    }
}
