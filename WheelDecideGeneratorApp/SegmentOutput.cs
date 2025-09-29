using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Represents user data to be outputted to Wheel Decide.
    /// </summary>
    public class SegmentOutput
    {
        /// <summary>
        /// The text value of the segment.
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// The background colour of the segment.
        /// </summary>
        public string BackgroundColour { get; set; }
        /// <summary>
        /// The colour of the segment's text value.
        /// </summary>
        public string TextColour { get; set; }
        /// <summary>
        /// The segment's weight, or relative size compared to other segments.
        /// </summary>
        public string Weight { get; set; }

        public SegmentOutput(SegmentInput segmentInput)
        {
            Value = segmentInput.Value;
            BackgroundColour = segmentInput.BackgroundColour.ToString().Substring(3);
            TextColour = segmentInput.TextColour.ToString().Substring(3);
            
            string weight = segmentInput.Weight.ToString();
            if (weight.Length > 2) Weight = weight.Substring(0,3);
            else Weight = weight;
        }
    }
}
