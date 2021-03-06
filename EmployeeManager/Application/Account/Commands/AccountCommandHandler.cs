﻿using Application.Account.Commands.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Commands
{
    public class AccountCommandHandler : IRequestHandler<RegisterReq, Tuple<string, IdentityUser, string>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Tuple<string, IdentityUser, string>> Handle(RegisterReq request, CancellationToken cancellationToken)
        {
            var user = new IdentityUser
            {
                UserName = request.Model.Email,
                Email = request.Model.Email
            };
            var result = await _userManager.CreateAsync(user, request.Model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "HR"/*request.Model.Role*/);
                await _signInManager.SignInAsync(user, false);
                return new Tuple<string, IdentityUser, string>(request.Model.Email, user, request.Model.Role);
            }
            
            throw new Exception(result.Errors.FirstOrDefault().Description);
        }
    }
}
