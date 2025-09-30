using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Stores a wheel's data that can be used on Wheel Decide
    /// </summary>
    public class WheelOutput
    {
        /// <summary>
        /// The title of the wheel.
        /// </summary>
        public string WheelTitle { get; set; }

        /// <summary>
        /// The amount of time, in seconds the wheel will spin.
        /// </summary>
        public int SpinDuration { get; set; }

        /// <summary>
        /// The size of the wheel, in pixels.
        /// </summary>
        public int WheelWidth { get; set; }

        /// <summary>
        /// If trus, removes the segment selected after a spin.
        /// </summary>
        public bool RemoveSelectedSegment { get; set; }

        /// <summary>
        /// Stores a wheel's segments.
        /// </summary>
        public List<SegmentOutput> Segments { get; set; } = new List<SegmentOutput>();

        /// <summary>
        /// Generates a string with a URL to use the wheel immediately.
        /// </summary>
        /// <returns></returns>
        public string GetWheelUrl()
        {
            //Creates url StringBuilder with Wheel Decide URL
            var url = new StringBuilder("https://wheeldecide.com/?");

            //Step 1: adds segment values
            for (int i = 0; i < Segments.Count; i++)
            {
                //Appends value with key of 1 plus index
                url.Append($"c{i + 1}={Segments[i].Value}");
                //Adds an end if index is less than total segments
                if(i + 1 < Segments.Count) url.Append('&');
            }

            //Step 2: adds background colours
            var backgroundColours = Segments.Select(s => s.BackgroundColour).ToList();
            if (backgroundColours.All(c => backgroundColours.First() == c))
                url.Append($"&cols={backgroundColours.First()}");
            else url.Append($"&cols={string.Join(",", backgroundColours)}");

            //Step 3: adds text colours
            var textColours = Segments.Select(s => s.TextColour).ToList();
            if (textColours.All(c => textColours.First() == c))
                url.Append($"&tcol={textColours.First()}");
            else url.Append($"&tcol={string.Join(",", textColours)}");

            //Step 4: adds segment weights
            var weights = Segments.Select(s => s.Weight).ToList();
            if (weights.All(w => weights.First() == w))
                url.Append($"&weights={weights.First()}");
            else url.Append($"&weights={string.Join(",", weights)}");

            //Step 5: adds title, if any
            if (!string.IsNullOrWhiteSpace(WheelTitle))
                url.Append($"&t={WheelTitle}");

            //Step 6: sets spin duration
            url.Append($"&time={SpinDuration}");

            //Step 7: sets wheel width
            url.Append($"&width={WheelWidth}");

            //Step 8: sets remove selected segment if true
            if (RemoveSelectedSegment)
                url.Append("&remove=1");

            return url.ToString();
        }

        /// <summary>
        /// Gets all segment values, joined with line breaks.
        /// </summary>
        public string GetValues
        {
            get
            {
                return string.Join("\n", Segments.Select(s => s.Value));
            }
        }

        /// <summary>
        /// Gets all segment background colours, joined with line breaks.
        /// </summary>
        public string GetBackgroundColours
        {
            get
            {
                return string.Join(",", Segments.Select(s => s.BackgroundColour));
            }
        }

        /// <summary>
        /// Gets all segment background colours, joined with line breaks.
        /// </summary>
        public string GetTextColours
        {
            get
            {
                return string.Join(",", Segments.Select(s => s.TextColour));
            }
        }

        /// <summary>
        /// Gets all segment weights, joined with line breaks.
        /// </summary>
        public string GetWeights
        {
            get
            {
                return string.Join(",", Segments.Select(s => s.Weight));
            }
        }
    }
}
