using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TVShowLogic
{
    public record class Show(
        [property: JsonPropertyName("id")] int Id,
        [property: JsonPropertyName("name")] string Name,
        [property: JsonPropertyName("type")] string Type,
        [property: JsonPropertyName("language")] string Language,
        [property: JsonPropertyName("genres")] string[] Genres,
        [property: JsonPropertyName("status")] string Ended,
        [property: JsonPropertyName("premiered")] string Premiered,
        [property: JsonPropertyName("ended")] string End,
        [property: JsonPropertyName("network")] Network Owner
        )
    {
        public override string ToString()
        {
            return $"{Name}, Premiere: {PremiereDateTime.Year}, ID:{Id}";
        }

        internal static Show Parse(SearchResult result) 
        {
            return result.Show;
        }

        internal static Show[] Parse(SearchResult[] results)
        {
            Show[] shows = new Show[results.Length];

            for (int i = 0; i < results.Length; i++)
            {
                shows[i] = Parse(results[i]);
            }

            return shows;
        }

        public DateTime PremiereDateTime
        {
            get 
            {
                if (Premiered == null)
                    return DateTime.MinValue;

                return DateTime.Parse(Premiered); 
            }
        }

        public string GetInfo()
        {
            return $"""
                    Name: {Name}
                    Type: {Type}
                    Premiered: {Premiered}
                    Running/Ended: {Ended}
                    

                    """;
        }
    }
}
