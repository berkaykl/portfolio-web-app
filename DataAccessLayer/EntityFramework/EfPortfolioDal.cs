using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPortfolioDal : GenericRepository<Portfolio>, IPortfolioDal
    {
        public List<Portfolio>? GetLast5Projects()
        {
            using(var c = new Context())
            {
                var last5projects = c.Portfolios.OrderByDescending(x => x.Date).Take(5).ToList();
                return last5projects;
            }
        }
    }
}
