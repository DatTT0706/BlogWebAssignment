using AutoMapper;
using BussinessModel;
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
            CreateMap<DataAccess.Models.Category, CategoryDTO>();
            CreateMap<DataAccess.Models.Post, PostDTO>();
            CreateMap<DataAccess.Models.Tag, TagDTO>();
            CreateMap<DataAccess.Models.User, UserDTO>();
            CreateMap<BussinessModel.PostComment, CommentDTO>();
            CreateMap<Role, RoleDTO>();
        }
    }
}
