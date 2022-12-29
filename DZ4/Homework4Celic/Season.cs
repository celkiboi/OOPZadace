using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow
{
    public class Season : IEnumerable<Episode>
    {
        private List<Episode> episodes;
        private int seasonNumber;
        private int count;

        readonly string formatedLine = "=================================================\n";

        public Season(int seasonNumber, List<Episode> episodes)
        {
            this.seasonNumber = seasonNumber;
            this.episodes = episodes;
            count = episodes.Count;
        }
        
        public Season(Season original)
        {
            this.seasonNumber = original.seasonNumber;
            this.episodes = CopyEpisodeList(original.episodes);
            count = original.Count;
        }

        private List<Episode> CopyEpisodeList(List<Episode> list)
        {
            List<Episode> copy = new List<Episode>();

            foreach(Episode episode in list) 
            {
                copy.Add(new Episode(episode));
            }

            return copy;
        }

        public int SeasonNumber
        {
            get { return seasonNumber; }
        }

        public int Count
        {
            get { return count; }
        }

        public Episode this[int index]
        {
            get { return episodes[index]; }
            set { episodes[index] = value; }
        }

        public int GetTotalViewers()
        {
            int totalViewers = 0;

            foreach (Episode episode in episodes)
            {
                totalViewers += episode.GetViewerCount();
            }

            return totalViewers;
        }

        private TimeSpan GetBingeLenght()
        {
            TimeSpan bingeLenght = TimeSpan.Zero;

            foreach (Episode episode in episodes)
            {
                bingeLenght += episode.GetDescription().Duration;
            }

            return bingeLenght;
        }

        public DateTime GetBingeEnd()
        {
            return DateTime.Now + GetBingeLenght();
        }

        public override string ToString()
        {
            string season = $"Season {seasonNumber}:\n";
            season += formatedLine;

            foreach (Episode episode in episodes)
            {
                season += episode.ToString() + "\n";
            }

            season += "Report:\n";
            season += formatedLine;
            season += $"Total viewers: {GetTotalViewers()}\n";
            season += $"Total duration: {GetBingeLenght()}\n";
            season += formatedLine;

            return season;
        }

        public IEnumerator<Episode> GetEnumerator()
        {
            return episodes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Remove(string title)
        {
            bool foundEpisode = false;

            for(int i=0;i<episodes.Count;i++) 
            {
                if (episodes[i].GetDescription().EpisodeName == title)
                {
                    episodes.RemoveAt(i); 
                    foundEpisode = true;
                    break;
                }
            }

            if(foundEpisode == false)
            {
                throw new TvException("No episode found", title);
            }
        }
    }
}
