using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVShow
{
    public class Episode
    {
        private int viewers;
        private double scoreSum;
        private double maxScore;

        public Episode(int viewers = 0, double scoreSum = 0, double maxScore = 0)
        {
            this.viewers = viewers;
            this.scoreSum = scoreSum;
            this.maxScore = maxScore;
        }

        public void AddView(double score)
        {
            this.viewers++;
            if (this.maxScore < score) this.maxScore = score;
            scoreSum += score;
        }

        public double GetAverageScore()
        {
            return this.scoreSum / this.viewers;
        }

        public int GetViewerCount()
        { 
            return this.viewers; 
        }

        public double GetMaxScore()
        {
            return maxScore;
        }
    }
}
