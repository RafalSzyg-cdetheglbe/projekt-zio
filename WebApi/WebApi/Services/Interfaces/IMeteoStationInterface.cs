using WebApi.Models.DTO;

namespace WebApi.Services.Interfaces
{
    public interface IMeteoStationInterface
    {
        public MeteoStationDTO? GetMeteoStation(int id);
        public List<MeteoStationDTO>? GetAll();
        public List<MeteoStationListEntry> GetUserStationsListEntries(int userId);
        public int AddMeteoStation(MeteoStationDTO dto);
        public bool DeleteMeteoStation(int id);
        public void UpdateMeteoStation(MeteoStationDTO dto);
        public void AddNewMeteoData(int id, MeteoDataDTO dto);
        public void ChangeMeteoStationCoordinates(int id, double latitude, double longitude);
    }
}
