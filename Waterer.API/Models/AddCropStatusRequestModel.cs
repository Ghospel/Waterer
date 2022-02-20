using System.ComponentModel.DataAnnotations;

namespace Waterer.API.Models
{
    public class AddCropStatusRequestModel
    {
        [Required]
        public string CropId { get; set; }
        public float SoilMoisture { get; set; }
        public float Temperature { get; set; }
        public float RelativeHumidity { get; set; }
        public float Lux { get; set; }
    }
}
