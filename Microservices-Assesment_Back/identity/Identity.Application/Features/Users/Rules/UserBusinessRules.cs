using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Hashing;
using Identity.Application.Features.Users.Constants;
using Identity.Application.Services.Repositories;
using Identity.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Users.Rules;

public class UserBusinessRules : BaseBusinessRules
{
    private readonly IUserRepository _userRepository;


    public UserBusinessRules(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    private Task throwBusinessException(string messageKey)
    {
        throw new BusinessException(messageKey);
    }

    public async Task UserShouldBeExistsWhenSelected(User? user)
    {
        if (user == null)
            await throwBusinessException(UsersMessages.UserDontExists);
    }

    public async Task UserIdShouldBeExistsWhenSelected(Guid id)
    {
        bool doesExist = await _userRepository.AnyAsync(predicate: u => u.Id == id);
        if (doesExist)
            await throwBusinessException(UsersMessages.UserDontExists);
    }

    public async Task UserPasswordShouldBeMatched(User user, string password)
    {
        if (!HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            await throwBusinessException(UsersMessages.PasswordDontMatch);
    }

    public async Task UserEmailShouldNotExistsWhenInsert(string email)
    {
        bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Email == email);
        if (doesExists)
            await throwBusinessException(UsersMessages.UserMailAlreadyExists);
    }

    public async Task UserEmailShouldNotExistsWhenUpdate(Guid id, string email)
    {
        bool doesExists = await _userRepository.AnyAsync(predicate: u => u.Id != id && u.Email == email);
        if (doesExists)
            await throwBusinessException(UsersMessages.UserMailAlreadyExists);
    }
}

