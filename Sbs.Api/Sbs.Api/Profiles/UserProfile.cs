using AutoMapper;
using Sbs.Api.Data.Entities;
using Sbs.Api.Models;

namespace Sbs.Api.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserModel, User>();
        }
    }
}
