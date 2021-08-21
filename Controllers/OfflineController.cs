using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramOfflineAPI.Services;
using NistagramSQLConnection.Model;
using NistagramUtils.DTO;
using NistagramUtils.DTO.WallPost;

namespace NistagramOfflineAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfflineController : ControllerBase
    {

        private readonly IOfflineService _iOfflineService;
        private readonly IMapper _mapper;

        public OfflineController(IOfflineService iOfflineService, IMapper mapper)
        {
            _iOfflineService = iOfflineService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("/[action]")]
        public Object FilterUser(string filter)
        {
            List<User> user = _iOfflineService.FilterUser(filter);
            List<UserDTO> userDTO = _mapper.Map<List<UserDTO>>(user);
            return JsonConvert.SerializeObject(userDTO);
        }

        [HttpGet]
        [Route("/[action]")]
        public Object FindNewUsers()
        {
            List<User> user = _iOfflineService.FindNewUsers();
            List<UserDTO> userDTO = _mapper.Map<List<UserDTO>>(user);
            return JsonConvert.SerializeObject(userDTO);
        }

        [HttpGet]
        [Route("/[action]")]
        public Object GetAllPosts()
        {
            List<WallPost> post = _iOfflineService.GetAllWallPosts();
            List<WallPostDTO> postDTO = _mapper.Map<List<WallPostDTO>>(post);
            return JsonConvert.SerializeObject(postDTO);
        }
    }
}
