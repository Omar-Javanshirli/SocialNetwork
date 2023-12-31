﻿using IdentityModel;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using SocialNetwork.IdentityServer.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkIdentityServer.Service.Validators
{
    public class IdentityResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly UserManager<ApplicationUser> userManager;

        public IdentityResourceOwnerPasswordValidator(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var existUser = await userManager.FindByEmailAsync(context.UserName);

            if (existUser == null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email or password is wrong" });
                context.Result.CustomResponse = errors;
                return;
            }

            var passwordCheck = await userManager.CheckPasswordAsync(existUser, context.Password);

            if (passwordCheck == false)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("errors", new List<string> { "Email or password is wrong" });
                context.Result.CustomResponse = errors;
                return;
            }

            //Grand type =>  Resource Owner Credentials
            context.Result = new GrantValidationResult(existUser.Id.ToString(), OidcConstants.AuthenticationMethods.Password);
        }
    }
}
