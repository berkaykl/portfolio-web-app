using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Testimonial
    {
        [Key]
        public int TestimonialID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public string Company { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int WriterUserId { get; set; }
        public WriterUser? WriterUser { get; set; }
    }
}
