﻿using B._SocialNetwork.Services.Graph.Core.Repositories;

namespace B._SocialNetwork.Services.Graph.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetGenericRepository<T>() where T : class;
        public IUserRepository userRepository { get; }
        public IPostRepository postRepository { get; }
        public ICommentRepository commentRepository { get; }
    }
}
