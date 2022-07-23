using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryDTO>();
            CreateMap<Tag, TagDTO>();
            CreateMap<User, UserDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<PostCategory, PostCategoryDTO>();
            CreateMap<PostComment, CommentDTO>(); 
            CreateMap<Role, RoleDTO>();
        }
    }
}