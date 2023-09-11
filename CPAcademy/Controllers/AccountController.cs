using CPAcademy.Models;
using Newtonsoft.Json.Linq;
using Stripe;

namespace CPAcademy.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly UserManager<User> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IMailService _mailService;

        public AccountController(UserManager<User> userManager, ITokenService tokenService, IMailService mailService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _mailService = mailService;
        }

        [HttpGet()]
        public async Task<ActionResult> Index([FromQuery] string token)
        {
            var email = _tokenService.DataFromToken(token, t => t.Type == "email");
            var user = await _userManager.FindByEmailAsync(email);
            return Ok(new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                ImgURL = user.ImgURL,
                Gender = user.Gender,
                Bio = user.Bio,
                DataofBirth = user.DataofBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = user.City,
                PhoneNumber = user.PhoneNumber,
                Token = token,
            });
        }

        [HttpPost("register")] // POST: api/account/register?username=dave&password=pwd
        public async Task<ActionResult> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.Email)) return BadRequest("Email is Already Exist");

            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) return BadRequest(result.Errors);

            var roleResult = await _userManager.AddToRoleAsync(user, "Member");

            if (!roleResult.Succeeded) return BadRequest(result.Errors);

            return Ok(new StanderUserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
            });
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users
                .Include(p => p.Photo)
                .SingleOrDefaultAsync(x => x.UserName == loginDto.Email);

            if (user == null) return Unauthorized("invalid email or password");

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) return Unauthorized("invalid email or password");

            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                ImgURL = user.ImgURL,
                Gender = user.Gender,
                Bio = user.Bio,
                DataofBirth = user.DataofBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = user.City,
                PhoneNumber = user.PhoneNumber
            };
        }

        [HttpPost("Edit")]
        public async Task<ActionResult<UserDto>> Edit(UserEditDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user is null)
            {
                return NotFound(new { success = false, message = "NotFound" });
            }

            user.PhoneNumber = dto.PhoneNumber;
            user.FirstName = dto.FirstName;
            user.LastName = dto.LastName;
            user.Bio = dto.Bio;
            user.City = dto.Location;
            user.Gender = dto.Gender;
            user.DataofBirth = dto.DataofBirth;
            user.ImgURL = dto.ImgURL;

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                Token = await _tokenService.CreateToken(user),
                ImgURL = user.ImgURL,
                Gender = user.Gender,
                Bio = user.Bio,
                DataofBirth = user.DataofBirth,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Location = user.City,
                PhoneNumber = user.PhoneNumber
            };
        }

        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(email);
                if (user is null)
                {
                    return NotFound(new { success = false, message = "NotFound" });
                }
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);

                var callbackurl = Url.Action("ResetPassword", "Account", values: new { userId = user.Id, Code = code }, protocol: Request.Scheme);

                await _mailService.SendEmailAsync(email, "Reset Email Confirmation", "Please reset email by going to this " +
                    "<a href=\"" + callbackurl + "\">link</a>");
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user is null)
                    return BadRequest("Email Not Found");

                var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest("Invalid Token");
            }
            return BadRequest(model);
        }

        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);

                if (user is null)
                    return BadRequest("Email Not Found");

                var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    return Ok();
                }
                return BadRequest(result.Errors);
            }
            return BadRequest(model);
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}