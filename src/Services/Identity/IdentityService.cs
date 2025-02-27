﻿using LocaFilms.Models;
using LocaFilms.Repository;
using LocaFilms.Services.Communication;
using LocaFilms.Services.Identity.Configurations;
using LocaFilms.Services.Identity.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace LocaFilms.Services.Identity
{
    public class IdentityService : IIdentityService
    {
        private readonly AspNetUserManager<UserModel> _aspNetUserManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IUserRepository _userRepository;
        private readonly JwtOptions _jwtOptions;

        public IdentityService(AspNetUserManager<UserModel> aspNetUserManager,
                               SignInManager<UserModel> signInManager,
                               IUserRepository userRepository,
                               IOptions<JwtOptions> jwtOptions)
        {
            _aspNetUserManager = aspNetUserManager;
            _signInManager = signInManager;
            _userRepository = userRepository;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<UserResponse> Register(string email, string password)
        {
            var user = new UserModel()
            {
                Email = email,
                UserName = email,
                EmailConfirmed = true
            };

            try
            {
                if (await _userRepository.CountAsync() >= 50)
                {
                    return new UserResponse($"Não foi possível cadastrar o usuário.");
                }

                var result = await _aspNetUserManager.CreateAsync(user, password);

                if (!result.Succeeded)
                {
                    return new UserResponse($"Não foi possível cadastrar o usuário. ${result.Errors.Select(e => e.Description).First()}");
                }

                await _aspNetUserManager.AddToRoleAsync(user, Roles.Customer);
                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"Não foi possível cadastrar o usuário. ${ex.Message}");
            }
        }

        public async Task<UserLoginResponse> Login(string email, string password)
        {
            var check = await _signInManager.PasswordSignInAsync(email, password, false, true);

            if (check.Succeeded)
            {
                var user = await _aspNetUserManager.FindByEmailAsync(email);
                return new UserLoginResponse(
                    success: true,
                    message: string.Empty,
                    accessToken: await GerarTokenJwt(user),
                    userId: user?.Id);
            }
                
            string failMessage = "O email e/ou senha estão incorretos.";
            if (check.IsLockedOut)
                failMessage = "Este usuário está bloqueado.";
            else if (check.IsNotAllowed)
                failMessage = "Este usuário não tem permissão para realizar o login.";

            return new UserLoginResponse(false, failMessage, string.Empty);
        }

        private async Task<string> GerarTokenJwt(UserModel? user)
        {
            if (user == null || user.Email == null)
                return string.Empty;

            List<Claim> claims =
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64),
                .. await _aspNetUserManager.GetClaimsAsync(user),
            ];

            var roles = await _aspNetUserManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim("role", role));

            var tokenJwt = new JwtSecurityToken(
                issuer: _jwtOptions.Issuer,
                audience: _jwtOptions.Audience,
                claims: claims,
                expires: DateTime.Now.AddSeconds(_jwtOptions.AccessTokenExpiration),
                notBefore: DateTime.Now,
                signingCredentials: _jwtOptions.SigningCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenJwt);
        }
    }
}
