using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp125.Models
{
    class Szereplo
    {
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("human")]
        public string Species { get; set; }
    }
}
