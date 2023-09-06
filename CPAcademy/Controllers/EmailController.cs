using CPAcademy.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    public class EmailController : BaseAPIController
    {
        private readonly IMailService _mailService;

        public EmailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMail([FromForm] EmailRequestDto dto)  // because we have attachments so we need be fromForm
        {
            await _mailService.SendEmailAsync(dto.ToEmail, dto.Subject, dto.Body);
            return Ok();
        }

        [HttpPost("subscribe")]
        public async Task<IActionResult> SendWelcomeEmail([FromBody] SubscribeDto subscribeDto)
        {
            var filepath = $"{Directory.GetCurrentDirectory()}\\Template\\index.html";
            var str = new StreamReader(filepath);
            var mailText = str.ReadToEnd();
            str.Close();

            mailText = mailText.Replace("[Our Services]", subscribeDto.UserName);
            await _mailService.SendEmailAsync(subscribeDto.Email, "Welcome to our Website", mailText);
            return Ok();
        }
    }
}