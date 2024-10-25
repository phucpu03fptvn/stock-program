using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StockProgram_API.Dtos.Account;
using StockProgram_Application.Services.TokenService;
using StockProgram_Domain.Models;

namespace StockProgram_API.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private UserManager<AppUser> _userManager;
        private ITokenService _tokenService;
        private SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> LoginWithUserNamePassword([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDTO.userName.ToLower());
            if (user == null) return Unauthorized("Invalid username!");
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.passWord, false);
            if (!result.Succeeded) return Unauthorized("Username not found and/or password not found!");
            return Ok(
                new NewAccountDTO
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    Token = _tokenService.CreateToken(user)
                }
                );
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterDTO registerDTO)
        {
            try
            {
                if (!ModelState.IsValid) {
                    return BadRequest(ModelState);
                }
                var AppUser = new AppUser
                {
                    UserName = registerDTO.userName,
                    Email = registerDTO.emailAddress
                };

                var newAccount = await _userManager.CreateAsync(AppUser, registerDTO.password);
                if (newAccount.Succeeded)
                {
                    var roleAcc = await _userManager.AddToRoleAsync(AppUser, "User");
                    if (roleAcc.Succeeded)
                    {
                        return Ok(
                            new NewAccountDTO
                            {
                                Email = AppUser.Email,
                                UserName = AppUser.UserName,
                                Token = _tokenService.CreateToken(AppUser)
                            }
                           );
                            
                    }
                    else
                    {
                        return StatusCode(500, roleAcc.Errors);
                    }
                }
                else { 
                    return StatusCode(500, newAccount.Errors);
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
