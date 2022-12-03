﻿using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

using Booking.System.Domain.Identity;
using Booking.System.Application.Identity.DTO;

using AutoMapper;
using Microsoft.Extensions.Options;
using Booking.System.Domain;
using Booking.System.Domain.Booking;

namespace Booking.System.Application.Identity
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JWTSettings _settings;

        private readonly IMapper _mapper;

        private readonly CampDbContext _campDbContext;

        private AppUser? _user;

        public UserAuthenticationRepository(UserManager<AppUser> userManager, IOptions<JWTSettings> options, IMapper mapper, CampDbContext campDbContext)
        {
            _userManager = userManager;
            _settings = options.Value;
            _mapper = mapper;
            _campDbContext = campDbContext;
        }

        public async Task<IdentityResult> RegisterUserAsync(UserRegistrationDto userRetistrationDto)
        {
            var user = _mapper.Map<AppUser>(userRetistrationDto);
            var result = await _userManager.CreateAsync(user, userRetistrationDto.Password);
            return result;
        }

        public async Task<IdentityResult> RegisterParentAsync(ParentRegistrationDto parentRegistrationDto)
        {
            var user = _mapper.Map<AppUser>(parentRegistrationDto.UserRegistration);
            var result = await _userManager.CreateAsync(user, parentRegistrationDto.UserRegistration.Password);
            var addedUser = await _userManager.FindByNameAsync(parentRegistrationDto.UserRegistration.UserName);
            if (addedUser != null)
            {

                string[] PassportDates = parentRegistrationDto.PassportDateOfIssue.Split("-");
                string[] ValidityDates = parentRegistrationDto.PassportValidity.Split("-");
                string[] BirthdayDates = parentRegistrationDto.Birthday.Split("-");

                var status = new Status
                {
                    Name = "Родитель"
                };
                if (_campDbContext.Statuses.FirstOrDefault(x=>x.Name==status.Name) == null) 
                    _campDbContext.Statuses.Add(status);
                var status2 = new Status
                {
                    Name = "Законный представитель ребенка"
                };
                if (_campDbContext.Statuses.FirstOrDefault(x => x.Name == status2.Name) == null)
                    _campDbContext.Statuses.Add(status2);
                _campDbContext.SaveChanges();

                var address = new Address
                {
                    AddressContent = parentRegistrationDto.Address,
                    Citizenship = parentRegistrationDto.Country
                };
                _campDbContext.Addresses.Add(address);
                _campDbContext.SaveChanges();
                int? passportRuId = null;
                int? passportForeignId = null;
                
                if (parentRegistrationDto.PassportType == "ru")
                {
                    var passportRu = new PassportRu
                    {
                        Number = parentRegistrationDto.PassportNumber,
                        Series = parentRegistrationDto.PassportSerial,
                        IssuedBy = parentRegistrationDto.PassportIssuedBy,
                        DateOfIssue = new DateOnly(int.Parse(PassportDates[0]), int.Parse(PassportDates[1]), int.Parse(PassportDates[2]))
                    };
                    _campDbContext.PassportRus.Add(passportRu);
                    _campDbContext.SaveChanges();
                    passportRuId = passportRu.PassportId;
                }
                else
                {
                    var passportForeign = new PassportForeign
                    {
                        Number = parentRegistrationDto.PassportNumber,
                        Series = parentRegistrationDto.PassportSerial,
                        IssuedBy = parentRegistrationDto.PassportIssuedBy,
                        DateOfIssue = new DateOnly(int.Parse(PassportDates[0]), int.Parse(PassportDates[1]), int.Parse(PassportDates[2])),
                        Validity  = new DateOnly(int.Parse(ValidityDates[0]), int.Parse(ValidityDates[1]), int.Parse(ValidityDates[2]))
                    };
                    _campDbContext.PassportForeigns.Add(passportForeign);
                    _campDbContext.SaveChanges();
                    passportForeignId = passportForeign.PassportId;
                }
                var parent = new Parent
                {
                    ParentId = addedUser.Id,
                    Name = parentRegistrationDto.UserRegistration.FirstName,
                    Surname = parentRegistrationDto.UserRegistration.LastName,
                    Patronymic = parentRegistrationDto.UserRegistration.ThirdName,
                    AddressId = address.AddressId,
                    Email = addedUser.Email,
                    PhoneNumber = addedUser.PhoneNumber,
                    Birthday = new DateOnly(int.Parse(BirthdayDates[0]), int.Parse(BirthdayDates[1]), int.Parse(BirthdayDates[2])),
                    PassportForeignId = passportForeignId,
                    PassportRuId = passportRuId,
                    StatusId = parentRegistrationDto.StatusId,
                    Snils = parentRegistrationDto.SNILS
                };
                _campDbContext.Parents.Add(parent);
                _campDbContext.SaveChanges();
            }
            return result;
        }

        public async Task<bool> ValidateUserAsync(UserLoginDto loginDto)
        {
            _user = await _userManager.FindByNameAsync(loginDto.UserName);
            var result = _user != null && await _userManager.CheckPasswordAsync(_user, loginDto.Password);
            return result;
        }

        public async Task<string> CreateTokenAsync()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();

            var tokenOptions = GenerateTokenOptions(signingCredentials, claims);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private SigningCredentials GetSigningCredentials()
        {
            var key = Encoding.UTF8.GetBytes(_settings.Secret);
            var secret = new SymmetricSecurityKey(key);

            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, _user.UserName)
            };

            var roles = await _userManager.GetRolesAsync(_user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }

        private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
        {
            var tokenOptions = new JwtSecurityToken
            (
                issuer: _settings.ValidIssuer,
                audience: _settings.ValidAudience,

                claims: claims,

                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_settings.ExpiresIn)),
                signingCredentials: signingCredentials
            );
            return tokenOptions;
        }
    }
}
