﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SocialNetwork.IdentityServer.Core.Models.Input
{
    public class SignUpInput
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}