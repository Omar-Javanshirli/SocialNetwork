﻿namespace SocialNetwork.Web.Core.Models.Dto
{
    public class UserDto
    {
        public string Id { get; set; } = null!;
        public string UserName { get; set; }=null!;
        public string Email { get; set; } = null!;

        public IEnumerable<string> GetUserProps()
        {
            yield return UserName;
            yield return Email;
        }
    }
}
