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
    public class AccountQueryHandler : IRequestHandler<LoginReq, Tuple<string, IdentityUser>>
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountQueryHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Tuple<string, IdentityUser>> Handle(LoginReq request, CancellationToken cancellationToken)
        {
            var result = await _signInManager.PasswordSignInAsync(request.Model.Email, request.Model.Password, false, false);

            if (result.Succeeded)
            {
                var appUser = _userManager.Users.SingleOrDefault(r => r.Email == request.Model.Email);
                return new Tuple<string, IdentityUser>(request.Model.Email, appUser);
            }

            throw new ApplicationException("INVALID_LOGIN_ATTEMPT");
        }
    }
}
