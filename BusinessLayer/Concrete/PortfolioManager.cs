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
    public class PortfolioManager : IPortfolioService
    {
        private readonly IPortfolioDal _portfolioDal;

        public PortfolioManager(IPortfolioDal portfolioDal)
        {
            _portfolioDal = portfolioDal;
        }

        public void TAdd(Portfolio t)
        {
            _portfolioDal.Insert(t);
        }

        public void TDelete(Portfolio t)
        {
            _portfolioDal.Delete(t);
        }

        public Portfolio? TGetById(int id)
        {
            return _portfolioDal.GetById(id);
        }

        public List<Portfolio>? TGetLast5Projects()
        {
            return _portfolioDal.GetLast5Projects();
        }

        public List<Portfolio> TGetList()
        {
            return _portfolioDal.GetList();
        }

        public List<Portfolio> TGetListByFilter(Expression<Func<Portfolio, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Portfolio t)
        {
            _portfolioDal.Update(t);
        }
    }
}
