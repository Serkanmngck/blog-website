using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AdminManager : IAdminService
    {

        IAdminDal adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            this.adminDal = adminDal;
        }

        public void Delete(Admin item)
        {
            throw new NotImplementedException();
        }

        public Admin GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Admin> GetListAll(Expression<Func<Admin, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(Admin item)
        {
            throw new NotImplementedException();
        }

        public void Update(Admin item)
        {
            throw new NotImplementedException();
        }
    }
}
