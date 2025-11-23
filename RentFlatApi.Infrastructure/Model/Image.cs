using System.ComponentModel.DataAnnotations;

namespace RentFlatApi.Infrastructure.Model
{
    public class Image : Entity
    {
        public byte[] Data { get; set; }
        public Flat Flat { get; set; }
    }
}