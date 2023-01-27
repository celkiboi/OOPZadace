using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVShowLogic
{
    public record class Network(
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("country")] Country Country
        )
    {

    }
}
