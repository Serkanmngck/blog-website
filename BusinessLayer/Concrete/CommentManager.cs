using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;
        private EfCategoryRepository efCategoryRepository;

        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public CommentManager(EfCategoryRepository efCategoryRepository)
        {
            this.efCategoryRepository = efCategoryRepository;
        }

        public void CommentAdd(Comment Comment)
        {
            _commentdal.Insert(Comment);
        }

        public List<Comment> GetList(int id)
        {
            return _commentdal.GetListAll(x => x.BlogID == id);
        }
    }
}
