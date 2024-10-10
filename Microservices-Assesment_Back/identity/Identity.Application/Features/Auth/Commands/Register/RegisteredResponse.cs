using Core.Application.Responses;
using Core.Security.JWT;
using Identity.Domain.Entities;



namespace Identity.Application.Features.Auth.Commands.Register;

public class RegisteredResponse : IResponse
{
    public AccessToken AccessToken { get; set; }
    public RefreshToken RefreshToken { get; set; }

    public RegisteredResponse()
    {
        AccessToken = null!;
        RefreshToken = null!;
    }

    public RegisteredResponse(AccessToken accessToken, Domain.Entities.RefreshToken refreshToken)
    {
        AccessToken = accessToken;
        RefreshToken = refreshToken;
    }
}
