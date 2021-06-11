using AutoMapper;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;

namespace Web.Data.Profiles
{
    public class OnboardingProfiles : Profile
    {
        public OnboardingProfiles()
        {
            CreateMap<IncomingOnboardingRequest, User>()
                .ForMember(to => to.ProfilePicture, 
                    from => from.Ignore())
                .ForMember(to => to.CompletedOnboarding, 
                    from => from.MapFrom(src => false));
        }
    }
}