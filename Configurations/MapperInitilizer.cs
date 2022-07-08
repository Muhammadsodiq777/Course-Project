using AutoMapper;
using Course_Project.Data;
using Course_Project.Models;

namespace HotelListing.Configurations
{
    public class MapperInitilizer: Profile
    {
        public MapperInitilizer()
        {
            CreateMap<ApiUser, UserDTO>().ReverseMap();
            
        }
    }
}
