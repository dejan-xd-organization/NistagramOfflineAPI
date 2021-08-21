using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NistagramSQLConnection.Model;

namespace NistagramOfflineAPI.Services
{
    public interface IOfflineService
    {
        List<User> FilterUser(string filter);
        List<User> FindNewUsers();
        List<WallPost> GetAllWallPosts();
    }
}
