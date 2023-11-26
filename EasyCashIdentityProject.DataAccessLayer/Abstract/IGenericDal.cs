using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCashIdentityProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class  // IGenericDal will accept a type (T). This type will be nothing but a class.
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);  
        T GetByID(int id);
        List<T> GetList();
        

        //this is a generic interface. All entities will implamante this so it'll be easier to have common CRUD operations at each one of these entities.

    }
}
