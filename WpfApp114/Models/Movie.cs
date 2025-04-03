using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json; // annotációk miatt

namespace WpfApp114.Models
{
    class Movie
    {
        [JsonProperty("age_rating")]
        public int AgeRating { get; set; } // korhatár
        [JsonProperty("genre")]
        public string Genre { get; set; } // műfaj
        [JsonProperty("image")]
        public string Image { get; set; } // poszter
        [JsonProperty("title")]
        public string Title { get; set; }  // cím
    }
}
