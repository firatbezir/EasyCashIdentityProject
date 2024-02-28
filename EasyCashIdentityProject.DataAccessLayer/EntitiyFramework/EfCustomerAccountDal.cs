using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Concrete.Context;
using EasyCashIdentityProject.DataAccessLayer.Repositories;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.EntitiyFramework
{
    public class EfCustomerAccountDal : GenericRepository<CustomerAccount>, ICustomerAccountDal
    {
        private readonly Context _context;
        public EfCustomerAccountDal(Context context) : base(context)
        {
            _context = context;
        }

        public List<CustomerAccount> GetCustomerAccountsList(int id)
        {
            var customerAccountsList = _context.CustomerAccounts.Where(x => x.AppUserID == id).ToList();
            return customerAccountsList;
        }
    }
}
