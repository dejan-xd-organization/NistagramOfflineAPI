using System.Collections.Generic;
using NistagramSQLConnection.Model;
using NistagramUtils.DTO;
using NistagramUtils.DTO.WallPost;

namespace NistagramOfflineAPI.Services
{
    public interface IOfflineService
    {
        List<User> FilterUser(string filter);
        List<User> FindNewUsers();
        List<WallPostDto> GetAllWallPosts(bool isPublic, int page, int limit);
        UserDto FindUserById(long id, bool isPublicProfile);
    }
}
