using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WpfApp108.Models
{
    //id;name;age;gender;fur_length;image_path
    class Cica
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("age")]
        public int Age { get; set; }
        [JsonProperty("gender")]
        public string Gender { get; set; }
        [JsonProperty("fur_length")]
        public string FurLenght { get; set; }
        [JsonProperty("image_path")]
        public string ImagePath { get; set; }
    }
}
