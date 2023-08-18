using Microsoft.AspNetCore.Http;

namespace CPAcademy.Models.DTOs
{
    public class EmailRequestDto
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
        public IList<IFormFile> Attachments { get; set; }
    }
}
