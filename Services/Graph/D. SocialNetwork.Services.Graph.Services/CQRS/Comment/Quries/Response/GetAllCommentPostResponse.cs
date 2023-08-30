namespace D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response
{
    public class GetAllCommentPostResponse
    {
        public string CommentText { get; set; } = null!;
        public string? ParentCommentId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
    }
}
