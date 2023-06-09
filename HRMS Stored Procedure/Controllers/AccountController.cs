﻿using HRMS_Stored_Procedure.DTO;
using HRMS_Stored_Procedure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HRMS_Stored_Procedure.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private SignInManager<ApplicationUser> _signInManager;
        public IConfiguration _appConfig { get; }

        public AccountController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<ApplicationUser> signInManager, IConfiguration appConfig)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _appConfig = appConfig;
        }
        [HttpPost]
        public async Task<IActionResult> LogInAsync(string UserName, string Password)
        {
            var issuer = _appConfig["JWT:Issuer"];
            var audience = _appConfig["JWT:Audience"];
            var key = _appConfig["JWT:Key"];

            // Log In
            if (ModelState.IsValid)
            {
                var credentials = await _signInManager.PasswordSignInAsync(UserName, Password, true, false);
                if (credentials.Succeeded)
                {
                    var user = await _signInManager.UserManager.FindByNameAsync(UserName);
                    if (user != null)
                    {
                        var roles = await _signInManager.UserManager.GetRolesAsync(user);

                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),

                        roles.Contains("Administrator") ? new Claim(ClaimTypes.Role, "Administrator") : null,
                        roles.Contains("Manager") ? new Claim(ClaimTypes.Role, "Manager") : null,
                        roles.Contains("Employee") ? new Claim(ClaimTypes.Role, "Employee") : null
                    };

                        var keyBytes = Encoding.UTF8.GetBytes(key);
                        var theKey = new SymmetricSecurityKey(keyBytes); 
                        var creds = new SigningCredentials(theKey, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(issuer, audience, claims.Where(x => x != null), expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
                        return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                    }
                }
                return BadRequest("Invalid Credentials!");
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Sign out the user

            // Return a response
            return Ok(new { message = "Logout successful" });
        }

    }
}
