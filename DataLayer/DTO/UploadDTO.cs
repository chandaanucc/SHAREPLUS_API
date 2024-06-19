using Microsoft.AspNetCore.Http;

namespace Shareplus.DataLayer.DTOs
{
    public class UploadDTO
    {
        public int Id { get; set; }
        public string ? FileName { get; set; }
        //public string ? ContentType { get; set; }
        public IFormFile ? File { get; set; }
    }
}
