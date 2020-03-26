using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Account.Queries.Requests
{
    public class LoginReq : IRequest<Tuple<string, IdentityUser, string>>
    {
        public LoginDto Model { get; set; }
    }
}
