using WebApi.Models.DbEntities.AuditAndContext;
using WebApi.Models.DbEntities.MeteoEntities;
using WebApi.Models.DTO;
using WebApi.Services.Interfaces;

namespace WebApi.Services.Implementations
{
    public class MeteoStationService : IMeteoStationInterface
    {
        private readonly MeteoContext _dbContext;
        public MeteoStationService(MeteoContext meteoContext)
        {
            this._dbContext = meteoContext;
        }
        public int AddMeteoStation(MeteoStationDTO dto)
        {
            return dto != null ? AddNewStation(dto) : -1;
        }

        public void AddNewMeteoData(int id, MeteoDataDTO dto)
        {
            var station = this._dbContext?.MeteoStations?.FirstOrDefault(x => x.Id == id);
            if (station != null && dto != null)
            {
                var meteoData = CreateAndReturnMeteoData(dto);
                if (station.MeteoData == null)
                    station.MeteoData = new List<MeteoData>();
                station.MeteoData.Add(meteoData);
                this._dbContext?.Update(station);
                this._dbContext?.SaveChanges();
            }
        }

        public void ChangeMeteoStationCoordinates(int id, double latitude, double longitude)
        {
            var station = this._dbContext?.MeteoStations?.FirstOrDefault(x => x.Id == id);
            if (station != null)
            {
                station.Latitude = latitude;
                station.Longitude = longitude;
                this._dbContext?.Update(station);
                this._dbContext?.SaveChanges();
            }
        }

        public bool DeleteMeteoStation(int id)
        {
            var station = this._dbContext?.MeteoStations?.FirstOrDefault(x => x.Id == id);
            if (station != null)
            {
                this._dbContext?.MeteoStations?.Remove(station);
                this._dbContext?.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateMeteoStation(MeteoStationDTO dto)
        {
            if (dto != null && dto.Id >= 0)
            {
                var meteoStation = this._dbContext?.MeteoStations?.FirstOrDefault(x => x.Id == dto.Id);
                if (meteoStation != null)
                {
                    UpdateMeteoStation(meteoStation, dto);
                    this._dbContext?.Update(meteoStation);
                }
            }
        }

        private void UpdateMeteoStation(MeteoStation meteoStation, MeteoStationDTO dto)
        {
            AddUser(meteoStation, dto);
            FillBasicStationInfo(meteoStation, dto);
            UpdateMeteoData(meteoStation, dto);
        }

        private int AddNewStation(MeteoStationDTO dto)
        {
            var station = new MeteoStation();
            AddUser(station, dto);
            FillBasicStationInfo(station, dto);
            FillMeteoData(station, dto);

            return station.Id;
        }

        private void AddUser(MeteoStation station, MeteoStationDTO dto)
        {
            if (dto.Creator != null)
            {
                var creator = this._dbContext?.Users?.FirstOrDefault(x => x.Id == dto.Creator.Id);
                if (creator != null)
                    station.Creator = creator;
            }
        }

        private void FillBasicStationInfo(MeteoStation station, MeteoStationDTO dto)
        {
            station.Latitude = dto.Latitude;
            station.Longitude = dto.Longitude;
            station.Name = dto.Name;
        }

        private void FillMeteoData(MeteoStation station, MeteoStationDTO dto)
        {
            if (dto.MeteoData != null && dto.MeteoData.Count() > 0)
            {
                station.MeteoData = new List<MeteoData>();
                foreach (var data in dto.MeteoData)
                    station.MeteoData.Add(CreateAndReturnMeteoData(data));
            }
        }

        private void UpdateMeteoData(MeteoStation station, MeteoStationDTO dto)
        {
            if (dto.MeteoData == null || dto.MeteoData.Count() == 0)
                RemoveAllDataFromStation(station);
            else
            {
                if (station.MeteoData == null || station.MeteoData.Count() == 0)
                {
                    station.MeteoData = new List<MeteoData>();
                    foreach (var data in dto.MeteoData)
                        station.MeteoData.Add(CreateAndReturnMeteoData(data));
                }
                else
                    UpdateExistingMeteoDataList(station, dto.MeteoData);
            }

        }

        private void UpdateExistingMeteoDataList(MeteoStation station, List<MeteoDataDTO> dataDto)
        {
            var dtoIds = dataDto.Select(x => x.Id).ToList();
            var toRemove = station.MeteoData?.Where(x => !dtoIds.Contains(x.Id)).ToList();

            if (toRemove != null)
            {
                foreach (var data in toRemove)
                {
                    station.MeteoData?.Remove(data);
                    this._dbContext.Remove(data);
                    this._dbContext.SaveChanges();
                }
            }
            var stationIds = station.MeteoData?.Select(x => x.Id).ToList();
            if (stationIds != null && stationIds.Count() > 0)
            {
                var toAdd = dataDto.Where(x => !stationIds.Contains(x.Id)).ToList();
                foreach (var data in toAdd)
                    station.MeteoData?.Add(CreateAndReturnMeteoData(data));
            }
            else
            {
                foreach (var data in dataDto)
                    station.MeteoData?.Add(CreateAndReturnMeteoData(data));
            }
        }

        private void RemoveAllDataFromStation(MeteoStation station)
        {
            if (station.MeteoData != null && station.MeteoData.Count() > 0)
            {
                foreach (var data in station.MeteoData)
                    this._dbContext.Remove(data);
                station.MeteoData = new List<MeteoData>();
            }
        }

        private MeteoData CreateAndReturnMeteoData(MeteoDataDTO dto)
        {
            var audit = new BaseAuditData() { CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now };
            this._dbContext?.BaseAudits?.Add(audit);
            this._dbContext?.SaveChanges();

            var meteoData = new MeteoData(dto, audit);
            this._dbContext?.MeteoData?.Add(meteoData);
            this._dbContext.SaveChanges();

            return meteoData;
        }
    }
}
