using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GS.Shared
{
    public class Trackable
    {
        public int Id { get; set; }
        public string InternalIdentifier { get; set; } = string.Empty;
        public string ManufacturerIdentifier { get; set; } = string.Empty;
        public int TrackableColorId { get; set; }
        public int TrackableYearId { get; set; }
        public string TrackableMake { get; set;} = string.Empty;
        public string TrackableModel { get; set;} = string.Empty;
        public string? TrackableTrimLevel { get; set;} = string.Empty;
        public DateTime? RegistrationExpiry { get; set; }
        public DateTime? InsuranceExpiry { get; set; }


        public TrackableColor TrackableColor { get; set; } = new TrackableColor();
        public TrackableYear TrackableYear { get; set; } = new TrackableYear();
        [JsonIgnore]
        public List<WorkOrder> WorkOrders { get; set; } = new List<WorkOrder>();
    }
}
