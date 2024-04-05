using WebApi.Models.DbEntities.MeteoEntities;

namespace WebApi.Models.DTO
{
    public class MeteoStationDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public UserResponseDTO? Creator { get; set; }
        public IEnumerable<MeteoDataDTO>? MeteoData { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public MeteoStationDTO(int id, string? name, UserResponseDTO? creator, IEnumerable<MeteoDataDTO>? meteoData, double latitude, double longitude)
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
                Creator = new UserResponseDTO(meteoStation.Creator);
            if (meteoStation.MeteoData != null && meteoStation.MeteoData.Count() > 0)
                MeteoData = meteoStation.MeteoData.Select(x => new MeteoDataDTO(x)).ToList();
        }
    }
}
