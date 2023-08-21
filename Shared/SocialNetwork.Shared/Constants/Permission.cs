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

    public static class GatewayPermission
    {
        public const string ResourceGateway = "resource_gateway";
        public const string GatewayFullpermission = "gateway_fullpermission";
        public const string GatewayAuthenticationScheme = "GatewayAuthenticationScheme";
    }

    public class Client
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientName { get; set; }
    }

}
