using AssessnyApp.Container;
using BLL.Helper;
using BLL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BLL.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext db;
        private readonly JWT _jwt;
        public AuthService(UserManager<IdentityUser> userManager/*, RoleManager<IdentityRole> roleManager*/, IOptions<JWT> jwt, ApplicationDbContext db)
        {
            _userManager = userManager;
            this.db = db;
            //_roleManager = roleManager;
            _jwt = jwt.Value;
        }

        public async Task<ResponseBody<AuthModel>> GetTokenAsync(TokenRequestModel model)
        {
            var authModel = new AuthModel();
            ResponseBody<AuthModel> response = new ResponseBody<AuthModel>();
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user is null ||(!await _userManager.CheckPasswordAsync(user,model.Password)))
            {
                response.error= "Email or Password is incorrect!";
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                return response;
            }
            var jwtSecurityToken = await CreateJwtToken(user);
            var rolesList = await _userManager.GetRolesAsync(user);

            authModel.IsAuthenticated = true;
            authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            authModel.Email = user.Email;
            authModel.Username = user.UserName;
            authModel.UseID = user.Id;
            if (rolesList[0] == "Teacher")
            {
                authModel.Phone = db.Teachers.Where(x => x.Email == model.Email).FirstOrDefault().PhoneNumber;
                authModel.UseID= db.Teachers.Where(x => x.Email == model.Email).FirstOrDefault().TeacherId.ToString();
            }
            else if (rolesList[1] == "Student")
            {
                authModel.Phone = db.Students.Where(x => x.Email == model.Email).FirstOrDefault().PhoneNumber;
                authModel.UseID = db.Students.Where(x => x.Email == model.Email).FirstOrDefault().StudentId.ToString();
            }
            authModel.Roles = rolesList.ToList();
            response.data=new List<AuthModel>() {authModel};
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }

        public async Task<ResponseBody<AuthModel>> RegisterAsync(RegisterModel model)
        {
            ResponseBody<AuthModel> response = new ResponseBody<AuthModel>();
            if (await _userManager.FindByEmailAsync(model.Email) is not null)
            {
                response.error = "Email is already registered!";
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                return response;

            }
            var user = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Name.Split(" ")[0]
            };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
               
                foreach (var error in result.Errors)
                   response.error += $"{error.Description},";
                response.data = null;
                response.message = false;
                response.status_code = $"{ StatusCodes.Status400BadRequest}";
                return response;
            }
            await _userManager.AddToRoleAsync(user, model.Role);

            var jwtSecurityToken = await CreateJwtToken(user);

           AuthModel authModel= new AuthModel
            {
                Email = user.Email,
                UseID=  _userManager.FindByEmailAsync(model.Email).Result.Id,
                IsAuthenticated = true,
                Roles = new List<string> { model.Role },
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Username = user.UserName,
                Phone=model.PhoneNumber
            };        
            response.data = new List<AuthModel>() { authModel };
            response.message = true;
            response.status_code = $"{ StatusCodes.Status200OK}";
            response.error = null;
            return response;
        }
        private async Task<JwtSecurityToken> CreateJwtToken(IdentityUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwt.Issuer,
                audience: _jwt.Audience,
                claims: claims,
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
