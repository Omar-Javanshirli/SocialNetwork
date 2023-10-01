namespace SocialNetwork.WEB.Core.Models.Settings
{
    public class ClientSetting
    {
        public Client WebClient { get; set; } = null!;
        public Client WebClientForUser { get; set; } = null!;


        public class Client
        {
            public string ClientId { get; set; } = null!;
            public string ClientSecret { get; set; } = null!;
        }
    }
}
