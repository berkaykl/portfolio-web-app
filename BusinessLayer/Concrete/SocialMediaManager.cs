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
    public class SocialMediaManager:ISocialMediaService
    {
        private readonly ISocialMediaDal _socialMediaDal;

        public SocialMediaManager(ISocialMediaDal socialMediaDal)
        {
            _socialMediaDal = socialMediaDal;
        }

        public void TAdd(SocialMedia t)
        {
            _socialMediaDal.Insert(t);
        }

        public void TDelete(SocialMedia t)
        {
            _socialMediaDal.Delete(t);
        }

        public SocialMedia? TGetById(int id)
        {
            return _socialMediaDal.GetById(id);
        }

        public List<SocialMedia> TGetList()
        {
            return _socialMediaDal.GetList();
        }

        public List<SocialMedia> TGetListByFilter(Expression<Func<SocialMedia, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(SocialMedia t)
        {
            _socialMediaDal.Update(t);
        }
    }
}
