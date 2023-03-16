using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Shared
{
    public class Note
    {
        public int id { get; set; }
        public required string Title { get; set; } = string.Empty;
        public required string Description { get; set; } = string.Empty;
        public int? WorkOrderId { get; set; }
        public WorkOrder? WorkOrder { get; set; }
    }
}
