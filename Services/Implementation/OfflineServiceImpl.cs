using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace NistagramOfflineAPI.Services
{
    public class OfflineServiceImpl : IOfflineService
    {

        private readonly IPostService _iPostService;
        private readonly IUserService _iUserService;

        public OfflineServiceImpl(IPostService iPostService, IUserService iUserService)
        {
            _iPostService = iPostService;
            _iUserService = iUserService;
        }

        public List<User> FilterUser(string filter)
        {
            return _iUserService.FilterUser(filter);
        }

        public List<User> FindNewUsers()
        {
            return _iUserService.FindNewUsers();
        }

        public List<WallPost> GetAllWallPosts()
        {
            List<WallPost> wallPosts = _iPostService.GetAllWallPosts(false);
            foreach (WallPost wp in wallPosts)
            {
                var i = wp.userPosts.Select(x => x.userId).FirstOrDefault();
                User user = _iUserService.FindUserById(i, true);

                var j = wp.postReactions.Select(x => x.reactionId).ToList();
                List<Reaction> reactions = _iPostService.GetAllReactions(j);
            }
            return wallPosts;
        }
    }
}
