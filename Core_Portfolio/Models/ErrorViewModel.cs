//namespace Core_Portfolio.Models
//{
//    public class ErrorViewModel
//    {
//        public string? RequestId { get; set; }

//        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
//    }
//}

namespace Core_Portfolio.Models
{
    public class ErrorViewModel
    {
        public int StatusCode { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
