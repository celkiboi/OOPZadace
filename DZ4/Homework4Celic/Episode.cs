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
        private Description description;

        public Episode(int viewers, double scoreSum, double maxScore, Description description)
        {
            this.description = description;
            this.viewers = viewers;
            this.scoreSum = scoreSum;
            this.maxScore = maxScore;
        }

        public Episode(Episode original)
        {
            description = original.description;
            this.viewers = original.viewers;
            this.scoreSum = original.scoreSum;
            this.maxScore = original.maxScore;
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

        public Description GetDescription()
        {
            return description;
        }

        public static bool operator >(Episode leftHandSide, Episode rightHandSide)
        {
            return leftHandSide.GetAverageScore() > rightHandSide.GetAverageScore();
        }

        public static bool operator <(Episode leftHandSide, Episode rightHandSide)
        {
            return leftHandSide.GetAverageScore() < rightHandSide.GetAverageScore();
        }

        public override string ToString()
        {
            return $"{this.viewers},{this.GetAverageScore().ToString("0.00")},{this.GetMaxScore().ToString("0.00")},{this.description.ToString()}";
        }
    }
}
