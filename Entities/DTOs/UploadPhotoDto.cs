using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UploadPhotoDto
    {
        public int carId { get; set; }
        public string Url { get; set; }
        public IFormFile file { get; set; }
        public string Description { get; set; }
        public bool IsMain { get; set; }
        public string PublicId { get; set; }
    }
}
