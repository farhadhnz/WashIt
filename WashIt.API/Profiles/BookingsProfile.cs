using AutoMapper;
using WashIt.API.DTOs;
using WashIt.API.Models;

namespace WashIt.API.Profiles
{
    public class BookingsProfile : Profile
    {
        public BookingsProfile()
        {
            CreateMap<BookingCreateDto, Booking>();
            CreateMap<Booking, BookingGetDto>();
        }

    }
}