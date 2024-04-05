using WebApi.Models.DTO;

namespace WebApi.Services.Interfaces
{
    public interface IMeteoStationInterface
    {
        public int AddMeteoStation(MeteoStationDTO dto);
        public bool DeleteMeteoStation(int id);
        public void UpdateMeteoStation(MeteoStationDTO dto);
        public void AddNewMeteoData(int id, MeteoDataDTO dto);
        public void ChangeMeteoStationCoordinates(int id, double latitude, double longitude);
    }
}
