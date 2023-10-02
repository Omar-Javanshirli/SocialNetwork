using AutoMapper;
using B._SocialNetwork.Services.Graph.Core.Entities.CommentEntity;
using B._SocialNetwork.Services.Graph.Core.Entities.PostEntity;
using D._SocialNetwork.Services.Graph.Services.CQRS.Comment.Quries.Response;
using D._SocialNetwork.Services.Graph.Services.CQRS.Post.Queries.Response;
using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response;

namespace D._SocialNetwork.Services.Graph.Services.Mapping
{
    public class MapProfil : Profile
    {
        public MapProfil()
        {
            CreateMap<Post, GetAllUserPostsQueryResponse>().ReverseMap();
            CreateMap<PostLike, GetAllUsersPostLikeQueryResponse>().ReverseMap();
            CreateMap<Comment, GetAllCommentPostResponse>().ReverseMap();
            CreateMap<CommentLike,GetAllCommentLikeResponse>().ReverseMap();
        }
    }
}
