﻿namespace BlackBoot.Services.Interfaces;

public interface IUserService : IScopedDependency
{
    Task<IActionResponse<User>> GetAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IActionResponse<User>> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
    IActionResponse<bool> CheckPassword(User user, string password, CancellationToken cancellationToken = default);
}