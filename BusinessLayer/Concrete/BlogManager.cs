﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal= blogDal;
        }


        public List<Blog> GetBlogListWithCategorys()
        {
            return _blogDal.GetListWithCategory();
        }
        public List<Blog> GetListWithCategoryByWirterBM(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }


        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x => x.BlogId == id);
        }
        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().Take(3).ToList();
        }
        public Blog TGetById(int id)
        {
            return _blogDal.GetByID(id);
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x=>x.WriterID == id);
        }

        public void TAdd(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
           _blogDal.Update(t);
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }
    }
}
