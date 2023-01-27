using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TVShowLogic
{
    public static class Utilities
    {
        static HttpClient client;

        static Utilities()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
        }

        public static Show[]? SearchShows(string query)
        {
            string search = $"https://api.tvmaze.com/search/shows?q={query}";
            //return Show.Parse(ProcessRepositoriesAsync<SearchResult[]>(search).Result);
            var s = ProcessRepositories<SearchResult[]>(search);
            return Show.Parse(s);
        }


        public static Season[]? GetSeasons(Show show)
        {
            return (ProcessRepositories<Season[]>($"https://api.tvmaze.com/shows/{show.Id}/seasons"));
        }

        public static Episode[]? GetEpisodes(Season season)
        {
            if (season.Episodes == null)
                throw new NotReleasedException("This season is not released yet");

            return (ProcessRepositories<Episode[]>($"https://api.tvmaze.com/seasons/{season.Id}/episodes"));
        }

        
        static T? ProcessRepositories<T>(string url)
        {
            Stream stream;
            T? repositories = default(T);
            var task = Task.Run(() =>
            {

                stream = client.GetStreamAsync(url).Result;
                repositories =
                     JsonSerializer.DeserializeAsync<T>(stream).Result;
            });
            task.Wait();
            return repositories;
        }
    }
}
