using Microsoft.AspNetCore.Http;

namespace CPAcademy.Services.IServices
{
    public interface IMailService
    {
        Task SendEmailAsync(string mailTo, string subject, string body;
    }
}