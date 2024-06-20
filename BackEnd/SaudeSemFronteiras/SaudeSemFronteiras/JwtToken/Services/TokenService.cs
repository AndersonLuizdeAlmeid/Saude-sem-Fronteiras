using SaudeSemFronteiras.Application.JwtToken.Models;
using System.Security.Claims;

namespace SaudeSemFronteiras.Application.JwtToken.Services;
public class TokenService
{
    //public static string GenerateCustomToken(UserDto user)
    //{
    //    var claims = new List<Claim>
    //    {
    //        new("userID", user.ID.ToString()),
    //        new("isAdministrator", user.IsAdministrator.ToString())
    //    };

    //    var key = new SymmetricSecurityKey(Convert.FromBase64String(Key.Secret!));
    //    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

    //    var token = new JwtSecurityToken(
    //        expires: DateTime.UtcNow.AddHours(16),
    //        signingCredentials: creds,
    //        claims: claims
    //    );

    //    return new JwtSecurityTokenHandler().WriteToken(token);
    //}

    //public static TokenDto DecryptToken(string token)
    //{
    //    var handler = new JwtSecurityTokenHandler();

    //    var validationParameters = new TokenValidationParameters
    //    {
    //        ValidateIssuerSigningKey = true,
    //        IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(Key.Secret!)),
    //        ValidateIssuer = false,
    //        ValidateAudience = false,
    //        RequireExpirationTime = true,
    //        ValidateLifetime = false,
    //        ClockSkew = TimeSpan.Zero
    //    };

    //    var principal = handler.ValidateToken(token, validationParameters, out _);

    //    TokenDto tokenDto = new();

    //    foreach (var claim in principal.Claims)
    //    {

    //        switch (claim.Type)
    //        {
    //            case "userID":
    //                tokenDto.UserID = int.Parse(claim.Value);
    //                break;

    //            case "isAdministrator":
    //                tokenDto.IsDoctor = bool.Parse(claim.Value);
    //                break;

    //            case "exp":
    //                tokenDto.ExpirationDate = DateTimeOffset.FromUnixTimeSeconds(long.Parse(claim.Value)).UtcDateTime;
    //                break;

    //        }
    //    }
    //    return tokenDto;
    //}
}
