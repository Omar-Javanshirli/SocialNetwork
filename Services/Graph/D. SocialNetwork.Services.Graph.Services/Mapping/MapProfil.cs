using AutoMapper;
using B._SocialNetwork.Services.Graph.Core.Entities.PostsEntity;
using D._SocialNetwork.Services.Graph.Services.CQRS.User.Queries.Response;

namespace D._SocialNetwork.Services.Graph.Services.Mapping
{
    public class MapProfil:Profile
    {
        public MapProfil()
        {
            CreateMap<Post, GetAllUserPostsQueryResponse>().ReverseMap();
        }
    }
}
