using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVShowLogic
{
    public record class Season(
        [property: JsonPropertyName("id")] int? Id,
        [property: JsonPropertyName("number")] int? Number,
        [property: JsonPropertyName("episodeOrder")] int? Episodes,
        [property: JsonPropertyName("preirereDate")] string PremiereDate,
        [property: JsonPropertyName("endDate")] string EndDate,
        [property: JsonPropertyName("name")] string? Name

        )
    {
        public override string ToString()
        {
            return $"Season: {Number}, Title: {Name}, Episodes: {Episodes}";
        }

        public string GetInfo()
        {
            if (Episodes== null) 
            { 
                throw new NotReleasedException("The season is not released yet"); 
            }

            return $"""
                    Name: {Name}
                    Number: {Number}
                    Episodes: {Episodes}
                    Premiered: {PremiereDate}
                    """;
        }
    }
}
