namespace Waterer.API.Models
{
    public class CropStatusResponseModel
    {
        public DateTime CreatedDate { get; set; }
        public float SoilMoisture { get; set; }
        public float Temperature { get; set; }
        public float RelativeHumidity { get; set; }
        public float Lux { get; set; }
    }
}
