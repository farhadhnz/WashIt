using AutoMapper;
using WashIt.API.DTOs;
using WashIt.API.Models;

namespace WashIt.API.Profiles
{
    public class WaitListProfile : Profile
    {
        public WaitListProfile()
        {
            CreateMap<WaitingListDto, WaitingListItem>();
        }

    }
}