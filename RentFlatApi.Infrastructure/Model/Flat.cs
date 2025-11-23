using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RentFlatApi.Infrastructure.Model
{
    public class Flat : Entity
    {
        public decimal Price { get; set; }
        public Address Address { get; set; }
        public string District { get; set; }
        public int NumberOfRooms { get; set; }
        public int SquareMeters { get; set; }
        public IEnumerable<Image> Images { get; set; }
        public int Floor { get; set; }
        public bool IsElevator { get; set; }
        public Owner Owner { get; set; }
        public Tenant Tenant { get; set; }
    }
}