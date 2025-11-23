namespace RentFlatApi.Contract.FlatDto
{
    public class FlatDto
    {
        public decimal? Price { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public int? NumberOfRooms { get; set; }
        public int? SquareMeters { get; set; }
        public int? Floor { get; set; }
        public bool IsElevator { get; set; }
        public long? Id { get; set; }    
    }
}