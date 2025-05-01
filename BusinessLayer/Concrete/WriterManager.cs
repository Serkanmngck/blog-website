using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writaldal;
        public Writer GetWriterByMail(string mail)
        {
            return _writaldal.GetListAll().FirstOrDefault(x => x.WriterMail == mail);
        }

        public WriterManager (IWriterDal writerDal)
        {
            _writaldal = writerDal;
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writaldal.GetListAll(x=>x.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writaldal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
            return _writaldal.GetByID(id);
        }

        public void TUpdate(Writer t)
        {
            _writaldal.Update(t);
        }

    }
}
