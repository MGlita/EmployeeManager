using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Account.Commands.Requests
{
    public class RegisterReq : IRequest<Tuple<string, IdentityUser>>
    {
        public RegisterDto Model { get; set; }
    }
}
