namespace B._SocialNetwork.Services.Graph.Core.Dtos.Users
{
    public class User_CreateDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
