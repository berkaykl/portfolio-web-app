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
    public class ToDoListManager : IToDoListService
    {
        private readonly IToDoListDal _toDoListDal;

        public ToDoListManager(IToDoListDal toDoListDal)
        {
            _toDoListDal = toDoListDal;
        }

        public void TAdd(ToDoList t)
        {
            _toDoListDal.Insert(t);
        }

        public void TDelete(ToDoList t)
        {
            _toDoListDal.Delete(t);
        }

        public ToDoList? TGetById(int id)
        {
            return _toDoListDal.GetById(id);
        }

        public List<ToDoList> TGetList()
        {
            return _toDoListDal.GetList();
        }

        public List<ToDoList> TGetListByFilter(Expression<Func<ToDoList, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(ToDoList t)
        {
            _toDoListDal.Update(t);
        }
    }
}
