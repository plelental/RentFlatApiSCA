using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using RentFlatApi.Contract.FlatDto;
using RentFlatApi.Core.Services.Mappers;
using RentFlatApi.Infrastructure.Model;
using RentFlatApi.Infrastructure.Repository;

namespace RentFlatApi.Core.Services
{
    public interface IFlatService : IService<FlatDto>
    {
    }

    public class FlatService : IFlatService
    {
        private readonly IFlatRepository _iFlatRepository;

        public FlatService(IFlatRepository iFlatRepository)
        {
            _iFlatRepository = iFlatRepository;
        }

        public async Task<IEnumerable<FlatDto>> GetAll()
        {
            var flats = await _iFlatRepository.GetAll();
            return flats
                .Select(FlatMapper.MapFlatToDto)
                .ToList();
        }

        public async Task<FlatDto> GetById(long id)
        {
            var flat = await _iFlatRepository.GetById(id);
            return FlatMapper.MapFlatToDto(flat);
        }

        public async Task Add(FlatDto flat)
        {
            await _iFlatRepository.Add(FlatMapper.MapDtoToFlat(flat));
        }

        public async Task Update(FlatDto entity)
        {
            await _iFlatRepository.Update(FlatMapper.MapDtoToFlat(entity));
        }

        public async Task Delete(long id)
        {
            await _iFlatRepository.Delete(id);
        }
    }
}