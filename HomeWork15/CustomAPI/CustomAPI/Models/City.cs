using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CustomAPI.Models
{
    public class City
    {
        public long Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public Country Country { get; set; }

        [NotMapped]
        public string CountryName
        {
            get { return this.Country?.Name; }
        }
    }
}
