using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using RentFlatApi.Infrastructure.Context;
using RentFlatApi.Infrastructure.Model;

namespace RentFlatApi.Infrastructure.Repository
{
    public interface IFlatRepository : IRepository<Flat>
    {
    }

    public class FlatRepository : IFlatRepository
    {
        private readonly RentContext _rentContext;

        public FlatRepository(RentContext rentContext)
        {
            _rentContext = rentContext;
        }

        public async Task<IEnumerable<Flat>> GetAll()
        {
            var flats = await _rentContext.Flat.ToListAsync();
            flats.ForEach(x => { _rentContext.Entry(x).Reference(y => y.Address).LoadAsync(); });
            return flats;
        }

        public async Task<Flat> GetById(long id)
        {
            var flat = await _rentContext.Flat
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();
           
            try
            {
                await _rentContext.Entry(flat).Reference(x => x.Address).LoadAsync();
            }
            catch (ArgumentException e)
            {
               
                return null;
            }

            return flat;
        }

        public async Task Add(Flat flat)
        {
            flat.DateOfCreation = DateTime.Now;
            await _rentContext.Flat
                .Include(x => x.Address)
                .Include(x => x.Owner)
                .Include(x => x.Tenant)
                .Include(x => x.Images)
                .FirstAsync();
            await _rentContext.Flat.AddAsync(flat);
            await _rentContext.SaveChangesAsync();
        }

        public async Task Update(Flat entity)
        {
            var flatToUpdate = await _rentContext.Flat
                .Include(x => x.Address)
                .Include(x => x.Owner)
                .Include(x => x.Tenant)
                .SingleOrDefaultAsync(x => x.Id == entity.Id);

            if (flatToUpdate != null)
            {
                flatToUpdate.Owner = entity.Owner;
                flatToUpdate.Images = entity.Images;
                flatToUpdate.Tenant = entity.Tenant;
                flatToUpdate.Floor = entity.Floor;
                flatToUpdate.Price = entity.Price;
                flatToUpdate.District = flatToUpdate.District;
                flatToUpdate.IsElevator = flatToUpdate.IsElevator;
                flatToUpdate.SquareMeters = flatToUpdate.SquareMeters;
                flatToUpdate.NumberOfRooms = flatToUpdate.SquareMeters;
                flatToUpdate.DateOfUpdate = DateTime.Now;

                if (entity.Address != null && flatToUpdate.Address != null)
                {
                    entity.Address.Id = flatToUpdate.Address.Id;
                        _rentContext.Entry(flatToUpdate.Address).CurrentValues.SetValues(entity.Address);
                    }
    
                    if (entity.Owner != null && flatToUpdate.Owner != null)
                    {
                        entity.Owner.Id = flatToUpdate.Owner.Id;
                        _rentContext.Entry(flatToUpdate.Owner).CurrentValues.SetValues(entity.Owner);
                    }
    
                    if (entity.Tenant != null && flatToUpdate.Tenant != null)
                    {
                        entity.Tenant.Id = flatToUpdate.Tenant.Id;
                        _rentContext.Entry(flatToUpdate.Tenant).CurrentValues.SetValues(entity.Tenant);
                    }
    
                    if (flatToUpdate.Images != null && entity.Images != null)
                    {
                        var imagesToUpdate = flatToUpdate.Images.ToList();
                        foreach (var image in imagesToUpdate)
                        {
                            foreach (var entityImage in entity.Images)
                            {
                                if (image.Id == entityImage.Id)
                                {
                                    _rentContext.Entry(imagesToUpdate).CurrentValues.SetValues(entity.Images);
                                }
                            }
                        }
                    }
    
                    await _rentContext.SaveChangesAsync();
            }
        }

        public async Task Delete(long id)
        {
            var flatToDelete = await _rentContext.Flat.SingleOrDefaultAsync(flat => flat.Id == id);
            if (flatToDelete != null)
            {
                _rentContext.Flat.Remove(flatToDelete);
                await _rentContext.SaveChangesAsync();
            }
        }
    }
}