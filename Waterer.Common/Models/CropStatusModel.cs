namespace Waterer.API.Models
{
    public class CropStatusModel
    {
        public string? Id { get; set; }
        public string? CropModelId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public float SoilMoisture { get; set; }
        public float Temperature { get; set; }
        public float RelativeHumidity { get; set; }
        public float Lux { get; set; }
    }
}