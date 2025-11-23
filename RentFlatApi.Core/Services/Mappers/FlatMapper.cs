using RentFlatApi.Contract.FlatDto;
using RentFlatApi.Infrastructure.Model;

namespace RentFlatApi.Core.Services.Mappers
{
    internal static class FlatMapper
    {
        public static FlatDto MapFlatToDto(Flat flat)
        {
            return new FlatDto()
            {
                City = flat.Address?.City,
                Floor = flat.Floor,
                Price = flat.Price,
                District = flat.District,
                IsElevator = flat.IsElevator,
                SquareMeters = flat.SquareMeters,
                NumberOfRooms = flat.NumberOfRooms,
                Street = flat.Address?.Street,
                ZipCode = flat.Address?.ZipCode,
                Id = flat.Id
            };
        }

        public static Flat MapDtoToFlat(FlatDto flat)
        {
            return new Flat()
            {
                Floor = flat.Floor.GetValueOrDefault(),
                Price = flat.Price.GetValueOrDefault(),
                District = flat.District,
                IsElevator = flat.IsElevator,
                SquareMeters = flat.SquareMeters.GetValueOrDefault(),
                NumberOfRooms = flat.NumberOfRooms.GetValueOrDefault(),
                Id = flat.Id.GetValueOrDefault(),
                Address = new Address()
                { 
                    City = flat.City,
                    Street = flat.Street,
                    ZipCode = flat.ZipCode,
                }
            };
        }
    }
}