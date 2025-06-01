using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Skill
    {
        public int SkillID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }
}
