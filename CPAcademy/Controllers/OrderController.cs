using CPAcademy.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{

    public class OrderController : BaseAPIController
    {
        private readonly ITokenService _tokenService;
        private readonly IMailService _mailService;
        public OrderController(ITokenService tokenService, IMailService mailService)
        {
            _tokenService = tokenService;
            _mailService = mailService;
        }

    }
}
