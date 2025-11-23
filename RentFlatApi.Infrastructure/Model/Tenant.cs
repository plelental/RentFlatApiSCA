namespace RentFlatApi.Infrastructure.Model
{
    public class Tenant : Person
    {
        public Flat Flat { get; set; }        
    }
}