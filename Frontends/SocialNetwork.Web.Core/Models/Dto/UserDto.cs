namespace SocialNetwork.Web.Core.Models.Dto
{
    public class UserDto
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }

        public IEnumerable<string> GetUserProps()
        {
            yield return UserName;
            yield return Email;
        }
    }
}
