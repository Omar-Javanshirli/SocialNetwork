namespace B_.SocialNetwork.Servicec.Graph.Core.Dtos
{
    public class User_CreateDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
