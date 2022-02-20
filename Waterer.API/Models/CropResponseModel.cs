using Waterer.Data.Entities;

namespace Waterer.API.Models
{
    public class CropResponseModel
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public DateTime? CreatedDate { get; set; }
        public IEnumerable<CropStatusResponseModel> CropStatuses { get; set; }
    }
}
