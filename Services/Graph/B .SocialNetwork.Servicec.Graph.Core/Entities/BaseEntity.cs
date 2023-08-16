namespace B._SocialNetwork.Services.Graph.Core.Entities
{
    public class BaseEntity
    {
        public string Id { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
