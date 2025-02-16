using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FireSafetySystem.Server.Database;
using FireSafetySystem.Server.Models;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FireSafetySystem.Server.Authentication
{
        public class AuthService
        {
            private readonly AppDbContext _context;
            private readonly IConfiguration _configuration;

            public AuthService(AppDbContext context, IConfiguration configuration)
            {
                _context = context;
                _configuration = configuration;
            }

            public async Task<AuthResponse?> Authenticate(FireSafetySystem.Server.Models.LoginRequest request)
            {
                var user = await _context.Users.SingleOrDefaultAsync(u => u.Email == request.Email);

                if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                    return null;

                var token = GenerateJwtToken(user);
                return new AuthResponse { Token = token, Role = user.Role, Name = user.Name };
            }

            public async Task<bool> Register(FireSafetySystem.Server.Models.RegisterRequest request)
            {
                if (await _context.Users.AnyAsync(u => u.Email == request.Email))
                    return false;

                var user = new User
                {
                    Name = request.Name,
                    Email = request.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Role = request.Role
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }

            private string GenerateJwtToken(User user)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role)
                };

                var token = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddHours(3),
                    signingCredentials: credentials
                );

                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
}
