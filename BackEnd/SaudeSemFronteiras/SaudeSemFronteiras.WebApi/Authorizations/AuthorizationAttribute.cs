using Microsoft.AspNetCore.Mvc;

namespace SaudeSemFronteiras.WebApi.Authorizations;
public class AuthorizationAttribute : TypeFilterAttribute
{
    public AuthorizationAttribute() : base(typeof(AuthorizationFilter))
    {

    }
}
