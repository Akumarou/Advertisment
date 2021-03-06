﻿using System.Threading;
using System.Threading.Tasks;
using Advertisement.Application.Services.User.Contracts;

namespace Advertisement.Application.Services.User.Interfaces
{
    public interface IUserService
    {
        Task<Domain.User> GetCurrent(CancellationToken cancellationToken);

        Task<Login.Response> Login(Login.Request request, CancellationToken cancellationToken);
        Task<Register.Response> Register(Register.Request request, CancellationToken cancellationToken);
    }
}