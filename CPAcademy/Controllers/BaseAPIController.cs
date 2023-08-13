using AutoMapper;
using CPAcademy.Models;
using CPAcademy.Services.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;
        protected readonly UserManager<User> _userManager;
        protected readonly ITokenService _tokenService;


        public BaseAPIController(IUnitOfWork unitOfWork = null,IMapper mapper= null, UserManager<User> userManager = null, ITokenService tokenService=null)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
            _tokenService = tokenService;            
        }
    }
}
