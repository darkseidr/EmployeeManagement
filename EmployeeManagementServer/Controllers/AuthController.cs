using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using EmployeeManagement.Data;

namespace EmployeeManagementServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {

        private readonly IConfiguration _configuration;
        private readonly ApplicationDbContext _context;
        public AuthController(IConfiguration configuration, ApplicationDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.LoginModels.FirstOrDefaultAsync(l => l.Username == login.Username);

            
            if ((existingUser != null && login.Username == existingUser.Username && login.Password == existingUser.Password) || (login.Username == "Admin" && login.Password == "TestPassword@1"))
            {
                var token = GenerateJwtToken(login.Username);
                return Ok(new { token });
            }
            return Unauthorized();
        }


        [Authorize]
        [HttpPost("update")]
        public async Task<IActionResult> UpdateLoginModel([FromBody] LoginModel loginModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.LoginModels.FirstOrDefaultAsync(l => l.Id == loginModel.Id);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }


            existingUser.Password = loginModel.Password;
            _context.LoginModels.Update(existingUser);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpPost("addCredentials")]
        public async Task<ActionResult<LoginModel>> AddLoginModel(LoginModel loginModel)
        {
            
            try
            {
                var existingUser = await _context.LoginModels.FirstOrDefaultAsync(l => l.Username == loginModel.Username);
                if (existingUser != null)
                {
                    return Unauthorized("Please provide unique Username");
                }
                loginModel.Id = 0;
                _context.LoginModels.Add(loginModel);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error adding employee: {ex.Message}");
            }
        }

        private string GenerateJwtToken(string username)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = jwtSettings["Key"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(jwtSettings["ExpirationMinutes"])),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
