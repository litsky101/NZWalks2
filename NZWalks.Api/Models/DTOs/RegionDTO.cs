namespace NZWalks.Api.Models.DTOs
{
    public class RegionDTO
    {
        public Guid Id { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public double Area { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long Population { get; set; }
    }
}
