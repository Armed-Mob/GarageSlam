using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GS.Shared
{
    public class TrackableColor
    {
        public int Id { get; set; }
        public string ColorName { get; set; } = string.Empty;

        [JsonIgnore]
        public List<Trackable> Trackables { get; set; } = new List<Trackable>();
    }
}
