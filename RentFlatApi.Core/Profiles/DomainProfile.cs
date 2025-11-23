using AutoMapper;
using RentFlatApi.Contract.FlatDto;
using RentFlatApi.Infrastructure.Model;

namespace RentFlatApi.Core.Profiles
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<FlatDto, Flat>()
                .ForMember(x => x.Images, opt => opt.Ignore())
                .ForMember(x => x.DateOfUpdate, opt => opt.Ignore())
                .ForMember(x => x.DateOfCreation, opt => opt.Ignore())
                .ForMember(x => x.Id, opt => opt.Ignore());

            CreateMap<FlatDto, Address>()
                .ForMember(x => x.City, opt => opt.MapFrom(y => y.City));

            CreateMap<Flat, FlatDto>()
                .ForMember(x => x.City, opt => opt.MapFrom(y => y.Address.City));
        }
    }
}