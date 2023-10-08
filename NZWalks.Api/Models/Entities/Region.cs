namespace NZWalks.Api.Models.Entities
{
    public class Region
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Area { get; set; } = 0;
        public double Latitude { get; set; } = 0;
        public double Longitude { get; set; } = 0;
        public long Population { get; set; } = 0;
        public string? RegionImageUrl { get; set; }

        //navigation properties - connection of entities
        //public IEnumerable<Walk> Walk { get; set; }

    }
}
