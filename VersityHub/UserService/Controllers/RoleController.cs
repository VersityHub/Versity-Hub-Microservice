using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Data;
using UserService.Model.Customer;
using UserService.Repository.Interface;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly UserDbContext _context;
        private readonly UserManager<ApplicationCustomer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RoleController> _logger;
        private readonly IRoleRepository _roleRepository;

        public RoleController(
            UserDbContext context,
            UserManager<ApplicationCustomer> userManager,
            RoleManager<IdentityRole> roleManger,
            ILogger<RoleController> logger,
            IRoleRepository roleRepository)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManger;
            _logger = logger;
            _roleRepository = roleRepository;
        }


        [HttpPost("createRole")]
        public async Task<IActionResult> CreateRole(string name)
        {
            var role = await _roleRepository.CreateRole(name);
            return Ok(role);
        }

        [HttpPost("deleteRole")]
        public async Task<IActionResult> DeleteRole(string name)
        {
            var role = await _roleRepository.DeleteRole(name);
            return Ok(role);
        }

        [HttpGet("getRoles")]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole(string email, string roleName)
        {
            var role = await _roleRepository.AssignRole(email, roleName);
            return Ok(role);
        }

        [HttpGet("getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("getUserRole")]
        public async Task<IActionResult> GetUserRole(string email)
        {
            //check if email is valid 
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                _logger.LogInformation($"This user {email} does not exist");
                return BadRequest($"This user {email} does not exist. Check the email and try again.");
            }
            var role = await _userManager.GetRolesAsync(user);
            return Ok(role);
        }

        [HttpPost("deleteUserRole")]
        public async Task<IActionResult> DeleteUserRole(string email, string roleName)
        {
            var deleteRole = await _roleRepository.DeleteUserRole(email, roleName);
            return Ok(deleteRole);
        }

        [HttpPost("deleteUserAccount")]
        public async Task<IActionResult> DeleteUserAcoount(string email)
        {
            var deleteAccount = await _roleRepository.DeleteUserAccount(email);
            return Ok(deleteAccount);
        }

    }
}
