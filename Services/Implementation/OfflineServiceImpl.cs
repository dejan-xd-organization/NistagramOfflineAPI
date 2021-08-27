using NistagramSQLConnection.Model;
using NistagramSQLConnection.Service.Interface;
using NistagramUtils.DTO.WallPost;
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

        public List<WallPostDto> GetAllWallPosts(bool isPublic, int page, int limit)
        {
            List<bool> isPublics = new List<bool>();
            if (!isPublic)
            {
                isPublics.Add(true);
                isPublics.Add(false);
            }
            else isPublics.Add(true);

            List<WallPost> wallPost = _iPostService.GetAllWallPosts(isPublics, page, 20);
            List<WallPostDto> wallPostDto = new List<WallPostDto>(wallPost.Count);

            foreach (WallPost wp in wallPost)
            {
                wallPostDto.Add(new WallPostDto(wp));
            }

            return wallPostDto;
        }
    }
}
