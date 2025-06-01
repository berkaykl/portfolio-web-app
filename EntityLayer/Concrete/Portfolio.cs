using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Portfolio
    {
        public int PortfolioID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public string ProjectUrl { get; set; } = string.Empty;
        public string ImageUrl2 { get; set; } = string.Empty;
        public string ProjectValue { get; set; } = string.Empty;
        public string Date { get; set; } = string.Empty;
        public string IconUrl { get; set; } = string.Empty;

    }
}
