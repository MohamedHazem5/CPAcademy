using Microsoft.AspNetCore.Mvc;

namespace CPAcademy.Controllers
{
    public class RoleController : BaseAPIController
    {
        private readonly RoleManager<Role> _roleManager;

        public RoleController(RoleManager<Role> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _roleManager.Roles.ToListAsync();
            return Ok(result);
        }

        [HttpPost("Create")]
        public async Task<ActionResult> CreateRole(string roleName)
        {
            var result = await _roleManager.CreateAsync(new Role { Name = roleName });
            if (!result.Succeeded)
                return BadRequest(result.Errors);
            return Ok();
        }
    }
}