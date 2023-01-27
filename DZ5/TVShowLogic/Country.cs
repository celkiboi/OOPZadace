using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVShowLogic
{
    public record class Country(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("code")] string Code,
        [property: JsonPropertyName("timezone")] string TimeZone
        )
    {}
}
