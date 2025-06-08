using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RegistoCriminal.Data;
using RegistoCriminal.Dtos;
using RegistoCriminal.Entities;
using System.Security.Claims;

namespace RegistoCriminal.Controllers
{
    [Authorize(Roles = "SuperAdministrador")]
    [ApiController]
    [Route("api/authorizations")]
    public class AuthorizationController : ControllerBase
    {
        //private readonly IAuthorizationService _authorizationService;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RegistoCriminalContext _registoCriminalContext;
        private readonly IMapper _mapper;

        public AuthorizationController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            RegistoCriminalContext registoCriminalContext,
            IMapper mapper)
        {
            _userManager = userManager ??
                throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ??
                throw new ArgumentNullException(nameof(roleManager));
            _registoCriminalContext = registoCriminalContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all roles in the system
        /// </summary>
        /// <returns></returns>
        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var roles = _roleManager.Roles.Select(r => new { r.Id, r.Name });

            var _roles = await roles.AsNoTracking().ToListAsync();


            return Ok(_roles);
        }

        /// <summary>
        /// Claims for a specific role
        /// </summary>
        /// <param name="roleName">the role name</param>
        /// <returns></returns>
        [HttpGet("roles/{roleName}/claims")]
        public async Task<IActionResult> GetRoleClaims(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return NotFound("Role not found");

            var claims = await _roleManager.GetClaimsAsync(role);
            return Ok(claims.Select(c => new { c.Type, c.Value }));
        }

        /// <summary>
        /// Get claims for a specific user
        /// </summary>
        /// <param name="username">The username</param>
        /// <returns></returns>
        [HttpGet("claims")]
        public async Task<IActionResult> GetClaims(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null)
                return NotFound("User not found");

            var claims = await _userManager.GetClaimsAsync(user);
            return Ok(claims.Select(c => new { c.Type, c.Value }));
        }

        [HttpPost("claims")]
        public async Task<IActionResult> AddClaim(AspSystemClaimsDto aspSystemClaims)
        {
            var hasClaim = await _registoCriminalContext.AspSystemsClaims.AnyAsync(c => c.Type == aspSystemClaims.Type && c.Value == aspSystemClaims.Value);

            if (hasClaim)
                return BadRequest("Claim já existe");

            var systemclaims =  _mapper.Map<AspSystemClaims>(aspSystemClaims);

            _registoCriminalContext.AspSystemsClaims.Add(systemclaims);

            await _registoCriminalContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("roles")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (await _roleManager.RoleExistsAsync(roleName))
                return BadRequest("Role já existe");

            var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
            return result.Succeeded ? Ok("Role criado") : BadRequest(result.Errors);
        }

        [HttpPost("users/{userId}/claims")]
        public async Task<IActionResult> AddClaimToUser(string userId, [FromBody] int idclaim)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            var claimDto = await _registoCriminalContext.AspSystemsClaims
                .Where(c => c.Id == idclaim)
                .Select(c => new ClaimDto { Type = c.Type, Value = c.Value })
                .FirstOrDefaultAsync();

            if (claimDto == null)
                return NotFound("Claim not found");

            var claim = new Claim(claimDto.Type, claimDto.Value);
            var result = await _userManager.AddClaimAsync(user, claim);

            return result.Succeeded ? Ok("Claim adicionado ao utilizador") : BadRequest(result.Errors);
        }

        [HttpPost("users/{userId}/roles")]
        public async Task<IActionResult> AddRoleToUser(string userId, [FromBody] string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound("User not found");

            if (!await _roleManager.RoleExistsAsync(roleName))
                return BadRequest("Role does not exist");

            var result = await _userManager.AddToRoleAsync(user, roleName);
            return result.Succeeded ? Ok("Role adicionado ao utilizador") : BadRequest(result.Errors);
        }

        [HttpPost("roles/{roleName}/claims")]
        public async Task<IActionResult> AddClaimToRole(string roleName, [FromBody] ClaimDto claimDto)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role == null) return NotFound("Role not found");

            var result = await _roleManager.AddClaimAsync(role, new Claim(claimDto.Type, claimDto.Value));
            return result.Succeeded ? Ok("Claim added to role") : BadRequest(result.Errors);
        }
    }
}
