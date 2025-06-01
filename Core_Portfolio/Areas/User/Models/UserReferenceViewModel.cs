using EntityLayer.Concrete;

namespace Core_Portfolio.Areas.User.Models
{
    public class UserReferenceViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;
        public int WriterUserId { get; set; }
        public string ImageUrl { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;

        public List<Testimonial> MyTestimonials { get; set; } = new List<Testimonial>();
    }
}

