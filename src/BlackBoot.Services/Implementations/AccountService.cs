﻿using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BlackBoot.Services.Implementations;

public class AccountService : IAccountService
{

    private readonly IUserService _userService;
    private readonly IUserJwtTokenService _userTokenService;
    private readonly IJwtTokenFactory _tokenFactoryService;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public AccountService(IUserService userService,
                          IUserJwtTokenService userTokenService,
                          IJwtTokenFactory tokenFactoryService,
                          IHttpContextAccessor httpContextAccessor)
    {
        _userService = userService;
        _userTokenService = userTokenService;
        _tokenFactoryService = tokenFactoryService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<IActionResponse<UserTokenDto>> LoginAsync(UserLoginDto item, CancellationToken cancellationToken = default)
    {
        var user = await _userService.GetByEmailAsync(item.Email, cancellationToken);
        if (user.Data is null) return new ActionResponse<UserTokenDto>(ActionResponseStatusCode.NotFound, AppResource.InvalidUser);

        var checkPasswordResult = _userService.CheckPassword(user.Data, item.Password, cancellationToken);
        if (!checkPasswordResult.Data) return new ActionResponse<UserTokenDto>(ActionResponseStatusCode.NotFound, AppResource.InvalidUser);

        var usertokens = await GenerateTokenAsync(user.Data.UserId, cancellationToken);
        await _userTokenService.AddUserTokenAsync(user.Data.UserId, usertokens.AccessToken, usertokens.RefreshToken, cancellationToken);
        return new ActionResponse<UserTokenDto>(usertokens); ;
    }
    public async Task<IActionResponse> LogoutAsync(string refreshtoken, CancellationToken cancellationToken = default)
    {
        var userId = _httpContextAccessor?.HttpContext?.User?.Identity?.GetUserIdAsGuid();
        if (userId is null || string.IsNullOrEmpty(refreshtoken))
            return new ActionResponse(ActionResponseStatusCode.NotFound, AppResource.InvalidUser);

        await _userTokenService.RevokeUserTokensAsync(userId.Value, refreshtoken, cancellationToken);
        return new ActionResponse();
    }
    public async Task<IActionResponse<UserTokenDto>> RefreshTokenAsync(string refreshToken, CancellationToken cancellationToken = default)
    {
        var refreshTokenModel = await _userTokenService.GetRefreshTokenAsync(refreshToken, cancellationToken);
        if (refreshTokenModel.Data is null)
            return new ActionResponse<UserTokenDto>(ActionResponseStatusCode.NotFound, AppResource.InvalidUser);

        var usertokens = await GenerateTokenAsync(refreshTokenModel.Data.UserId.Value, cancellationToken);
        await _userTokenService.AddUserTokenAsync(refreshTokenModel.Data.UserId.Value, usertokens.AccessToken, usertokens.RefreshToken, cancellationToken);
        return new ActionResponse<UserTokenDto>(usertokens);
    }
    public async Task<IActionResponse<UserDto>> GetCurrentUserAsync(CancellationToken cancellationToken = default)
    {
        var userId = _httpContextAccessor?.HttpContext?.User?.Identity?.GetUserIdAsGuid();
        if (userId is null)
            return new ActionResponse<UserDto>(ActionResponseStatusCode.NotFound, AppResource.InvalidUser);
        var user = await _userService.GetAsync(userId.Value, cancellationToken);
        return new ActionResponse<UserDto>(new UserDto
        {
            Email = user.Data.Email,
            FullName = user.Data.FullName,
            Gender = user.Data.Gender,
            Nationality = user.Data.Nationality,
        });
    }
    private async Task<UserTokenDto> GenerateTokenAsync(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userService.GetAsync(userId, cancellationToken);
        var accessToken = _tokenFactoryService.CreateToken(new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier,user.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email,user.Data.Email)
            }, JwtTokenType.AccessToken);

        var refreshToken = _tokenFactoryService.CreateToken(new List<Claim>
            {
               new Claim("AccessToken",accessToken.Data.Token)

            }, JwtTokenType.RefreshToken);
        var result = new UserTokenDto()
        {
            AccessToken = accessToken.Data.Token,
            AccessTokenExpireTime = DateTimeOffset.UtcNow.AddMinutes(accessToken.Data.TokenExpirationMinutes),
            RefreshToken = refreshToken.Data.Token,
            RefreshTokenExpireTime = DateTimeOffset.UtcNow.AddMinutes(refreshToken.Data.TokenExpirationMinutes),
            User = new UserDto
            {
                Email = user.Data.Email,
                FullName = user.Data.FullName,
                Gender = user.Data.Gender,
                Nationality = user.Data.Nationality
            }
        };

        return result;
    }
}