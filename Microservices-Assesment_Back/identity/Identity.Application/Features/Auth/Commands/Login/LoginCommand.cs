using Core.Application.Dtos;
using Core.Security.Enums;
using Core.Security.JWT;
using Identity.Application.Features.Auth.Rules;
using Identity.Application.Services.AuthService;
using Identity.Application.Services.UsersService;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.Login;

public class LoginCommand : IRequest<LoggedResponse>
{
    public UserForLoginDto UserForLoginDto { get; set; }
    public string IpAddress { get; set; }

    public LoginCommand()
    {
        UserForLoginDto = null!;
        IpAddress = string.Empty;
    }

    public LoginCommand(UserForLoginDto userForLoginDto, string ipAddress)
    {
        UserForLoginDto = userForLoginDto;
        IpAddress = ipAddress;
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
    {
        private readonly AuthBusinessRules _authBusinessRules;

        private readonly IAuthService _authService;
        private readonly IUserService _userService;
        public LoginCommandHandler(
            IUserService userService,
            IAuthService authService,
            AuthBusinessRules authBusinessRules
        )
        {
            _userService = userService;
            _authService = authService;
            _authBusinessRules = authBusinessRules;
        }

        public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            User? user = await _userService.GetAsync(
                predicate: u => u.Email == request.UserForLoginDto.Email,
                cancellationToken: cancellationToken
            );
            await _authBusinessRules.UserShouldBeExistsWhenSelected(user);
            await _authBusinessRules.UserPasswordShouldBeMatch(user!, request.UserForLoginDto.Password);

            LoggedResponse loggedResponse = new();

            AccessToken createdAccessToken = await _authService.CreateAccessToken(user);

            RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(user, request.IpAddress);
           RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);
            await _authService.DeleteOldRefreshTokens(user.Id);

            loggedResponse.AccessToken = createdAccessToken;
            loggedResponse.RefreshToken = addedRefreshToken;
            return loggedResponse;
        }
    }
}
