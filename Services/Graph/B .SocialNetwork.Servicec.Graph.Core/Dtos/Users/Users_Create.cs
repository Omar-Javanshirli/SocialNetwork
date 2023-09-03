namespace B_.SocialNetwork.Servicec.Graph.Core.Dtos
{
    public class Users_Create
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
