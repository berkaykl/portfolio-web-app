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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void TAdd(About t)
        {
            _aboutDal.Insert(t);
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About? TGetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public List<About> TGetList()
        {
            return  _aboutDal.GetList();
        }

        public List<About> TGetListByFilter(Expression<Func<About, bool>> filter)
        {
            return _aboutDal.GetByFilter(filter);
        }

        public void TUpdate(About t)
        {
            _aboutDal.Update(t);
        }
    }
}
