using System;
using AutoMapper;
using Web.Data.Entities;
using Web.Data.ViewModels.Incoming;
using Web.Data.ViewModels.Outgoing;
using Web.Util.Transformers;

namespace Web.Data.Profiles
{
    public class SettingsProfile : Profile
    {
        public SettingsProfile()
        {
            CreateMap<User, OutgoingUserUpdateResponse>();
            CreateMap<IncomingUserUpdateRequest, User>()
                .ForMember(to => to.BirthDate,
                    from
                        => from.Ignore());
        }
    }
}