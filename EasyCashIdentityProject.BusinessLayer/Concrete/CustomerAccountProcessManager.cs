using EasyCashIdentityProject.BusinessLayer.Abstract;
using EasyCashIdentityProject.DataAccessLayer.Abstract;
using EasyCashIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.BusinessLayer.Concrete
{
    public class CustomerAccountProcessManager : ICustomerAccountProcessService
    {
        private readonly ICostumerAccountProcessDal _costumerAccountProcessDal;

        public CustomerAccountProcessManager(ICostumerAccountProcessDal costumerAccountProcessDal)
        {
            _costumerAccountProcessDal = costumerAccountProcessDal;
        }

        public void TDelete(CustomerAccountProcess entity)
        {
            _costumerAccountProcessDal.Delete(entity);
        }

        public CustomerAccountProcess TGetByID(int id)
        {
            return _costumerAccountProcessDal.GetByID(id);
        }

        public List<CustomerAccountProcess> TGetList()
        {
            return _costumerAccountProcessDal.GetList();
        }

        public void TInsert(CustomerAccountProcess entity)
        {
            _costumerAccountProcessDal.Insert(entity);
        }

        public void TUpdate(CustomerAccountProcess entity)
        {
            _costumerAccountProcessDal.Update(entity);
        }
    }
}
