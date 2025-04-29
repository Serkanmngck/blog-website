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
    public class NewsLetterManager : INewsLetterService
    {
        INewsLetterDal _newLatterDal;

        public NewsLetterManager(INewsLetterDal newLatterDal)
        {
            _newLatterDal = newLatterDal;
        }

        public void AddNewsLetter(NewsLatter newsLatter)
        {
            _newLatterDal.Insert(newsLatter);
        }
    }
}
