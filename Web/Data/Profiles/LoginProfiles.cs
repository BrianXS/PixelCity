using AutoMapper;
using Web.Data.ViewModels.Incoming;
using Web.Data.ViewModels.Outgoing;

namespace Web.Data.Profiles
{
    public class LoginProfiles : Profile
    {
        public LoginProfiles()
        {
            CreateMap<IncomingUserData, OutgoingUserData>();
            CreateMap<IncomingRegistrationData, OutgoingRegistrationData>();
        }
    }
}