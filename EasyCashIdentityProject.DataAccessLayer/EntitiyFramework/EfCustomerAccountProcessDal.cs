using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete.Context;
using EasyCashIdentityProject.DataAccessLayer.Repositories;
using EasyCashIdentityProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.EntitiyFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICostumerAccountProcessDal
    {
        private readonly Context _context;
        
        public EfCustomerAccountProcessDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<CustomerAccountProcess> GetRecentProcessesBySenderId(int id)
        {
            var userList = _context.CustomerAccountProcesses.Include(y => y.SenderCustomer).Where(x => x.SenderID == id || x.ReceiverID == id).ToList();
            return userList;
        }
    }
}
