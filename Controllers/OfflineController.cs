using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NistagramOfflineAPI.Services;
using NistagramSQLConnection.Model;
using NistagramUtils.DTO;
using NistagramUtils.DTO.WallPost;

namespace NistagramOfflineAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            List<UserDto> userDTO = _mapper.Map<List<UserDto>>(user);
            return JsonConvert.SerializeObject(userDTO);
        }

        [HttpGet]
        [Route("/[action]")]
        public Object FindNewUsers()
        {
            List<User> user = _iOfflineService.FindNewUsers();
            List<UserDto> userDTO = _mapper.Map<List<UserDto>>(user);
            return JsonConvert.SerializeObject(userDTO);
        }

        [HttpGet]
        [Route("/[action]")]
        public Object GetAllWallPosts()
        {
            List<WallPostDto> wallPostDto = _iOfflineService.GetAllWallPosts(true, 1, 20);
            return JsonConvert.SerializeObject(wallPostDto);
        }

        [HttpGet]
        [Route("/[action]")]
        public Object FindUserById(long id, bool isPublicProfile)
        {
            UserDto userDto = _iOfflineService.FindUserById(id, isPublicProfile);
            return JsonConvert.SerializeObject(userDto);
        }
    }
}
