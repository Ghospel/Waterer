using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waterer.Data.Entities
{
    public class CropStatusEntity
    {
        public string? Id { get; set; }
        public string CropEntityId { get; set; }
        public CropEntity CropEntity { get; set; }
        public DateTime CreatedDate { get; set; }
        public float SoilMoisture { get; set; }
        public float Temperature { get; set; }
        public float RelativeHumidity { get; set; }
        public float Lux { get; set; }
    }
}
