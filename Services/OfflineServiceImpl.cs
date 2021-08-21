using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;

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
            return _iPostService.GetAllWallPosts(false);
        }
    }
}
