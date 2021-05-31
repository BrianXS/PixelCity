using AutoMapper;
using Web.Data.Entities;
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
    
    public class OnboardingProfiles : Profile
    {
        public OnboardingProfiles()
        {
            CreateMap<IncomingOnboardingRequest, User>()
                .ForMember(to => to.ProfilePicture, 
                    from => from.Ignore())
                .ForMember(to => to.CompletedOnboarding, 
                    from => from.MapFrom(src => true));
        }
    }
}