using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp115.Models
{
    class Movie
    {
        [JsonProperty("age_rating")]
        public int AgeRating { get; set; }
        [JsonProperty("genre")]
        public string Genre { get; set; }
        [JsonProperty("image")]
        public string Image { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
