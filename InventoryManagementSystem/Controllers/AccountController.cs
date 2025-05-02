using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        
            private readonly UserManager<ApplicationUser> userManager;
            private readonly RoleManager<IdentityRole> roleManager;
            private readonly IConfiguration config;

            public AccountController(UserManager<ApplicationUser> userManager, IConfiguration config, RoleManager<IdentityRole> roleManager)
            {
                this.userManager = userManager;
                this.config = config;
            this.roleManager = roleManager;
            }

            [HttpPost("register")]
            public async Task<IActionResult> Register(RegisterDto userFromConsumer)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = new ApplicationUser()
                    {
                        UserName = userFromConsumer.UserName,
                        Email = userFromConsumer.Email
                    };
                    IdentityResult result = await userManager.CreateAsync(user, userFromConsumer.Password);
                    if (result.Succeeded)
                    {
                        
                        return Ok("Account Create Success");
                    }
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
                return BadRequest(ModelState);
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(LoginDto userFromConsumer)
            {
                if (ModelState.IsValid)
                {
                    ApplicationUser user = await userManager.FindByNameAsync(userFromConsumer.UserName);
                    if (user != null)
                    {
                        bool found = await userManager.CheckPasswordAsync(user, userFromConsumer.Password);
                        if (found)
                        {
                            #region Create Token
                            string jti = Guid.NewGuid().ToString();
                            var userRoles = await userManager.GetRolesAsync(user);


                            List<Claim> claim = new List<Claim>();
                            claim.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
                            claim.Add(new Claim(ClaimTypes.Name, user.UserName));
                            claim.Add(new Claim(JwtRegisteredClaimNames.Jti, jti));
                            if (userRoles != null)
                            {
                                foreach (var role in userRoles)
                                {
                                    claim.Add(new Claim(ClaimTypes.Role, role));
                                }
                            }
                            //
                            SymmetricSecurityKey signinKey =
                                new(Encoding.UTF8.GetBytes(config["JWT:Key"]));

                            SigningCredentials signingCredentials =
                                new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256);

                            JwtSecurityToken myToken = new JwtSecurityToken(
                                issuer: config["JWT:Iss"],
                                audience: config["JWT:Aud"],
                                expires: DateTime.Now.AddHours(1),
                                claims: claim,
                                signingCredentials: signingCredentials
                                );

                            
                            return Ok(new
                            {
                                expired = DateTime.Now.AddHours(10),
                                token = new JwtSecurityTokenHandler().WriteToken(myToken)
                            });
                            #endregion
                        }
                    }
                    ModelState.AddModelError("", "Invalid Account");
                }
                return BadRequest(ModelState);
            }
        [Authorize(Roles = "Admin")]
        [HttpPost("addrole")]
        public async Task<IActionResult> AddRole(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return BadRequest("Role name is required.");
            }

            var roleExists = await roleManager.RoleExistsAsync(role);
            if (roleExists)
            {
                return BadRequest("Role already exists.");
            }

            var result = await roleManager.CreateAsync(new IdentityRole(role));
            if (result.Succeeded)
            {
                return Ok("Role created successfully.");
            }

            return BadRequest(result.Errors);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("assignrole")]
        public async Task<IActionResult> AssignRole(string userId, string role)
        {
            if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(role))
            {
                return BadRequest("UserId and Role are required.");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            var roleExists = await roleManager.RoleExistsAsync(role);
            if (!roleExists)
            {
                return NotFound("Role does not exist.");
            }

            var result = await userManager.AddToRoleAsync(user, role);
            if (result.Succeeded)
            {
                return Ok("Role assigned to user successfully.");
            }

            return BadRequest(result.Errors);
        }

    }
}
