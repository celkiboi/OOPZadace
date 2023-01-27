using System;
using System.Text.Json.Serialization;

namespace TVShowLogic
{
    public record class Episode(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("season")] int Season,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("airdate")] string Airdate,
        [property: JsonPropertyName("airtime")] string Airtime,
        [property: JsonPropertyName("runtime")] int Runtime,
        [property: JsonPropertyName("average")] float Rating
        )
    {
        public override string ToString()
        {
            return $"{Id} {Name} {Season}";
        }
    }
}
