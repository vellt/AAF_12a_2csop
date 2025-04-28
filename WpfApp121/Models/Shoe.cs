using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp121.Models
{
    class Shoe
    {
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("price")]
        public string Price { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
