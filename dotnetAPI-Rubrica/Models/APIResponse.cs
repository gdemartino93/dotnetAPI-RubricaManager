using System.Net;

namespace dotnetAPI_Rubrica.Models
{
    public class APIResponse
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessage { get; set; }
        public object Result { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }

        public APIResponse()
        {
            ErrorMessage = new List<string>();
        }

    }
}
