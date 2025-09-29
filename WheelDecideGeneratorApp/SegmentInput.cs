using System;
using System.Collections.Generic;
using System.Media;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WheelDecideGeneratorApp
{
    /// <summary>
    /// Stores user input data for a Wheel Decide segment.
    /// </summary>
    public class SegmentInput
    {
        /// <summary>
        /// Represents the value visible on a segment. Must contain at least one character.
        /// </summary>
        public string Value { get; set; } = "Value";
        /// <summary>
        /// Represents the background colour of a segment. Defaults to white (#FFFFFF).
        /// </summary>
        public Color BackgroundColour { get; set; } = Color.FromRgb(255,255,255);
        /// <summary>
        /// Represents the text colour of a segment. Defaults to black (#000000).
        /// </summary>
        public Color TextColour { get; set; } = Color.FromRgb(0,0,0);
        /// <summary>
        /// Represents a segment's weight, or relative size compared to other segments.
        /// </summary>
        public double Weight { get; set; } = 1;
    }
}
