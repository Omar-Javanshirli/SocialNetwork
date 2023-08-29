namespace D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response
{
    public class GetAllCommentLikeResponse
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid CommentId { get; set; }
    }
}
