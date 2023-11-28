using AutoMapper;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.RegisterDto;
using HotelProject.WebUI.Dtos.LoginDto;
using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.Testimonial;
using HotelProject.WebUI.Dtos.StaffDto;
using HotelProject.WebUI.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.BookingDto;
using HotelProject.WebUI.Dtos.ContactDto;

namespace HotelProject.WebUI.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<CreateServiceDto, Service>().ReverseMap();

            CreateMap<CreateNewUserDto,AppUser>().ReverseMap(); 
            CreateMap<LoginUserDto,AppUser>().ReverseMap(); 

            CreateMap<ResultAboutDto,About>().ReverseMap();
            CreateMap<UpdateAboutDto,About>().ReverseMap();

            CreateMap<ResultRoomDto,Room>().ReverseMap();
            
            CreateMap<ResultTestimonialDto,Testimonial>().ReverseMap();
            CreateMap<ResultStaffDto,Staff>().ReverseMap(); 
            CreateMap<CreateSubscribeDto,Subscribe>().ReverseMap();

            CreateMap<CreateBookingDto,Booking>().ReverseMap();
            CreateMap<ApproveReservationDto,Booking>().ReverseMap();

            CreateMap<CreateContactDto,Contact>().ReverseMap();
        }
    }
}
