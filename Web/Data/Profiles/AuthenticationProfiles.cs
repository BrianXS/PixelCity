using AutoMapper;
using Web.Data.ViewModels.Incoming;
using Web.Data.ViewModels.Outgoing;

namespace Web.Data.Profiles
{
    public class AuthenticationProfiles : Profile
    {
        public AuthenticationProfiles()
        {
            CreateMap<IncomingUserData, OutgoingUserData>();
            CreateMap<IncomingRegistrationData, OutgoingRegistrationData>();

            CreateMap<IncomingPasswordRecoveryDataFromEmail, OutgoingPasswordRecoveryData>();
        }
    }
}