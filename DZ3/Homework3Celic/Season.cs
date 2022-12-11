using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow
{
    public class Season
    {
        private Episode[] episodes;
        private int seasonNumber;
        private int length;

        readonly string formatedLine = "=================================================\n";

        public Season(int seasonNumber, Episode[] episodes)
        {
            this.seasonNumber = seasonNumber;
            this.episodes = episodes;
            length = episodes.Length;
        }

        public Episode[] Episodes
        {
            get { return episodes; }
        }

        public int SeasonNumber
        {
            get { return seasonNumber; }
        }

        public int Length
        {
            get { return length; }
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
    }
}
