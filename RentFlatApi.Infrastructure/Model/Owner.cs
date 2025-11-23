using System.Collections.Generic;

namespace RentFlatApi.Infrastructure.Model
{
    public class Owner : Person
    {
        public List<Flat> Flats { get; set; }
    }
}