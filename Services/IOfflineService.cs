using NistagramSQLConnection.Model;
using System.Collections.Generic;

namespace NistagramOfflineAPI.Services
{
    public interface IOfflineService
    {
        List<User> FilterUser(string filter);
        List<User> FindNewUsers();
        List<WallPost> GetAllWallPosts();
    }
}
