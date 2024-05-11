using WebApi.Models.DbEntities.MeteoEntities;

namespace WebApi.Models.DTO
{
    public class MeteoStationDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UserDTO? Creator { get; set; }
        public List<MeteoDataDTO>? MeteoData { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public AuditDataDTO? AuditData { get; set; }

        public MeteoStationDTO() { }

        public MeteoStationDTO(int id, string? name, UserDTO? creator, List<MeteoDataDTO>? meteoData, double latitude, double longitude)
        {
            Id = id;
            Name = name;
            Creator = creator;
            MeteoData = meteoData;
            Latitude = latitude;
            Longitude = longitude;
        }

        public MeteoStationDTO(MeteoStation meteoStation)
        {
            Id = meteoStation.Id;
            Name = meteoStation.Name;
            if (meteoStation.Creator != null)
                Creator = new UserDTO(meteoStation.Creator);
            if (meteoStation.MeteoData != null && meteoStation.MeteoData.Count() > 0)
                MeteoData = meteoStation.MeteoData.Select(x => new MeteoDataDTO(x)).ToList();
            Longitude = meteoStation.Longitude;
            Latitude = meteoStation.Latitude;
        }
    }

    public class MeteoStationListEntry
    {
        public MeteoStationListEntry() { }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Coordinates { get; set; }
        public string? AuditData { get; set; }
    }
}
