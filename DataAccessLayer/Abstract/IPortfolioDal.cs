﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IPortfolioDal : IGenericDal<Portfolio>
    {
        public List<Portfolio>? GetLast5Projects();
    }
}
