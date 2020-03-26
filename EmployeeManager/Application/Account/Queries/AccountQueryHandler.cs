using Application.Account.Queries.Requests;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Account.Queries
{
    public class AccountQueryHandler : IRequestHandler<LoginReq, Tuple<string, IdentityUser, string>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountQueryHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Tuple<string, IdentityUser, string>> Handle(LoginReq request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Model.Email, request.Model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = await _userManager.FindByEmailAsync(request.Model.Email);
                var roles = await _userManager.GetRolesAsync(appUser);
                return new Tuple<string, IdentityUser, string>(request.Model.Email, appUser, roles.FirstOrDefault());
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
    }
}
