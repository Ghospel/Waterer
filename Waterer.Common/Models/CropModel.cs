namespace Waterer.API.Models
{
    public class CropModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; } = DateTime.Now;
        public IEnumerable<CropStatusModel> CropStatuses { get; set; } = Enumerable.Empty<CropStatusModel>();
    }
}
