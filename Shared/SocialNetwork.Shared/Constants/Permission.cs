public static class Permission
{
    public static class GraphPermission
    {
        public const string resourseGraph = "resourse_graph";
        public const string graphFullpermission = "graph_fullpermission";
    }

    public static class ClientPermission
    {
        public static readonly Client SocialNetworkWeb = new Client
        {
            ClientName = "Social_Network_Web",
            ClientId = "Web_Client_ForUser",
            ClientSecret = "secret"
        };

    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientName { get; set; }
    }

}
