using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApi.Models.DbEntities.UserEntities;

namespace WebApi.Models.DbEntities.MeteoEntities
{
    public class MeteoStation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public User? Creator { get; set; }
        [ForeignKey(nameof(UserId))]
        public int? UserId { get; set; }
        public int CreatorId { get; set; }
        public IEnumerable<MeteoData>? MeteoData { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
