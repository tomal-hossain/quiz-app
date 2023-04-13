using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Entity;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Service.Dto;
using Service.Helper;

namespace Service.Services
{
    public interface IAuthService
    {
        Task<Result> Register(RegisterRequest request);
        Task<Result> Login(LoginRequest request);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthService> _logger;

        public AuthService(UserManager<ApplicationUser> userManager, IConfiguration config, ILogger<AuthService> logger)
        {
            _userManager = userManager;
            _config = config;
            _logger = logger;
        }

        public async Task<Result> Login(LoginRequest request)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user != null && await _userManager.CheckPasswordAsync(user, request.Password))
                {
                    var userRoles = await _userManager.GetRolesAsync(user);

                    var token = CreateToken(user, userRoles);

                    return new Result { StatusCode = 200, Body = new { Token = token } };
                }
                return new Result { StatusCode = 404, Body = new { Message = "Username or Password doesn't match" } };
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while login", ex);
                return new Result
                {
                    StatusCode = 500,
                    Body = new { Message = "Server Error" }
                };
            }
        }

        public async Task<Result> Register(RegisterRequest request)
        {
            try
            {
                var isUserExisit = await _userManager.FindByEmailAsync(request.Email);
                if(isUserExisit != null)
                {
                    return new Result
                    {
                        StatusCode = 400,
                        Body = new { Message = "Email already exists!" }
                    };
                }

                var user = new ApplicationUser
                {
                    Email = request.Email,
                    UserName = request.Email,
                    NormalizedEmail = request.Email,
                    Name = request.Name,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };

                var result = await _userManager.CreateAsync(user, request.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, RoleType.User.ToString());
                    var token = CreateToken(user, new List<string> { RoleType.User.ToString() });
                    return new Result { StatusCode = 200, Body = new { Token = token } };
                }

                return new Result { StatusCode = 400, Body = new { Message = result.Errors.First().Description } };
            }
            catch(Exception ex)
            {
                _logger.LogError("Error while register new user", ex);
                return new Result
                {
                    StatusCode = 500,
                    Body = new { Message = "Server Error" }
                };
            }
        }

        private string CreateToken(ApplicationUser user, IList<string> userRoles)
        {
            bool isAdmin = userRoles.Any(r => string.Equals(r, UserRole.Admin));
            var authClaims = new List<Claim>
                {
                    new Claim(AppClaim.Name, user.Name),
                    new Claim(AppClaim.UserId, user.Id),
                    new Claim(AppClaim.IsAdmin, isAdmin.ToString())
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Key:TokenKey"]));

            var token = new JwtSecurityToken(
                issuer: _config["ApiBaseUrl"],
                expires: DateTime.Now.AddDays(7),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
