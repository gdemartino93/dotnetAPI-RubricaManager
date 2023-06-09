﻿using AutoMapper;
using dotnetAPI_Rubrica.Data;
using dotnetAPI_Rubrica.Models;
using dotnetAPI_Rubrica.Models.DTO;
using dotnetAPI_Rubrica.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authentication;

namespace dotnetAPI_Rubrica.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private string secretKey;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserRepository(ApplicationDbContext dbContext,
                              IConfiguration config,
                              RoleManager<IdentityRole> roleManager,
                              UserManager<ApplicationUser> userManager,
                              IMapper mapper,
                              IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            secretKey = config.GetValue<string>("ApiSettings:secretKey");
            Console.WriteLine(secretKey);
            _roleManager = roleManager;
            _userManager = userManager;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;

        }

        //public async Task<bool> Logout()
        //{
        //    var currentUser = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
        //    if(currentUser is null)
        //    {
        //        return false;
        //    }
        //    await _httpContextAccessor.HttpContext.SignOutAsync();
        //    return true;
        //}
        public bool IsUniqueUser(string username)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == username);
            if (user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<LoginResponseDTO> Login(LoginRequestDTO loginRequestDTO)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == loginRequestDTO.Username.ToLower());
            bool isValid = await _userManager.CheckPasswordAsync(user, loginRequestDTO.Password);
            if (user == null || isValid == false)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    User = null,
                };
            }
            var token = GenerateJwtToken(user, secretKey);
            var roles = await _userManager.GetRolesAsync(user);
            var loginResponseDTO = new LoginResponseDTO()
            {
                Token = token,
                User = _mapper.Map<UserDTO>(user),
                Role = roles.FirstOrDefault()
            };
            return loginResponseDTO;

        }

        public async Task<UserDTO> Register(RegisterRequestDTO registerRequestDTO)
        {
            ApplicationUser newUser = new()
            {
                UserName = registerRequestDTO.Username,
                Name = registerRequestDTO.Name,
                Lastname = registerRequestDTO.Lastname,
                Email = registerRequestDTO.Email
            };

            var createdNewUser = await _userManager.CreateAsync(newUser, registerRequestDTO.Password);
            if (createdNewUser.Succeeded)
              {
                    //creiamo i ruoli se non esistono(da spostare in db)
                    if (!_roleManager.RoleExistsAsync("admin").GetAwaiter().GetResult())
                    {
                        await _roleManager.CreateAsync(new IdentityRole { Name = "admin" });
                        await _roleManager.CreateAsync(new IdentityRole { Name = "user" });
                    }
                    //assegnaimo il ruolo all'utente appena creato
                    await _userManager.AddToRoleAsync(newUser, "user");
                    //creiamo l'oggetto da ritoranre
                    var userToReturn = _dbContext.ApplicationUsers.FirstOrDefault(u => u.UserName == registerRequestDTO.Username);

                   return _mapper.Map<UserDTO>(userToReturn);
                }
            else
            {
                var error = createdNewUser.Errors.FirstOrDefault();
                if (error != null)
                {
                    throw new ArgumentException(error.Description);
                }
            }

            return null;
        }

        private string GenerateJwtToken(ApplicationUser user, string secretKey)
        {
            var roles = _userManager.GetRolesAsync(user).Result;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
                new Claim(ClaimTypes.Role, roles.FirstOrDefault())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool IsUniqueEmail(string email)
        {
            var user = _dbContext.ApplicationUsers.FirstOrDefault(u => u.Email == email);
            if( user == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _dbContext.ApplicationUsers.ToListAsync();
            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetMe()
        {
            UserDTO userDTO = null;
            return userDTO;
        }


    }
}
