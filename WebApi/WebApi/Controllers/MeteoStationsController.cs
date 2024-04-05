using Microsoft.AspNetCore.Mvc;
using WebApi.Models.DTO;
using WebApi.Services.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeteoStationsController : ControllerBase
    {
        private readonly IMeteoStationInterface _meteoStationService;

        public MeteoStationsController(IMeteoStationInterface meteoStationService)
        {
            _meteoStationService = meteoStationService;
        }

        [HttpPost]
        public ActionResult<int> AddMeteoStation(MeteoStationDTO dto)
        {
            var stationId = _meteoStationService.AddMeteoStation(dto);
            return stationId >= 0 ? (ActionResult<int>)Ok(stationId) : BadRequest();
        }

        [HttpPost("{id}/data")]
        public IActionResult AddMeteoData(int id, MeteoDataDTO dto)
        {
            _meteoStationService.AddNewMeteoData(id, dto);
            return Ok();
        }

        [HttpPut("{id}/coordinates")]
        public IActionResult UpdateMeteoStationCoordinates(int id, [FromBody] CoordinatesDTO coordinates)
        {
            _meteoStationService.ChangeMeteoStationCoordinates(id, coordinates.Latitude, coordinates.Longitude);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateMeteoStation(int id, MeteoStationDTO dto)
        {
            _meteoStationService.UpdateMeteoStation(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMeteoStation(int id)
        {
            var success = _meteoStationService.DeleteMeteoStation(id);
            return success ? (IActionResult)Ok() : NotFound();
        }
    }
}
