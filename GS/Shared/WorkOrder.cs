using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GS.Shared
{
    public class WorkOrder
    {
        public int Id {  get; set; }
        public required string InitialIssue { get; set; } = string.Empty;
        public int TrackableId { get; set; }
        public string? WorkCompleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModified { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime? CompletedDate { get; set; }
        public decimal? WorkOrderCost { get; set; }
        public decimal? WorkOrderPartsCost { get; set; }
        public decimal? WorkOrderLaborCost { get; set; }

        [JsonIgnore]
        public List<Note> Notes { get; set; } = new List<Note>();
        public Trackable Trackable { get; set; } = new Trackable();
    }
}
