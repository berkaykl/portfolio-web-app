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
    public class UserMessageManager : IUserMessageService
    {
        private readonly IUserMessageDal _userMessageDal;

        public UserMessageManager(IUserMessageDal userMessageDal)
        {
            _userMessageDal = userMessageDal;
        }

        public void TAdd(UserMessage t)
        {
            _userMessageDal.Insert(t);
        }

        public void TDelete(UserMessage t)
        {
            _userMessageDal.Delete(t);
        }

        public UserMessage? TGetById(int id)
        {
            return _userMessageDal.GetById(id);
        }

        public List<UserMessage> TGetList()
        {
            return _userMessageDal.GetList();
        }

        public List<UserMessage> TGetListByFilter(Expression<Func<UserMessage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<UserMessage>? TGetUserMessagesWithUser()
        {
            return _userMessageDal.GetUserMessagesWithUser();
        }

        public void TUpdate(UserMessage t)
        {
            _userMessageDal.Update(t);
        }
    }
}
