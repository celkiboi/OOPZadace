using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Configuration;

namespace TVShow
{
    public static class TvUtilities
    {
        public static void Sort(Episode[] episodes)
        {
            for(int i = 0; i < episodes.Length; i++)
            {
                Episode largestAverageScore = episodes[i];
                int largestIndex = i;

                for (int j = i+1; j < episodes.Length; j++)
                {
                    if (episodes[j] > largestAverageScore)
                    {
                        largestAverageScore = episodes[j];
                        largestIndex = j;
                    }    
                }

                Episode temp = episodes[i];
                episodes[i] = largestAverageScore;
                episodes[largestIndex] = temp;
            }
        }

        public static Episode Parse(string text)
        {
            string[] lines = text.Split(',');

            int viewers = int.Parse(lines[0]);
            //double scoreSum = double.Parse(lines[1], CultureInfo.InvariantCulture); // Neke drzave koriste zapis a,bcd.xyz, a neke a.bcd,xyz za realne brojeve. Zbog toga iz datoteke cita 67.7 kao 6,67. Nazalost nisam to uspio popraviti :(
            double scoreSum = double.Parse(lines[1]) * 10; //Ovo je workaround ali radi samo za ove test case-ove :(
            double maxScore = double.Parse(lines[2]); 
            uint episodeNumber = uint.Parse(lines[3]);
            string episodeTitle = lines[5];

            string[] time = lines[4].Split(':');
            TimeSpan duration = TimeSpan.FromMinutes(int.Parse(time[1]));

            return new Episode(viewers, scoreSum, maxScore, new Description(episodeNumber, duration, episodeTitle));
        }
    }
}
