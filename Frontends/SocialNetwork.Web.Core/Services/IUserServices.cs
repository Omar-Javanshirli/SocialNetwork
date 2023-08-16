﻿using SocialNetwork.Web.Core.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Web.Core.Services
{
    public interface IUserServices
    {
        Task<UserDto> GetUser();
    }
}
