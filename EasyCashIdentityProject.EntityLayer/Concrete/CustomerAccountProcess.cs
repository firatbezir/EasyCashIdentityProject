using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.EntityLayer.Concrete
{
    // will vbe defined for customer account transactions
    public class CustomerAccountProcess
    {
        public int CustomerAccountProcessID { get; set; }
        public string TransactionType { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? SenderId { get; set; }
        public int? ReceiverId { get; set; }


    }
}

/* 
    This table should have ID, Transactions, Amount, Date, Sender and Receiver properties.
    So it's need to be related with customer account to answer which customer account has this transactions or other props that are defined in this class.

    Here is the thing: as we must have two accounts to send and receive the money, this class must relate two AppUsers. Because of that, relation between these classes will be taken care of not here but later!! 11:40 pm - 11/24/2023

    DATE: 12-19-2023 : SENDERID and Receoverid were added to take care of the money transfer issue explained above.

 
 */
