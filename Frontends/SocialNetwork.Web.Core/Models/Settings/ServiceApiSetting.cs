namespace SocialNetwork.Web.Core.Models.Settings
{
    public class ServiceApiSetting
    {
        public string IdentityBaseUri { get; set; } = null!;
        public string GetewayBaseUri { get; set; } = null!;
        public ServiceApi Discover { get; set; }=null!;
        public ServiceApi Feed { get; set; }= null!;
        public ServiceApi Graph { get; set; } = null!;
        public ServiceApi Live { get; set; } = null!;
        public ServiceApi Media { get; set; } = null!;
        public ServiceApi Message { get; set; } = null!;
        public ServiceApi Notification { get; set; } = null!;
        public ServiceApi Post { get; set; } = null!;
        public ServiceApi Search { get; set; } = null!;
        public ServiceApi Profil { get; set; } = null!;
        public ServiceApi Story { get; set; } = null!;

        public class ServiceApi
        {
            public string Path { get; set; } = null!;
        }
    }
}
