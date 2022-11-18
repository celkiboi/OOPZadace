using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow
{
    public class Description
    {
        private string episodeName;
        private TimeSpan duration;
        private uint episodeNumber;

        public Description(uint episodeNumber, TimeSpan duration, string episodeName)
        {
            this.episodeNumber = episodeNumber;
            this.duration = duration;
            this.episodeName = episodeName;
        }

        public string EpisodeName
        {
            get { return episodeName; }
        }

        public TimeSpan Duration
        {
            get { return duration; }
        }

        public uint EpisodeNumber
        {
            get { return episodeNumber; }
        }

        public override string ToString()
        {
            return $"{this.episodeNumber},{this.duration},{this.episodeName}";
        }
    }
}
