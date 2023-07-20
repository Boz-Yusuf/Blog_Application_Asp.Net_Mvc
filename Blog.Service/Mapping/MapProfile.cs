using AutoMapper;
using Blog.Core.DTOs;
using Blog.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<BlogContent, BlogContentDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserCredentials, UserCredentialsDto>().ReverseMap();
            CreateMap<UserCredentials, SignUpCredentialsDto>().ReverseMap();
        }
    }
}
