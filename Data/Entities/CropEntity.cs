using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Waterer.Data.Entities
{
    public class CropEntity
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }

        public DateTime? PlantedDate { get; set; }
        
        public DateTime? CreatedDate { get; set; }
        [JsonIgnore]
        public List<CropStatusEntity> CropStatuses { get; set; }
    }
}
